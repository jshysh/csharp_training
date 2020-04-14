using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : ContactTestBase
    {

    [Test]
    public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Smith1", "John")
            {
                Address = "N2B 2L6",
                Work = "519721721",
                Home = "519721721",
                Mobile = "519721721",
                Email = "jane@gmail.com",
                Email2 = "jane@gmail.com",
                Email3 = "jane@gmail.com"
            };
            app.Contacts.VerifyContactExists();
            
            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeModified = oldContacts[0];

            app.Contacts.Modify(toBeModified, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].LastName = newData.LastName;
            oldContacts[0].FirstName = newData.FirstName;

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }
        }
    }
}
