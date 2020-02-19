using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;
        private string nickname;
        private string title;
        private string company;
        private string address;
        private string home;
        private string email;
        private string bday;
        private string bmonth;
        private string byear;

        public ContactData(string lastName, string firstName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }

        public string Email 
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }

        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }

        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }

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
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName) + LastName.CompareTo(other.LastName);
        }

    }
}
