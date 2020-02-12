using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactUpdateTests : TestBase
    {

    [Test]
    public void ContactUpdateTest()
        {
            ContactData contact = new ContactData("John", "Smith1");
            contact.Nickname = "TestUser1";
            contact.Title = "QA1";
            contact.Company = "Some Company1";
            contact.Address = "N2B 4E31";
            contact.Home = "51973110001";
            contact.Email = "test@gmail.com1";
            contact.Bday = "14";
            contact.Bmonth = "April";
            contact.Byear = "2001";

            app.Contacts.Update(contact);
            app.Navigator.OpenHomePage();
        }
    }
}
