using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankClient
{
    public class City : IEquatable<City>
    {
        public int id { get; set; }
        public string name { get; set; }

        public bool Equals(City? other)
        {
            if (other is null)
            {
                return false;
            }

            return id == other.id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as City);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return name;
        }
    }
}
