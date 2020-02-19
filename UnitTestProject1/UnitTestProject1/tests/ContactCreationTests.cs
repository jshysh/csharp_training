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
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Smith", "Jane");
            contact.Nickname = "TestUser";
            contact.Title = "QA";
            contact.Company = "Some Company";
            contact.Address = "N2B 4E3";
            contact.Home = "5197311000";
            contact.Email = "test@gmail.com";
            contact.Bday = "13";
            contact.Bmonth = "March";
            contact.Byear = "2000";
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
 }

