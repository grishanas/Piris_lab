using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankClient
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
