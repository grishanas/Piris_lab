using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class Disability
    {
        public int dis_id { get; set; }
        public string dis_name { get; set; }
        public override string ToString()
        {
            return dis_name;
        }
    }
}
