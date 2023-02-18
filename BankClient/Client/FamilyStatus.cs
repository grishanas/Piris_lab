using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class FamilyStatus : IEquatable<FamilyStatus>
    {
        public int id { get; set; }
        public string status_name { get; set; }

        public bool Equals(FamilyStatus? other)
        {
            if (other is null)
            {
                return false;
            }

            return id == other.id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as FamilyStatus);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return status_name;
        }
    }
}
