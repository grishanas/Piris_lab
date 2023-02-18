using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class Client
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string midle_name { get; set; }
        public DateTime birthday { get; set; }
        public bool sex { get; set; }
        public string passport_series { get; set; }
        public string passport_number { get; set; }
        public string authority { get; set; }
        public DateTime date_of_issue { get; set; }
        public string place_of_birth { get; set; }
        public string? mobile_phone { get; set; }
        public string? home_phone { get; set; }
        public string? email { get; set; }
        public string? work_place { get; set; }
        public string? work_position { get; set; }
        public string address_of_registration { get; set; }
        public bool retired { get; set; }
        public decimal? monthly_income { get; set; }
        public bool military_conscription { get; set; }

        public List<City> live { get; set; } = new List<City>();

        public Client GetClone()
        {
            return (Client)MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{first_name} {midle_name} {second_name}";
        }
    }
}
