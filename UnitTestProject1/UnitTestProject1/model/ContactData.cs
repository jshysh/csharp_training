using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string lastName, string firstName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Email { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Id { get; set; }


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName
                && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "lastName= " + LastName + " firstName= " + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            {
                if (object.ReferenceEquals(other, null))
                {
                    return 1;
                }

                if (LastName.CompareTo(other.LastName) != 0)
                {
                    return LastName.CompareTo(other.LastName);
                }
                else if (FirstName.CompareTo(other.FirstName) != 0)
                {
                    return FirstName.CompareTo(other.FirstName);
                }

                return 0;
            }
        }
    }
}
