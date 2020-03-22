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
    public class SearchTests : AuthTestBase
    {

        [Test]
        public void TestSearch()
        {
            app.Contacts.Search("t");
            Assert.AreEqual(app.Contacts.GetNumberOfSearchResults(), app.Contacts.GetContactCount());
        }
    }
}
