using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests

{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Search(string s)
        {
            manager.Navigator.ClickHomePage();
            Type(By.Name("searchstring"), s);

            return this;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.ClickHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(lastName, firstName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.ClickHomePage();
            InitContactEdit(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");


            return new ContactData(lastName, firstName)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3

            };
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.ClickHomePage();
            OpenContactDetails(index);

            string allDetails = driver.FindElement(By.Id("content")).Text;
            return new ContactData("", "")
            {
                AllDetails = allDetails
            };
        }


        public ContactHelper Update(ContactData contact, int index)
        {
            contactCache = null;
            InitContactEdit(index);
            FillContactForm(contact);
            SubmitContactModification(0);
            return this;
        }

        public ContactHelper Delete(int index)
        {
            SelectContact(index);
            Click(By.XPath("//input[@value='Delete']"));
            driver.SwitchTo().Alert().Accept();
            manager.Navigator.ClickHomePage();
            contactCache = null;
            return this;
        }

        public ContactHelper Delete(ContactData contact)
        {
            SelectContact(contact.Id);
            Click(By.XPath("//input[@value='Delete']"));
            driver.SwitchTo().Alert().Accept();
            manager.Navigator.ClickHomePage();
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.ClickHomePage();

                //get all lines from Contacts
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    string lastName = element.FindElement(By.XPath("./td[2]")).Text;
                    string firstName = element.FindElement(By.XPath("./td[3]")).Text;
                    string id = element.FindElement(By.Name("selected[]")).GetAttribute("value");
                    contactCache.Add(new ContactData(lastName, firstName)
                    {
                        Id = id
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper InitContactEdit(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            IsElementPresent(By.XPath("//h1[contains(text(),'Edit / add address book entry')]"));
            return this;
        }

        public ContactHelper OpenContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            manager.Navigator.OpenHomePage();
            Click(By.Name("selected[]'])[" + (index + 1) + "]"));
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            manager.Navigator.OpenHomePage();
            Click(By.Id(id));
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            Click(By.XPath("(//input[@name='submit'])[2]"));
            IsElementPresent(By.XPath("//div[contains(text(),'Information entered into address book.')]"));
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification(int index)
        {
            Click(By.XPath("//input[@name='update'][" + index + "]"));
            IsElementPresent(By.XPath("//h1[contains(text(),'Edit / add address book entry')]"));
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            Click(By.LinkText("add new"));
            IsElementPresent(By.XPath("//h1[contains(text(),'Edit / add address book entry')]"));
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            return this;
        }

        public ContactHelper VerifyContactExists()
        {
            manager.Navigator.ClickHomePage();
            if (!IsElementPresent(By.Name("entry")))
            {
                ContactData contact = new ContactData("Vasilisa", "Smirnova");
                Create(contact);
            }
            return this;
        }

        public int GetContactCount()
        {
            manager.Navigator.ClickHomePage();
            return driver.FindElements(By.Name("entry")).Count;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.ClickHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;

            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}