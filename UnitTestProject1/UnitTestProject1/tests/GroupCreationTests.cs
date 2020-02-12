using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("groupname1");
            group.GroupHeader = "groupheader1";
            group.GroupFooter = "groupfooter1";

            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.GroupHeader = "";
            group.GroupFooter = "";

            app.Groups.Create(group);
        }
    }
}
