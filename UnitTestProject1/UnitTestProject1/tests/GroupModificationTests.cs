using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("groupname1");
            group.Header = "groupheader1";
            group.Footer = "groupfooter1";
            if (!app.Groups.VerifyGroupExists())
            {

                app.Groups.Create(group);
            }

            app.Groups.Modify(group);
        }

    }
}
