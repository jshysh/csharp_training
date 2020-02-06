using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.OpenGroupPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("groupname1");
            group.GroupHeader = "groupheader1";
            group.GroupFooter = "groupfooter1";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            navigator.ReturnToGroupPage();
            loginHelper.Logout();
        }
    }
}
