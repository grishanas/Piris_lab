using System;
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
        private Client[]? clients = null;

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void FetchClients()
        {
            var res = httpClient.GetRequestString(HttpMethod.Get, "api/client/");

            var node = Utils.GetJSONValue(res);

            clients = JsonSerializer.Deserialize<Client[]>(node);

            Array.Sort(clients, (Client a, Client b) => 
                string.Compare(a.second_name, b.second_name, StringComparison.InvariantCulture));
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lboxClients.Items.Clear();

            FetchClients();

            lboxClients.Items.AddRange(clients);
        }
    }
}