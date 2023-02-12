using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class FamilyStatus
    {
        public int id { get; set; }
        public string status_name { get; set; }
        public override string ToString()
        {
            return status_name;
        }
    }
}
