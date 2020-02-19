﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ContactHelper Update(ContactData contact)
        {
            InitContactEdit();
            FillContactForm(contact);
            SubmitContactModification();
            return this;
        }

        
        public ContactHelper Delete()
        {
            Click(By.XPath("//input[@value='Delete']"));
            driver.SwitchTo().Alert().Accept();
            manager.Navigator.ClickHomePage();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            manager.Navigator.ClickHomePage();
            int i = 2;
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> firstNames = driver.FindElements(By.XPath("//*[@id='maintable']/tbody/tr[" + i + "]/td[2]"));
            ICollection<IWebElement> lastNames = driver.FindElements(By.XPath("//*[@id='maintable']/tbody/tr[" + i + "]/td[3]"));
            for (; IsElementPresent(By.XPath("//*[@id='maintable']/tbody/tr[" + i + "]/td[2]")); i++)
            {
                foreach (IWebElement firstName in firstNames)
                {
                    foreach (IWebElement lastName in lastNames)
                    {                       
                        contacts.Add(new ContactData(firstName.Text, lastName.Text));
                    }
                }
            }
            return contacts;
        }

        public ContactHelper InitContactEdit()
        {
            Click(By.XPath("//img[@title='Edit']"));
            IsElementPresent(By.XPath("//h1[contains(text(),'Edit / add address book entry')]"));
            return this;
        }

        public ContactHelper SelectContact()
        {
            manager.Navigator.OpenHomePage();
            Click(By.Name("selected[]"));
            return this;
        }


        public ContactHelper SubmitContactCreation()
        {
            Click(By.XPath("(//input[@name='submit'])[2]"));
            IsElementPresent(By.XPath("//div[contains(text(),'Information entered into address book.')]"));
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            Click(By.XPath("//input[@name='update'][2]"));
            IsElementPresent(By.XPath("//h1[contains(text(),'Edit / add address book entry')]"));
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
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("home"), contact.Home);
            SelectValue(contact.Bday, By.Name("bday"));
            SelectValue(contact.Bmonth, By.Name("bmonth"));
            Type(By.Name("byear"), contact.Byear);
            return this;
        }

        public bool VerifyContactExists()
        {
            manager.Navigator.OpenHomePage();
            if (IsElementPresent(By.Name("selected[]")))
            {
                return true;
            }
            else return false;
        }
    }
}
