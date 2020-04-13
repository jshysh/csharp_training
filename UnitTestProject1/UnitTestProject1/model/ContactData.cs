using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;

        public ContactData()
        {
        }

        public ContactData(string lastName, string firstName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string Home { get; set; }

        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "work")]
        public string Work { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
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

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    return (EndStringInsert(EndStringInsert(ContactDetailsList(
                        FirstName, LastName, Nickname, Title, Company, Address)))
                        + EndStringInsert(EndStringInsert(GetTelephoneList(Home, Mobile, Work)))
                        + EndStringInsert(EndStringInsert(GetEmailList(Email, Email2, Email3)))).Trim();
                }
            }
            set
            {
                allDetails = value;
            }
        }

        public string GetEmailList(string email, string email2, string email3)
        {
            string form = "";

            if (email != null && email != "")
            {
                form = form + EndStringInsert(email);
            }
            if (email2 != null && email2 != "")
            {
                form = form + EndStringInsert(email2);
            }
            if (email3 != null && email3 != "")
            {
                form = form + EndStringInsert(email3);
            }
            return form.Trim();
        }


        public string GetTelephoneList(string home, string mobile, string work)
        {
            string form = "";

            if (home != null && home != "")
            {
                form = form + "H: " + EndStringInsert(Home);
            }
            if (mobile != null && mobile != "")
            {
                form = form + "M: " + EndStringInsert(Mobile);
            }
            if (work != null && work != "")
            {
                form = form + "W: " + EndStringInsert(Work);
            }
            return form.Trim();
        }

        public string StartStringInsert(string line)
        {
            if (line == null || line == "")
            {
                return "";
            }
            return "\r\n" + line;
        }

        public string EndStringInsert(string line)
        {
            if (line == null || line == "")
            {
                return "";
            }
            return line + "\r\n";
        }

        public string ContactDetailsList(
                  string firstname,
                  string lastname,
                  string nickname,
                  string title,
                  string company,
                  string address)
        {
            return (EndStringInsert(GetFullName(firstname, lastname))
                + EndStringInsert(nickname)
                + EndStringInsert(title)
                + EndStringInsert(company)
                + EndStringInsert(address)).Trim();
        }

        public string GetFullName(string firstname, string lastname)
        {
            string form = "";

            if (firstname != null && firstname != "")
            {
                form = FirstName + " ";
            }
            if (lastname != null && lastname != "")
            {
                form = form + LastName + " ";
            }
            return form.Trim();
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

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }

    }
}