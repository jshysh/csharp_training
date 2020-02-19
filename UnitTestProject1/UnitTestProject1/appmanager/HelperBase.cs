using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
            AreEqual(driver.FindElement(locator).Text, text);
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Click(By locator)
        {
            if (IsElementPresent(locator))
            {
                driver.FindElement(locator).Click();
            }
        }

        public void SelectValue(string contactValue, By locator)
        {
            driver.FindElement(locator).Click();
            new SelectElement(driver.FindElement(locator)).SelectByText(contactValue);
        }

        public void AreEqual(string s1, string s2)
        {
            bool result = s1.Equals(s2);
        }

        public void WaitForElementPresent(int timeOut, By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut)).
                Until(ExpectedConditions.ElementExists((locator)));
        }
           
    }
}