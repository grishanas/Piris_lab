using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;

namespace BankClient
{
    public partial class FormMain : Form
    {
        private const ushort port = 9000;
        public FormMain()
        {
            InitializeComponent();

            // Disable SSL verification
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    (message, cert, chain, sslPolicyErrors) => true
            };

            httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri($"http://127.0.0.1:{port}/")
            };
        }

        public readonly HttpClient httpClient;
        public List<Client>? clients = null;
        public List<City>? cities = null;
        public List<FamilyStatus>? familyStatuses = null;
        public List<Citizenship>? citizenships = null;
        public List<Disability>? disabilities = null;
        public List<CurrencyType>? currencies = null;
        public List<AccountCode>? accountCodes = null;
        public List<Account>? accounts = null;

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (FetchClients())
            {
                lboxClients.Items.AddRange(clients!.ToArray());
            }
            else
            {
                MessageBox.Show("Closing");
                Close();
            }

            if (FetchCities())
            {
                lboxCities.Items.AddRange(cities!.ToArray());
            }
            else
            {
                MessageBox.Show("Closing");
                Close();
            }

            if (FetchFamilyStatuses())
            {
                lboxFamilyStatuses.Items.AddRange(familyStatuses!.ToArray());
            }
            else
            {
                MessageBox.Show("Closing");
                Close();
            }

            if (FetchCitizenships())
            {
                lboxCitizenships.Items.AddRange(citizenships!.ToArray());
            }
            else
            {
                MessageBox.Show("Closing");
                Close();
            }

            if (FetchDisabilities())
            {
                lboxDisabilities.Items.AddRange(disabilities!.ToArray());
            }
            else
            {
                MessageBox.Show("Closing");
                Close();
            }

            if (!FetchCurrencies())
            {
                MessageBox.Show("Closing");
                Close();
            }

            if (!FetchAccountCodes())
            {
                MessageBox.Show("Closing");
                Close();
            }

            FillAccountsGridColumns();

            if (FetchAccounts())
            {
                FillAccountsGrid();
            }
            else
            {
                MessageBox.Show("Closing");
                Close();
            }
        }

        private bool FetchAccountCodes()
        {
            string res;
            bool success;

            try
            {
                res = httpClient.GetRequestString(HttpMethod.Get, "api/AccountCode", out success);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to get account codes");
                return false;
            }

            accountCodes = JsonSerializer.Deserialize<List<AccountCode>>(res);

            return true;
        }

        private bool FetchCurrencies()
        {
            string res;
            bool success;

            try
            {
                res = httpClient.GetRequestString(HttpMethod.Get, "api/Currency/", out success);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to get currency types");
                return false;
            }

            var node = Utils.GetJSONValue(res);

            currencies = JsonSerializer.Deserialize<List<CurrencyType>>(node);

            return true;
        }

        private bool FetchClients()
        {
            string res;
            bool success;

            try
            {
                res = httpClient.GetRequestString(HttpMethod.Get, "api/client/", out success);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to get clients");
                return false;
            }

            var node = Utils.GetJSONValue(res);

            clients = JsonSerializer.Deserialize<List<Client>>(node);

            clients!.Sort((Client a, Client b) =>
                string.Compare(a.second_name, b.second_name, StringComparison.InvariantCulture));

            return true;
        }

        private bool DeleteClient(string id)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Delete, "api/client", $"\"{id}\"");
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to delete client");
                return false;
            }

            return true;
        }

        private void tsmiRefreshClients_Click(object sender, EventArgs e)
        {
            lboxClients.Items.Clear();

            if (!FetchClients())
            {
                return;
            }

            lboxClients.Items.AddRange(clients!.ToArray());
        }

        private void tsmiDeleteClient_Click(object sender, EventArgs e)
        {
            if (lboxClients.SelectedIndex == -1)
            {
                MessageBox.Show("No client selected");
                return;
            }

            int selInd = lboxClients.SelectedIndex;
            Client selClient = clients![selInd];

            if (!DeleteClient(selClient.id))
            {
                return;
            }

            lboxClients.Items.Remove(selClient);
            clients!.RemoveAt(selInd);
        }

        private void tsmiAddClient_Click(object sender, EventArgs e)
        {
            var frmClient = new FormClient(this);

            var dlgRes = frmClient.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            lboxClients.Items.Clear();

            if (!FetchClients())
            {
                return;
            }

            lboxClients.Items.AddRange(clients!.ToArray());
        }

        private void tsmiEditClient_Click(object sender, EventArgs e)
        {
            if (lboxClients.SelectedIndex == -1)
            {
                MessageBox.Show("No client selected");
                return;
            }

            int selInd = lboxClients.SelectedIndex;
            Client client = clients![selInd];

            var frmClient = new FormClient(this, client);

            var dlgRes = frmClient.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            client = frmClient.Client;

            clients![selInd] = client;
            lboxClients.Items[selInd] = client;
        }

        #region Cities

        private bool FetchCities()
        {
            string res;
            bool success;

            try
            {
                res = httpClient.GetRequestString(HttpMethod.Get, "api/city/", out success);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to get cities");
                return false;
            }

            cities = JsonSerializer.Deserialize<List<City>>(res);

            return true;
        }

        private bool DeleteCity(City city)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Delete, "api/city", JsonSerializer.Serialize(city));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to delete city");
                return false;
            }

            return true;
        }

        private bool AddCity(City city)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "api/city", JsonSerializer.Serialize(city));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to add city");
                return false;
            }

            return true;
        }

        private bool EditCity(City city)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Patch, "api/city", JsonSerializer.Serialize(city));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to edit city");
                return false;
            }

            return true;
        }

        private void tsmiRefreshCities_Click(object sender, EventArgs e)
        {
            lboxCities.Items.Clear();

            if (!FetchCities())
            {
                return;
            }

            lboxCities.Items.AddRange(cities!.ToArray());
        }

        private void tsmiDeleteCity_Click(object sender, EventArgs e)
        {
            if (lboxCities.SelectedIndex == -1)
            {
                MessageBox.Show("No city selected");
                return;
            }

            int selInd = lboxCities.SelectedIndex;
            City selCity = cities![selInd];

            if (!DeleteCity(selCity))
            {
                return;
            }

            lboxCities.Items.Remove(selCity);
            cities!.RemoveAt(selInd);
        }

        private void tsmiAddCity_Click(object sender, EventArgs e)
        {
            var frmTbox = new FormTextbox();

            var dlgRes = frmTbox.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            var city = new City()
            {
                name = frmTbox.InText
            };

            if (!AddCity(city))
            {
                return;
            }

            lboxCities.Items.Clear();

            if (!FetchCities())
            {
                return;
            }

            lboxCities.Items.AddRange(cities!.ToArray());
        }

        private void tsmiEditCity_Click(object sender, EventArgs e)
        {
            if (lboxCities.SelectedIndex == -1)
            {
                MessageBox.Show("No city selected");
                return;
            }

            int selInd = lboxCities.SelectedIndex;
            City selCity = cities![selInd];
            string oldName = selCity.name;

            var frmTbox = new FormTextbox
            {
                InText = oldName
            };

            var dlgRes = frmTbox.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            selCity.name = frmTbox.InText;

            if (!EditCity(selCity))
            {
                selCity.name = oldName;
                return;
            }

            lboxCities.Items[selInd] = selCity;
        }

        #endregion

        #region FamilyStatuses

        private bool FetchFamilyStatuses()
        {
            string res;
            bool success;

            try
            {
                res = httpClient.GetRequestString(HttpMethod.Get, "api/familystatus/", out success);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to get family statuses");
                return false;
            }

            familyStatuses = JsonSerializer.Deserialize<List<FamilyStatus>>(Utils.GetJSONValue(res));

            return true;
        }

        private bool DeleteFamilyStatus(FamilyStatus familyStatus)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Delete, "api/familystatus", JsonSerializer.Serialize(familyStatus));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to delete family status");
                return false;
            }

            return true;
        }

        private bool AddFamilyStatus(FamilyStatus familyStatus)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "api/familystatus", JsonSerializer.Serialize(familyStatus));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to add family status");
                return false;
            }

            return true;
        }

        private bool EditFamilyStatus(FamilyStatus familyStatus)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Patch, "api/familystatus", JsonSerializer.Serialize(familyStatus));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to edit family status");
                return false;
            }

            return true;
        }

        private void tsmiRefreshFamilyStatuses_Click(object sender, EventArgs e)
        {
            lboxFamilyStatuses.Items.Clear();

            if (!FetchFamilyStatuses())
            {
                return;
            }

            lboxFamilyStatuses.Items.AddRange(familyStatuses!.ToArray());
        }

        private void tsmiDeleteFamilyStatus_Click(object sender, EventArgs e)
        {
            if (lboxFamilyStatuses.SelectedIndex == -1)
            {
                MessageBox.Show("No family statuses selected");
                return;
            }

            int selInd = lboxFamilyStatuses.SelectedIndex;
            FamilyStatus familyStatus = familyStatuses![selInd];

            if (!DeleteFamilyStatus(familyStatus))
            {
                return;
            }

            lboxFamilyStatuses.Items.Remove(familyStatus);
            familyStatuses!.RemoveAt(selInd);
        }

        private void tsmiAddFamilyStatus_Click(object sender, EventArgs e)
        {
            var frmTbox = new FormTextbox();

            var dlgRes = frmTbox.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            var familyStatus = new FamilyStatus()
            {
                status_name = frmTbox.InText
            };

            if (!AddFamilyStatus(familyStatus))
            {
                return;
            }

            lboxFamilyStatuses.Items.Clear();

            if (!FetchFamilyStatuses())
            {
                return;
            }

            lboxFamilyStatuses.Items.AddRange(familyStatuses!.ToArray());
        }

        private void tsmiEditFamilyStatus_Click(object sender, EventArgs e)
        {
            if (lboxFamilyStatuses.SelectedIndex == -1)
            {
                MessageBox.Show("No family status selected");
                return;
            }

            int selInd = lboxFamilyStatuses.SelectedIndex;
            FamilyStatus familyStatus = familyStatuses![selInd];
            string oldName = familyStatus.status_name;

            var frmTbox = new FormTextbox
            {
                InText = oldName
            };

            var dlgRes = frmTbox.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            familyStatus.status_name = frmTbox.InText;

            if (!EditFamilyStatus(familyStatus))
            {
                familyStatus.status_name = oldName;
                return;
            }

            lboxFamilyStatuses.Items[selInd] = familyStatus;
        }

        #endregion

        #region Citizenships

        private bool FetchCitizenships()
        {
            string res;
            bool success;

            try
            {
                res = httpClient.GetRequestString(HttpMethod.Get, "api/citizenship/", out success);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to get citizenships");
                return false;
            }

            citizenships = JsonSerializer.Deserialize<List<Citizenship>>(Utils.GetJSONValue(res));

            return true;
        }

        private bool DeleteCitizenship(Citizenship citizenship)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Delete, "api/citizenship", JsonSerializer.Serialize(citizenship));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to delete citizenship");
                return false;
            }

            return true;
        }

        private bool AddCitizenship(Citizenship citizenship)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "api/citizenship", JsonSerializer.Serialize(citizenship));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to add citizenship");
                return false;
            }

            return true;
        }

        private bool EditCitizenship(Citizenship citizenship)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Patch, "api/citizenship", JsonSerializer.Serialize(citizenship));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to edit citizenship");
                return false;
            }

            return true;
        }

        private void tsmiRefreshCitizenships_Click(object sender, EventArgs e)
        {
            lboxCitizenships.Items.Clear();

            if (!FetchCitizenships())
            {
                return;
            }

            lboxCitizenships.Items.AddRange(citizenships!.ToArray());
        }

        private void tsmiDeleteCitizenship_Click(object sender, EventArgs e)
        {
            if (lboxCitizenships.SelectedIndex == -1)
            {
                MessageBox.Show("No citizenship selected");
                return;
            }

            int selInd = lboxCitizenships.SelectedIndex;
            Citizenship citizenship = citizenships![selInd];

            if (!DeleteCitizenship(citizenship))
            {
                return;
            }

            lboxCitizenships.Items.Remove(citizenship);
            citizenships!.RemoveAt(selInd);
        }

        private void tsmiAddCitizenship_Click(object sender, EventArgs e)
        {
            var frmTbox = new FormTextbox();

            var dlgRes = frmTbox.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            var citizenship = new Citizenship()
            {
                nationality = frmTbox.InText
            };

            if (!AddCitizenship(citizenship))
            {
                return;
            }

            lboxCitizenships.Items.Clear();

            if (!FetchCitizenships())
            {
                return;
            }

            lboxCitizenships.Items.AddRange(citizenships!.ToArray());
        }

        private void tsmiEditCitizenship_Click(object sender, EventArgs e)
        {
            if (lboxCitizenships.SelectedIndex == -1)
            {
                MessageBox.Show("No citizenship selected");
                return;
            }

            int selInd = lboxCitizenships.SelectedIndex;
            Citizenship citizenship = citizenships![selInd];
            string oldName = citizenship.nationality;

            var frmTbox = new FormTextbox
            {
                InText = oldName
            };

            var dlgRes = frmTbox.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            citizenship.nationality = frmTbox.InText;

            if (!EditCitizenship(citizenship))
            {
                citizenship.nationality = oldName;
                return;
            }

            lboxCitizenships.Items[selInd] = citizenship;
        }

        #endregion

        #region Disabilities

        private bool FetchDisabilities()
        {
            string res;
            bool success;

            try
            {
                res = httpClient.GetRequestString(HttpMethod.Get, "api/disabilities/", out success);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to get disabilities");
                return false;
            }

            disabilities = JsonSerializer.Deserialize<List<Disability>>(Utils.GetJSONValue(res));

            return true;
        }

        private bool DeleteDisability(Disability disability)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Delete, "api/disabilities", JsonSerializer.Serialize(disability));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to delete disability");
                return false;
            }

            return true;
        }

        private bool AddDisability(Disability disability)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "api/disabilities", JsonSerializer.Serialize(disability));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to add disability");
                return false;
            }

            return true;
        }

        private bool EditDisability(Disability disability)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Patch, "api/disabilities", JsonSerializer.Serialize(disability));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to edit disability");
                return false;
            }

            return true;
        }

        private void tsmiRefreshDisabilities_Click(object sender, EventArgs e)
        {
            lboxDisabilities.Items.Clear();

            if (!FetchDisabilities())
            {
                return;
            }

            lboxDisabilities.Items.AddRange(disabilities!.ToArray());
        }

        private void tsmiDeleteDisability_Click(object sender, EventArgs e)
        {
            if (lboxDisabilities.SelectedIndex == -1)
            {
                MessageBox.Show("No disability selected");
                return;
            }

            int selInd = lboxDisabilities.SelectedIndex;
            Disability disability = disabilities![selInd];

            if (!DeleteDisability(disability))
            {
                return;
            }

            lboxDisabilities.Items.Remove(disability);
            disabilities!.RemoveAt(selInd);
        }

        private void tsmiAddDisability_Click(object sender, EventArgs e)
        {
            var frmTbox = new FormTextbox();

            var dlgRes = frmTbox.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            var disability = new Disability()
            {
                name = frmTbox.InText
            };

            if (!AddDisability(disability))
            {
                return;
            }

            lboxDisabilities.Items.Clear();

            if (!FetchDisabilities())
            {
                return;
            }

            lboxDisabilities.Items.AddRange(disabilities!.ToArray());
        }

        private void tsmiEditDisability_Click(object sender, EventArgs e)
        {
            if (lboxDisabilities.SelectedIndex == -1)
            {
                MessageBox.Show("No disability selected");
                return;
            }

            int selInd = lboxDisabilities.SelectedIndex;
            Disability disability = disabilities![selInd];
            string oldName = disability.name;

            var frmTbox = new FormTextbox
            {
                InText = oldName
            };

            var dlgRes = frmTbox.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            disability.name = frmTbox.InText;

            if (!EditDisability(disability))
            {
                disability.name = oldName;
                return;
            }

            lboxDisabilities.Items[selInd] = disability;
        }

        #endregion Disabilites

        private bool CloseDay()
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "api/CloseDay/CloseDay", string.Empty);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to close day");
                return false;
            }

            return true;
        }

        private void btnCloseDay_Click(object sender, EventArgs e)
        {
            if (!CloseDay())
            {
                return;
            }

            MessageBox.Show("Day closed");
        }

        private bool FetchAccounts()
        {
            string res;
            bool success;

            try
            {
                res = httpClient.GetRequestString(HttpMethod.Get, "api/Account/GetAccounts", out success);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to get accounts");
                return false;
            }

            var node = Utils.GetJSONValue(res);

            accounts = JsonSerializer.Deserialize<List<Account>>(node);

            return true;
        }

        private void FillAccountsGridColumns()
        {
            dgvAccounts.Columns.Add("1", "Account ID");
            dgvAccounts.Columns.Add("2", "Bank name");
            dgvAccounts.Columns.Add("3", "Start date");
            dgvAccounts.Columns.Add("4", "End date");
            dgvAccounts.Columns.Add("5", "Deadline");
            dgvAccounts.Columns.Add("6", "Interest rate");
            dgvAccounts.Columns.Add("7", "Currency type");
            dgvAccounts.Columns.Add("8", "Account code");
            dgvAccounts.Columns.Add("9", "Account type");
            dgvAccounts.Columns.Add("10", "Balance");
            dgvAccounts.Columns.Add("11", "Client id");
            dgvAccounts.Columns.Add("12", "Deadline");
        }

        private void FillAccountsGrid()
        {
            dgvAccounts.Rows.Clear();
            
            foreach (Account account in accounts)
            {
                int rInd = dgvAccounts.Rows.Add();
                dgvAccounts.Rows[rInd].Cells[0].Value = account.account_id;
                dgvAccounts.Rows[rInd].Cells[1].Value = account.bank_name;
                dgvAccounts.Rows[rInd].Cells[2].Value = account.start_date;
                dgvAccounts.Rows[rInd].Cells[3].Value = account.end_date;
                dgvAccounts.Rows[rInd].Cells[4].Value = account.deadline;
                dgvAccounts.Rows[rInd].Cells[5].Value = account.interest_rate;
                dgvAccounts.Rows[rInd].Cells[6].Value = account.currency_type.name;
                dgvAccounts.Rows[rInd].Cells[7].Value = account.account_code.account_code;
                dgvAccounts.Rows[rInd].Cells[8].Value = account.account_type.name;
                dgvAccounts.Rows[rInd].Cells[9].Value = account?.balance?.count;
                dgvAccounts.Rows[rInd].Cells[10].Value = account?.client_id;
                dgvAccounts.Rows[rInd].Cells[11].Value = account?.deadline;
            }
        }

        private void tsmiRefreshAccounts_Click(object sender, EventArgs e)
        {
            if (FetchAccounts())
            {
                FillAccountsGrid();
            }
        }
    }
}