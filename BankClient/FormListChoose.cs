using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace BankClient
{
    public partial class FormListChoose : Form
    {
        public object ChosenObject { get; private set; }

        public FormListChoose(IList list)
        {
            InitializeComponent();

            for (int i = 0; i < list.Count; ++i)
            {
                lboxMain.Items.Add(list![i]);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lboxMain.SelectedIndex == -1)
            {
                MessageBox.Show("No object chosen");
                return;
            }

            ChosenObject = lboxMain.SelectedItem;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
