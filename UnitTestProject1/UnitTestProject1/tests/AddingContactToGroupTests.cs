﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [SetUp]

        // Common verification
        public void VerifyObjectPresence()
        {
            app.Groups.VerifyGroupExists();
            app.Contacts.VerifyContactExists();
        }

        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];

            app.Contacts.VerifyContactInGroupPresence(group);

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];

            app.Contacts.VerifyContactInGroupAbsence(group);

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = group.GetContacts().First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}