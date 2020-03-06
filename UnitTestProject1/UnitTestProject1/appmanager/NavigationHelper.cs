using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "addressbook/" && IsElementPresent(By.Name("searchstring")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void ClickHomePage()
        {
            WaitForElementPresent(2, By.XPath("//a[.='home']"));
            Click(By.XPath("//a[.='home']"));
        }

        public void OpenGroupPage()
        {
            if (driver.Url == baseURL + "addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
