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
using System.IO;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    Address = GenerateRandomString(30),
                    Work = GenerateRandomString(30),
                    Home = GenerateRandomString(30),
                    Mobile = GenerateRandomString(30),
                    Email = GenerateRandomString(30),
                    Email2 = GenerateRandomString(30),
                    Email3 = GenerateRandomString(30)
                });
            }

            return contact;
        }

        public static IEnumerable<ContactData> RandomContactDataFromFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");

            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1]){
                    Address = parts[2],
                    Work = parts[3],
                    Home = parts[4],
                    Mobile = parts[5],
                    Email = parts[6],
                    Email2 = parts[7],
                    Email3 = parts[8]
                });
            }
            return contacts;
        }

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Smith", "Jane")
            {
                Address = "N2B 2L6",
                Work = "519721721",
                Home = "519721721",
                Mobile = "519721721",
                Email = "jane@gmail.com",
                Email2 = "jane@gmail.com",
                Email3 = "jane@gmail.com"
            };

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }

        /*[Test, TestCaseSource("RandomContactDataFromFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
        */
    }
 }

