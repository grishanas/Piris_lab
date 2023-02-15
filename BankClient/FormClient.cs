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
        private bool isEdit = false;
        private readonly HttpClient httpClient;
        private readonly List<City>? cities;
        private readonly List<FamilyStatus>? familyStatuses;
        private readonly List<Citizenship>? citizenships;
        private readonly List<Disability>? disabilities;
        public Client Client { get; private set; }

        public FormClient(FormMain frmMain, Client? client = null)
        {
            InitializeComponent();

            isEdit = client != null;

            if (isEdit)
            {
                Client = client!.GetClone();
                FillFields();
            }
            else
            {
                Client = new Client();

                for (int i = tabControlClient.TabPages.Count - 1; i >= 1; --i)
                {
                    tabControlClient.TabPages.RemoveAt(i);
                }
            }

            tbxId.ReadOnly = isEdit;

            httpClient = frmMain.httpClient;
            cities = frmMain.cities;
            familyStatuses = frmMain.familyStatuses;
            citizenships = frmMain.citizenships;
            disabilities = frmMain.disabilities;
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

            if (tbxPassportNumber.Text.Length != 9)
            {
                MessageBox.Show("The passport number must be 9 symbols long");
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
    }
}
