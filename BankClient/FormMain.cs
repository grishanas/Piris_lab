using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;

namespace BankClient
{
    public partial class FormMain : Form
    {
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
                BaseAddress = new Uri("http://127.0.0.1:5242/")
            };
        }

        private readonly HttpClient httpClient;
        private List<Client>? clients = null;
        private List<City>? cities = null;
        private List<FamilyStatus>? familyStatuses = null;
        private List<Citizenship>? citizenships = null;
        private List<Disability>? disabilities = null;

        private void FormMain_Load(object sender, EventArgs e)
        {
            
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
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



        #endregion

        #region Disabilities



        #endregion Disabilites
    }
}