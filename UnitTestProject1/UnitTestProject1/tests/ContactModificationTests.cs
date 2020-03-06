using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {

    [Test]
    public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Smith1", "John");
            newData.Nickname = "TestUser1";
            newData.Title = "QA1";
            newData.Company = "Some Company1";
            newData.Address = "N2B 4E31";
            newData.Home = "51973110001";
            newData.Email = "test@gmail.com1";

            if (!app.Contacts.VerifyContactExists())
            {
                app.Contacts.Create(newData);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];
            app.Contacts.Update(newData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].LastName = newData.LastName;
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }


        }
    }
}
