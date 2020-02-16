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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
             : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.OpenGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(GroupData group)
        {
            manager.Navigator.OpenGroupPage();
            InitGroupUpdate();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Delete()
        {
            manager.Navigator.OpenGroupPage();
            SelectGroup();
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            Click(By.Name("new"));
            IsElementPresent(By.Name("group_name"));
            return this;
        }

        public GroupHelper InitGroupUpdate()
        {
            SelectGroup();
            Click(By.Name("edit"));
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            Click(By.Name("submit"));
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            Click(By.Name("update"));
            return this;
        }

        public GroupHelper SelectGroup()
        {
            Click(By.Name("selected[]"));
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            Click(By.Name("delete"));
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            Click(By.LinkText("group page"));
            return this;
        }
    }
}
