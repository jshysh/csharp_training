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
                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });      
                }
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i-shift].Trim();
                    }
                }
            }
            return new List<GroupData>(groupCache);
        }

        public GroupHelper Modify(GroupData group, int index)
        {
            manager.Navigator.OpenGroupPage();
            InitGroupUpdate(index);
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(GroupData group)
        {
            manager.Navigator.OpenGroupPage();
            InitGroupUpdate(group.Id);
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Delete(int index)
        {
            manager.Navigator.OpenGroupPage();
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Delete(GroupData group)
        {
            manager.Navigator.OpenGroupPage();
            SelectGroup(group.Id);
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

        public GroupHelper InitGroupUpdate(int index)
        {
            SelectGroup(index);
            Click(By.Name("edit"));
            return this;
        }

        public GroupHelper InitGroupUpdate(String id)
        {
            SelectGroup(id);
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

        public GroupHelper SelectGroup(int index)
        {
            Click(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]"));
            return this;
        }

        public GroupHelper SelectGroup(String id)
        {
            Click(By.XPath("(//input[@name='selected[]' and @value = " + id + "])"));
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
