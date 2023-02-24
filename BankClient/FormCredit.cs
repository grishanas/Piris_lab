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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankClient
{
    public partial class FormCredit : Form
    {
        private readonly Account account;
        private readonly HttpClient httpClient;
        private readonly CreditCard creditCard;
        public FormCredit(FormMain frmMain, Account account)
        {
            InitializeComponent();

            this.account = account;
            httpClient = frmMain.httpClient;
            creditCard = new CreditCard()
            {
                UserAccountID = new UserAccountID(account)
            };
        }

        private bool AddCreditCard()
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "api/CreditCard/CreateCard", JsonSerializer.Serialize(creditCard));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to add credit card");
                return false;
            }

            return true;
        }

        private bool CheckFields()
        {
            if (string.IsNullOrWhiteSpace(tboxId.Text) ||
                string.IsNullOrWhiteSpace(tboxPassword.Text) ||
                string.IsNullOrWhiteSpace(tboxValidTime.Text))
            {
                MessageBox.Show("One or more required fields are not filled out");
                return false;
            }

            if (!DateTime.TryParseExact(tboxValidTime.Text, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out _))
            {
                MessageBox.Show("Valid time formatting error");
                return false;
            }

            if (tboxPassword.Text.Length != 4)
            {
                MessageBox.Show("The password must be 4 characters long");
            }

            return true;
        }

        private void GetFields()
        {
            creditCard.id = tboxId.Text;
            creditCard.valid_time = DateTime.ParseExact(tboxValidTime.Text, "MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None);
            creditCard.password = tboxPassword.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                return;
            }

            GetFields();

            if (!AddCreditCard())
            {
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
