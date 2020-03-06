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
            contactCache = null;
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
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry")); //get all lines from Contacts
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
        contactCache = null;
        return this;
    }

    public ContactHelper SubmitContactModification()
    {
        Click(By.XPath("//input[@name='update'][2]"));
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
        Type(By.Name("nickname"), contact.Nickname);
        Type(By.Name("title"), contact.Title);
        Type(By.Name("company"), contact.Company);
        Type(By.Name("address"), contact.Address);
        Type(By.Name("home"), contact.Home);
        Type(By.Name("email"), contact.Email);
        Type(By.Name("home"), contact.Home);
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

    public int GetContactCount()
    {
        manager.Navigator.ClickHomePage();
        return driver.FindElements(By.XPath("//img[@title='Edit']")).Count;
    }
    }
}
