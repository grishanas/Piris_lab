using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class Citizenship : IEquatable<Citizenship>
    {
        public int id { get; set; }
        public string nationality { get; set; }

        public bool Equals(Citizenship? other)
        {
            if (other is null)
            {
                return false;
            }

            return id == other.id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Citizenship);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return nationality;
        }
    }
}
