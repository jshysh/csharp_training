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
    public class ContactInformationTests : ContactTestBase
    {

        [Test]
        public void TestContactInformation()
        {
            app.Contacts.VerifyContactExists();

            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformationDetails()
        {
            app.Contacts.VerifyContactExists();

            ContactData fromDetailsForm = app.Contacts.GetContactInformationFromDetails(0);
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification

            Assert.AreEqual(fromEditForm.AllDetails, fromDetailsForm.AllDetails);
        }
    }
}