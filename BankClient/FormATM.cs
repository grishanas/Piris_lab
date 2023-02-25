using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankClient
{
    public partial class FormATM : Form
    {
        private readonly HttpClient httpClient;
        private readonly CreditCard creditCard;
        private readonly UserAccountID accountID;
        private readonly List<Account>? accounts;

        public FormATM(FormMain frmMain)
        {
            InitializeComponent();

            tabCtrlMain.Appearance = TabAppearance.FlatButtons;
            tabCtrlMain.ItemSize = new Size(0, 1);
            tabCtrlMain.SizeMode = TabSizeMode.Fixed;

            httpClient = frmMain.httpClient;
            creditCard = new CreditCard();
            accountID = new UserAccountID();
            accounts = frmMain.accounts;
        }

        private bool CheckInsertFields()
        {
            if (string.IsNullOrWhiteSpace(tboxCardNumber.Text) ||
                string.IsNullOrWhiteSpace(tboxCardDate.Text))
            {
                MessageBox.Show("One or more required fields are not filled out");
                return false;
            }

            if (!DateTime.TryParseExact(tboxCardDate.Text, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out _))
            {
                MessageBox.Show("Card date formatting error");
                return false;
            }

            return true;
        }

        private void GetInsertFields()
        {
            creditCard.id = tboxCardNumber.Text;
            creditCard.valid_time = DateTime.ParseExact(tboxCardDate.Text, "MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        private void ResetCurrentTabControls()
        {
            TabPage currPage = tabCtrlMain.SelectedTab;

            if (currPage == tabPageCard)
            {
                tboxCardDate.Text = string.Empty;
                tboxCardNumber.Text = string.Empty;
            }
            else if (currPage == tabPagePin)
            {
                tboxPin.Text = string.Empty;
            }
            else if (currPage == tabPageAmount)
            {
                nudAmount.Value = 0;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!CheckInsertFields())
            {
                return;
            }

            GetInsertFields();

            tabCtrlMain.SelectTab(tabPagePin);
            ResetCurrentTabControls();
        }

        private void GetPIN()
        {
            creditCard.password = tboxPin.Text;
        }

        private bool CardLogin()
        {
            CreditCardLogin login = new(creditCard);
            
            bool success;
            string res;
            try
            {
                res = httpClient.GetRequestString(HttpMethod.Post, $"api/CreditCard/LogIn?password={creditCard.password}",
                    JsonSerializer.Serialize(login), out success);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to authenticate");
                return false;
            }

            var node = JsonNode.Parse(res);

            var valueNode = node!["value"];

            var result = JsonSerializer.Deserialize<CreditCardLoginResult>(valueNode);

            if (!string.IsNullOrWhiteSpace(result!.detail))
            {
                if (result.detail.Contains("blocked", StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("This card is blocked");
                    tabCtrlMain.SelectTab(tabPageCard);
                    ResetCurrentTabControls();
                }
                else if (result.detail.Contains("object", StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("Invalid card");
                    tabCtrlMain.SelectTab(tabPageCard);
                    ResetCurrentTabControls();
                }
                else
                {
                    MessageBox.Show(result.detail);
                }

                return false;
            }

            accountID.account_id = result.account_id;
            accountID.account_code = result.account_code;

            return true;
        }

        private void GetAccountStatus()
        {
            var accountMain = accounts!.Find(acc => acc.account_id == accountID.account_id &&
                                                   acc.account_code.account_code == "2400");

            var accountInterest = accounts!.Find(acc => acc.account_id == accountID.account_id &&
                                                 acc.account_code.account_code == "2470");

            lblCheck.Text = $"Balance: {accountMain!.balance?.count}\n" +
                $"Interest: {accountInterest!.balance?.count}";
        }

        private void btnEnterPin_Click(object sender, EventArgs e)
        {
            if (tboxPin.Text.Length != 4)
            {
                MessageBox.Show("PIN not entered");
                return;
            }

            GetPIN();

            if (!CardLogin())
            {
                return;
            }

            GetAccountStatus();

            tabCtrlMain.SelectTab(tabPageMain);
        }

        private void btnTakeCard_Click(object sender, EventArgs e)
        {
            tabCtrlMain.SelectTab(tabPageCard);
            ResetCurrentTabControls();
        }

        private void btnCheckAccountStatus_Click(object sender, EventArgs e)
        {
            tabCtrlMain.SelectTab(tabPageCheck);
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            tabCtrlMain.SelectTab(tabPageAmount);
            ResetCurrentTabControls();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabCtrlMain.SelectTab(tabPageMain);
        }

        private bool CashOut()
        {
            bool success;
            string res;
            try
            {
                res = httpClient.GetRequestString(HttpMethod.Post, $"api/Credit/CashOut?amount={nudAmount.Value}",
                    JsonSerializer.Serialize(accountID), out success);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to withdraw cash");
                return false;
            }

            var result = JsonSerializer.Deserialize<HttpResponse>(res);

            if (!string.IsNullOrWhiteSpace(result!.contentType))
            {
                MessageBox.Show("Withdrawal failed");
                return false;
            }

            return true;
        }

        private void btnCashOut_Click(object sender, EventArgs e)
        {
            if (!CashOut())
            {
                return;
            }

            tabCtrlMain.SelectTab(tabPageWithdrawn);
        }
    }
}
