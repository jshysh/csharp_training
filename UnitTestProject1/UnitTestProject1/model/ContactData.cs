using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string fullName;


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
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Id { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(Home) + CleanUpPhone(Mobile) + CleanUpPhone(Work)).Trim();
                }
            }

            set
            {
                allPhones = value;
            }

        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }

            set
            {
                allEmails = value;
            }

        }

        public string FullName
        {
            get
            {
                if (fullName != null)
                {
                    return FullName;
                }
                else
                {
                    return (CleanUp(FirstName)) + (CleanUp(LastName));
                }
            }
        }

        private string CleanUpPhone(string s)
        {
            if (s == null || s == "")
            {
                return "";
            }
            return Regex.Replace(s, "[ -()]HMW:", "") + "\r\n";
        }

        private string CleanUp(string s)
        {
            if (s == null || s == "")
            {
                return "";
            }
            return Regex.Replace(s, "[ -()]", "") + "\r\n";
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
            return "lastName= " + LastName + "\nfirstName= " + FirstName + "\naddress = " + Address 
                + "\nhome = " + Home + "\nmobile = " + Mobile + "\nwork = " + Work
                + "\nemail = " + Email + "\nemail2 = " + Email2 + "\nemail3 = " + Email3;
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
