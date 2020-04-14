﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupModificationTests : GroupTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("groupname11");
            newData.Header = "groupheader1";
            newData.Footer = "groupfooter1";

            app.Groups.VerifyGroupExists();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
            app.Groups.Modify(newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
