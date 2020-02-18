﻿using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("groupname1");
            group.Header = "groupheader1";
            group.Footer = "groupfooter1";

            if (!app.Groups.VerifyGroupExists())
            {
                app.Groups.Create(group);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Delete();
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
        }
    }
}
