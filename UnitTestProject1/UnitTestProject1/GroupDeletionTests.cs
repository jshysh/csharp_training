using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.OpenGroupPage();
            groupHelper.SelectGroup();
            groupHelper.RemoveGroup();
            navigator.ReturnToGroupPage();
            loginHelper.Logout();
        }

 
    }
}
