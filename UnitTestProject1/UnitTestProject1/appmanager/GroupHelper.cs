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

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.OpenGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });                   
                }
            }
            return new List<GroupData>(groupCache);
        }

        public GroupHelper Modify(GroupData group)
        {
            manager.Navigator.OpenGroupPage();
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

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
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
            groupCache = null;
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            Click(By.Name("update"));
            groupCache = null;
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
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            Click(By.LinkText("group page"));
            return this;
        }

        public bool VerifyGroupExists()
        {
            manager.Navigator.OpenGroupPage();
            if (IsElementPresent(By.Name("selected[]")))
            {
              return true;
            } else return false;
        }
    }
}
