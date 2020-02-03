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
using addressbook_web_tests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
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
            FillContactForm(contact);
            SubmitContactCreation();
            OpenHomePage();
        }
    }
 }

