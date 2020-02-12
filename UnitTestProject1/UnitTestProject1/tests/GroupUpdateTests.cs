using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupUpdateTests : TestBase
    {

        [Test]
        public void GroupUpdateTest()
        {
            GroupData group = new GroupData("Updated groupname1");
            group.GroupHeader = "groupheader1";
            group.GroupFooter = "groupfooter1";

            app.Groups.Update(group);
        }

    }
}
