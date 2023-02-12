using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class Citizenship
    {
        public int citizenship_id { get; set; }
        public string nationality { get; set; }
        public override string ToString()
        {
            return nationality;
        }
    }
}
