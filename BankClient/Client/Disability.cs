using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class Disability : IEquatable<Disability>
    {
        public int id { get; set; }
        public string name { get; set; }

        public bool Equals(Disability? other)
        {
            if (other is null)
            {
                return false;
            }

            return id == other.id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Disability);
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
