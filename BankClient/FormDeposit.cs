﻿using System;
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
    public partial class FormDeposit : Form
    {
        public FormDeposit(FormClient frmClient, bool isDeposit = true)
        {
            InitializeComponent();

            deposit = new Deposit();
            httpClient = frmClient.httpClient;
            client = frmClient.Client;
            currencies = frmClient.currencies;
            accountCodes = frmClient.accountCodes;
            this.isDeposit = isDeposit;
            Text = isDeposit ? "Deposit" : "Credit";

            for (int i = 0; i < currencies!.Count; ++i)
            {
                cmbxCurrencyType.Items.Add(currencies[i].name);
            }

            cmbxCurrencyType.SelectedIndex = 0;

            for (int i = 0; i < accountCodes!.Count; ++i)
            {
                cmbxAccountCode.Items.Add($"({accountCodes[i].account_code}) {accountCodes[i].description}");
            }

            cmbxAccountCode.SelectedIndex = 0;

            tbxAmount.Enabled = !isDeposit;
        }

        private readonly bool isDeposit;
        private readonly HttpClient httpClient;
        private readonly Client client;
        private readonly Deposit deposit;
        private readonly List<CurrencyType>? currencies;
        private readonly List<AccountCode>? accountCodes;
        private decimal amount;

        private bool CheckFields()
        {
            if (string.IsNullOrWhiteSpace(tbxAccountId.Text) ||
                string.IsNullOrWhiteSpace(tbxBankName.Text) ||
                string.IsNullOrWhiteSpace(tbxStartDate.Text) ||
                string.IsNullOrWhiteSpace(tbxEndDate.Text) ||
                string.IsNullOrWhiteSpace(tbxDeadline.Text))
            {
                MessageBox.Show("One or more required fields are not filled out");
                return false;
            }

            if (!DateTime.TryParseExact(tbxStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out _))
            {
                MessageBox.Show("Start date formatting error");
                return false;
            }

            if (!DateTime.TryParseExact(tbxEndDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out _))
            {
                MessageBox.Show("End date formatting error");
                return false;
            }

            if (!DateTime.TryParseExact(tbxDeadline.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out _))
            {
                MessageBox.Show("Deadline formatting error");
                return false;
            }

            if (!decimal.TryParse(tbxInterestRate.Text, out _))
            {
                MessageBox.Show("Interest rate formatting error");
                return false;
            }

            if (!isDeposit)
            {
                if (string.IsNullOrWhiteSpace(tbxAmount.Text))
                {
                    MessageBox.Show("Amount field not filled out");
                    return false;
                }

                if (!decimal.TryParse(tbxAmount.Text, out _))
                {
                    MessageBox.Show("Amount formatting error");
                    return false;
                }
            }

            return true;
        }

        private void GetFields()
        {
            deposit.account_id = tbxAccountId.Text;
            deposit.client_id = client.id;
            deposit.bank_name = tbxBankName.Text;
            deposit.start_date = DateTime.ParseExact(tbxStartDate.Text, "dd/MM/yyyy", 
                CultureInfo.InvariantCulture, DateTimeStyles.None);
            deposit.end_date = DateTime.ParseExact(tbxEndDate.Text, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None);
            deposit.deadline = DateTime.ParseExact(tbxDeadline.Text, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None);
            deposit.interest_rate = decimal.Parse(tbxInterestRate.Text);
            deposit.currency_type = currencies![cmbxCurrencyType.SelectedIndex].id;
            deposit.account_code = accountCodes![cmbxAccountCode.SelectedIndex].account_code;

            if (!isDeposit)
            {
                amount = decimal.Parse(tbxAmount.Text);
            }
        }

        private bool AddDeposit()
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "api/Deposit", JsonSerializer.Serialize(deposit));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to add deposit");
                return false;
            }

            return true;
        }

        private bool AddCredit()
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, $"api/Credit?amount={amount}", JsonSerializer.Serialize(deposit));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to add credit");
                return false;
            }

            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                return;
            }

            GetFields();

            if (isDeposit)
            {
                if (!AddDeposit())
                {
                    return;
                }
            }
            else
            {
                if (!AddCredit())
                {
                    return;
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
