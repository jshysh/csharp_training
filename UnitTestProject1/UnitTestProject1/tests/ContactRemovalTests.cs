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
    class ContactDeletionTests : TestBase
    {
        [Test]
        public void ContactRemoval()
        {
            app.Contacts.SelectContact();
            app.Contacts.Delete();
            app.Navigator.OpenHomePage();

        }

    }
}
