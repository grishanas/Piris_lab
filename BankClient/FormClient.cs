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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankClient
{
    public partial class FormClient : Form
    {
        private readonly bool isEdit = false;
        public readonly HttpClient httpClient;
        private readonly List<Client>? clients;
        private readonly List<City>? cities;
        private readonly List<FamilyStatus>? familyStatuses;
        private readonly List<Citizenship>? citizenships;
        private readonly List<Disability>? disabilities;
        public readonly List<CurrencyType>? currencies;
        public readonly List<AccountCode>? accountCodes;
        public Client Client { get; private set; }

        public FormClient(FormMain frmMain, Client? client = null)
        {
            InitializeComponent();

            isEdit = client != null;

            tbxId.ReadOnly = isEdit;

            httpClient = frmMain.httpClient;
            clients = frmMain.clients;
            cities = frmMain.cities;
            familyStatuses = frmMain.familyStatuses;
            citizenships = frmMain.citizenships;
            disabilities = frmMain.disabilities;
            currencies = frmMain.currencies;
            accountCodes = frmMain.accountCodes;

            if (isEdit)
            {
                Client = client!.GetClone();
                FillFields();
                FillLists();
            }
            else
            {
                Client = new Client();

                for (int i = tabControlClient.TabPages.Count - 1; i >= 1; --i)
                {
                    tabControlClient.TabPages.RemoveAt(i);
                }
            }
        }

        private void FillLists()
        {
            FillLive();
            FillResidence();
            FillFamilyStatus();
            FillCitizenships();
            FillDisabilities();
        }

        private void FillLive()
        {
            var liveCities = Client.live.Intersect(cities);

            lboxLive.Items.AddRange(liveCities.ToArray());
        }

        private void FillResidence()
        {
            var residenceCities = Client.residence.Intersect(cities);

            lboxResidence.Items.AddRange(residenceCities.ToArray());
        }

        private void FillFamilyStatus()
        {
            var statuses = Client.familyStatus.Intersect(familyStatuses);

            lboxFamily.Items.AddRange(statuses.ToArray());
        }

        private void FillCitizenships()
        {
            var foundCitizenships = Client.citizenships.Intersect(citizenships);

            lboxCitizenship.Items.AddRange(foundCitizenships.ToArray());
        }

        private void FillDisabilities()
        {
            var foundDisabilities = Client.disabilities.Intersect(disabilities);

            lboxDisability.Items.AddRange(foundDisabilities.ToArray());
        }

        private bool CheckFields()
        {
            if (tbxId.Text.Length != 11)
            {
                MessageBox.Show("The ID must be 11 symbols long");
                return false;
            }

            if (tbxPassportSeries.Text.Length != 2)
            {
                MessageBox.Show("The passport series must be 2 symbols long");
                return false;
            }

            if (clients!.Any(client => string.Equals(client.passport_series, tbxPassportSeries.Text, 
                StringComparison.InvariantCulture)))
            {
                MessageBox.Show("Duplicate passport series");
                return false;
            }

            if (tbxPassportNumber.Text.Length != 9)
            {
                MessageBox.Show("The passport number must be 9 symbols long");
                return false;
            }

            if (clients!.Any(client => string.Equals(client.passport_number, tbxPassportNumber.Text,
                StringComparison.InvariantCulture)))
            {
                MessageBox.Show("Duplicate passport number");
                return false;
            }

            var regName = new Regex(@"[a-zA-zа-яА-я-]");
            if (!regName.IsMatch(tbxFirstName.Text))
            {
                MessageBox.Show("The first name contains invalid symbols");
                return false;
            }

            if (!regName.IsMatch(tbxMiddleName.Text))
            {
                MessageBox.Show("The middle name contains invalid symbols");
                return false;
            }

            if (!regName.IsMatch(tbxSecondName.Text))
            {
                MessageBox.Show("The second name contains invalid symbols");
                return false;
            }

            if (!DateTime.TryParseExact(tbxBirthday.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out _))
            {
                MessageBox.Show("Birthday formatting error");
                return false;
            }

            if (!DateTime.TryParseExact(tbxDateOfIssue.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out _))
            {
                MessageBox.Show("Date of issue formatting error");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(tbxMonthlyIncome.Text) &&
                !decimal.TryParse(tbxMonthlyIncome.Text, out _))
            {
                MessageBox.Show("Mothly income formatting error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbxId.Text) ||
                string.IsNullOrWhiteSpace(tbxFirstName.Text) ||
                string.IsNullOrWhiteSpace(tbxSecondName.Text) ||
                string.IsNullOrWhiteSpace(tbxMiddleName.Text) ||
                string.IsNullOrWhiteSpace(tbxBirthday.Text) ||
                string.IsNullOrWhiteSpace(tbxPassportSeries.Text) ||
                string.IsNullOrWhiteSpace(tbxPassportNumber.Text) ||
                string.IsNullOrWhiteSpace(tbxAuthority.Text) ||
                string.IsNullOrWhiteSpace(tbxDateOfIssue.Text) ||
                string.IsNullOrWhiteSpace(tbxPlaceOfBirth.Text) ||
                string.IsNullOrWhiteSpace(tbxAddressOfRegistration.Text))
            {
                MessageBox.Show("One or more required fields are not filled out");
                return false;
            }

            return true;
        }

        private void GetFields()
        {
            Client.id = tbxId.Text;
            Client.first_name = tbxFirstName.Text;
            Client.midle_name = tbxMiddleName.Text;
            Client.second_name = tbxSecondName.Text;
            Client.birthday = DateTime.ParseExact(tbxBirthday.Text, "dd/MM/yyyy", 
                CultureInfo.InvariantCulture, DateTimeStyles.None);
            Client.sex = cboxSex.Checked;
            Client.passport_series = tbxPassportSeries.Text;
            Client.passport_number = tbxPassportNumber.Text;
            Client.authority = tbxAuthority.Text;
            Client.date_of_issue = DateTime.ParseExact(tbxDateOfIssue.Text, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None);
            Client.place_of_birth = tbxPlaceOfBirth.Text;
            Client.mobile_phone = string.IsNullOrWhiteSpace(tbxMobilePhone.Text) ? null : tbxMobilePhone.Text;
            Client.home_phone = string.IsNullOrWhiteSpace(tbxHomePhone.Text) ? null : tbxHomePhone.Text;
            Client.email = string.IsNullOrWhiteSpace(tbxHomePhone.Text) ? null : tbxHomePhone.Text;
            Client.work_place = string.IsNullOrWhiteSpace(tbxWorkplace.Text) ? null : tbxWorkplace.Text;
            Client.work_position = string.IsNullOrWhiteSpace(tbxWorkPosition.Text) ? null : tbxWorkPosition.Text;
            Client.address_of_registration = tbxAddressOfRegistration.Text;
            Client.retired = cboxRetired.Checked;
            Client.monthly_income = string.IsNullOrWhiteSpace(tbxMonthlyIncome.Text) ? null : 
                decimal.Parse(tbxMonthlyIncome.Text);
            Client.military_conscription = cboxConscription.Checked;
        }

        private void FillFields()
        {
            tbxId.Text = Client.id;
            tbxFirstName.Text = Client.first_name;
            tbxMiddleName.Text = Client.midle_name;
            tbxSecondName.Text = Client.second_name;
            tbxBirthday.Text = Client.birthday.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            cboxSex.Checked = Client.sex;
            tbxPassportSeries.Text = Client.passport_series;
            tbxPassportNumber.Text = Client.passport_number;
            tbxAuthority.Text = Client.authority;
            tbxDateOfIssue.Text = Client.date_of_issue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            tbxPlaceOfBirth.Text = Client.place_of_birth;
            tbxMobilePhone.Text = Client.mobile_phone;
            tbxHomePhone.Text = Client.home_phone;
            tbxEmail.Text = Client.email;
            tbxWorkplace.Text = Client.work_place;
            tbxWorkPosition.Text = Client.work_position;
            tbxAddressOfRegistration.Text = Client.address_of_registration;
            cboxRetired.Checked = Client.retired;
            tbxMonthlyIncome.Text = Client.monthly_income.ToString();
            cboxConscription.Checked = Client.military_conscription;
        }

        private bool AddClient()
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "AddClient", JsonSerializer.Serialize(Client));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to add client");
                return false;
            }

            return true;
        }

        private bool EditClient()
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Patch, "api/client", JsonSerializer.Serialize(Client));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to edit client");
                return false;
            }

            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                return;
            }

            GetFields();

            if (isEdit)
            {
                if (!EditClient())
                {
                    return;
                }
            }
            else
            {
                if (!AddClient())
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

        #region Live

        private bool AddLive(ClientLive live)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "AddM2MLive", JsonSerializer.Serialize(live));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to add live");
                return false;
            }

            return true;
        }

        private bool DeleteLive(ClientLive live)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Delete, "DeleteM2MLive", JsonSerializer.Serialize(live));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to delete live");
                return false;
            }

            return true;
        }

        private void tsmiAddLive_Click(object sender, EventArgs e)
        {
            var frmChoice = new FormListChoose(cities);

            var dlgRes = frmChoice.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            City? city = frmChoice.ChosenObject as City;

            if (Client.live.Contains(city))
            {
                MessageBox.Show("Duplicate city");
                return;
            }

            var live = new ClientLive()
            {
                city_id = city.id,
                id = Client.id
            };

            if (!AddLive(live))
            {
                return;
            }

            Client.live.Add(city);
            lboxLive.Items.Add(city);
        }

        private void tsmiDeleteLive_Click(object sender, EventArgs e)
        {
            if (lboxLive.SelectedIndex == -1)
            {
                MessageBox.Show("No live selected");
                return;
            }

            int selInd = lboxLive.SelectedIndex;
            City selCity = lboxLive.SelectedItem as City;

            var live = new ClientLive()
            {
                city_id = selCity!.id,
                id = Client.id
            };

            if (!DeleteLive(live))
            {
                return;
            }

            lboxLive.Items.RemoveAt(selInd);
            Client.live.RemoveAt(selInd);
        }

        #endregion

        #region Residence

        private bool AddResidence(ClientResidence residence)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "AddM2MResidence", JsonSerializer.Serialize(residence));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to add residence");
                return false;
            }

            return true;
        }

        private bool DeleteResidence(ClientResidence residence)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Delete, "DelteM2MResidence", JsonSerializer.Serialize(residence));
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect");
                return false;
            }

            if (!success)
            {
                MessageBox.Show("Failed to delete residence");
                return false;
            }

            return true;
        }

        private void tsmiAddResidence_Click(object sender, EventArgs e)
        {
            var frmChoice = new FormListChoose(cities);

            var dlgRes = frmChoice.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            City? city = frmChoice.ChosenObject as City;

            if (Client.residence.Contains(city))
            {
                MessageBox.Show("Duplicate city");
                return;
            }

            var residence = new ClientResidence()
            {
                city_id = city.id,
                id = Client.id
            };

            if (!AddResidence(residence))
            {
                return;
            }

            Client.residence.Add(city);
            lboxResidence.Items.Add(city);
        }

        private void tsmiDeleteResidence_Click(object sender, EventArgs e)
        {
            if (lboxResidence.SelectedIndex == -1)
            {
                MessageBox.Show("No residence selected");
                return;
            }

            int selInd = lboxResidence.SelectedIndex;
            City selCity = lboxResidence.SelectedItem as City;

            var residence = new ClientResidence()
            {
                city_id = selCity!.id,
                id = Client.id
            };

            if (!DeleteResidence(residence))
            {
                return;
            }

            lboxResidence.Items.RemoveAt(selInd);
            Client.residence.RemoveAt(selInd);
        }

        #endregion

        #region FamilyStatus

        private bool AddFamilyStatus(ClientFamily family)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "AddM2MFamily", JsonSerializer.Serialize(family));
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

        private bool DeleteFamilyStatus(ClientFamily family)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Delete, "DeleteM2MFamily", JsonSerializer.Serialize(family));
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

        private void tsmiAddFimily_Click(object sender, EventArgs e)
        {
            var frmChoice = new FormListChoose(familyStatuses);

            var dlgRes = frmChoice.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            FamilyStatus? familyStatus = frmChoice.ChosenObject as FamilyStatus;

            if (Client.familyStatus.Contains(familyStatus))
            {
                MessageBox.Show("Duplicate family status");
                return;
            }

            var family = new ClientFamily()
            {
                id_family_status = familyStatus.id,
                id = Client.id
            };

            if (!AddFamilyStatus(family))
            {
                return;
            }

            Client.familyStatus.Add(familyStatus);
            lboxFamily.Items.Add(familyStatus);
        }

        private void tsmiDeleteFamily_Click(object sender, EventArgs e)
        {
            if (lboxFamily.SelectedIndex == -1)
            {
                MessageBox.Show("No family status selected");
                return;
            }

            int selInd = lboxFamily.SelectedIndex;
            FamilyStatus selStatus = lboxFamily.SelectedItem as FamilyStatus;

            var family = new ClientFamily()
            {
                id_family_status = selStatus!.id,
                id = Client.id
            };

            if (!DeleteFamilyStatus(family))
            {
                return;
            }

            lboxFamily.Items.RemoveAt(selInd);
            Client.familyStatus.RemoveAt(selInd);
        }


        #endregion

        #region Citizenship

        private bool AddCitizenship(ClientCitizenship citizenship)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "AddM2MCitezenship", JsonSerializer.Serialize(citizenship));
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

        private bool DeleteCitizenship(ClientCitizenship citizenship)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Delete, "DelteM2MCitizenship", JsonSerializer.Serialize(citizenship));
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

        private void tsmiAddCitizenship_Click(object sender, EventArgs e)
        {
            var frmChoice = new FormListChoose(citizenships);

            var dlgRes = frmChoice.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            Citizenship? citizenship = frmChoice.ChosenObject as Citizenship;

            if (Client.citizenships.Contains(citizenship))
            {
                MessageBox.Show("Duplicate citizenship");
                return;
            }

            var clientCtz = new ClientCitizenship()
            {
                citizenship_id = citizenship.id,
                id = Client.id
            };

            if (!AddCitizenship(clientCtz))
            {
                return;
            }

            Client.citizenships.Add(citizenship);
            lboxCitizenship.Items.Add(citizenship);
        }

        private void tsmiDeleteCitizenship_Click(object sender, EventArgs e)
        {
            if (lboxCitizenship.SelectedIndex == -1)
            {
                MessageBox.Show("No citizenship selected");
                return;
            }

            int selInd = lboxCitizenship.SelectedIndex;
            Citizenship selCitizenship = lboxCitizenship.SelectedItem as Citizenship;

            var clientCtz = new ClientCitizenship()
            {
                citizenship_id = selCitizenship.id,
                id = Client.id
            };

            if (!DeleteCitizenship(clientCtz))
            {
                return;
            }

            lboxCitizenship.Items.RemoveAt(selInd);
            Client.citizenships.RemoveAt(selInd);
        }


        #endregion

        #region Disability

        private bool AddDisability(ClientDisability disability)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Post, "AddM2MDisability", JsonSerializer.Serialize(disability));
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

        private bool DeleteDisability(ClientDisability disability)
        {
            bool success;
            try
            {
                success = httpClient.SendRequest(HttpMethod.Delete, "DeleteM2MDisability", JsonSerializer.Serialize(disability));
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

        private void tsmiAddDisability_Click(object sender, EventArgs e)
        {
            var frmChoice = new FormListChoose(disabilities);

            var dlgRes = frmChoice.ShowDialog();

            if (dlgRes == DialogResult.Cancel)
            {
                return;
            }

            Disability? selDisability = frmChoice.ChosenObject as Disability;

            if (Client.disabilities.Contains(selDisability))
            {
                MessageBox.Show("Duplicate disability");
                return;
            }

            var clientDsb = new ClientDisability()
            {
                dis_id = selDisability.id,
                id = Client.id
            };

            if (!AddDisability(clientDsb))
            {
                return;
            }

            Client.disabilities.Add(selDisability);
            lboxDisability.Items.Add(selDisability);
        }

        private void tsmiDeleteDisability_Click(object sender, EventArgs e)
        {
            if (lboxDisability.SelectedIndex == -1)
            {
                MessageBox.Show("No disability selected");
                return;
            }

            int selInd = lboxDisability.SelectedIndex;
            Disability selDisability = lboxDisability.SelectedItem as Disability;

            var clientDsb = new ClientDisability()
            {
                dis_id = selDisability.id,
                id = Client.id
            };

            if (!DeleteDisability(clientDsb))
            {
                return;
            }

            lboxDisability.Items.RemoveAt(selInd);
            Client.disabilities.RemoveAt(selInd);
        }

        #endregion

        private void tsmiAddDeposit_Click(object sender, EventArgs e)
        {
            var frmClient = new FormDeposit(this);

            var dlgRes = frmClient.ShowDialog();
        }
    }
}
