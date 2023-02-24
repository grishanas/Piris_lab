using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BankClient
{
    public partial class FormBalanceHistory : Form
    {
        public FormBalanceHistory(Balance[] balances)
        {
            InitializeComponent();

            formsPlotMain.Plot.AddScatter(Enumerable.Range(0, balances.Length).Select(v => (double)v).ToArray(), 
                balances.Select(b => (double)b.count).ToArray());
        }
    }
}
