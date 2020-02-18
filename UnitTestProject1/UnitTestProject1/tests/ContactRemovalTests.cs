using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemoval()
        {
            ContactData contact = new ContactData("Jane", "Smith");
            contact.Nickname = "TestUser";
            contact.Title = "QA";
            contact.Company = "Some Company";
            contact.Address = "N2B 4E3";
            contact.Home = "5197311000";
            contact.Email = "test@gmail.com";
            contact.Bday = "13";
            contact.Bmonth = "March";
            contact.Byear = "2000";

            if (!app.Contacts.VerifyContactExists())
            {
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.SelectContact();
            app.Contacts.Delete();
            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);
        }

    }
}
