using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
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
            clients.RemoveAt(selInd);
        }
    }
}