using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QCloudAPIHelper.Tests
{
    [TestClass]
    public class BaseTest
    {
        public static QCloudHelper qcloud = new QCloudHelper("AKIDDG8yiF8HIuXO9hrYEgpobEgM1jObGVDh", "p8NBvZ1NUQafZ7m5vu1ELQJAxc1FQpV0");

        [TestMethod]
        public void UserInfoTest()
        {
            var returnJson1 = qcloud.RequestAPiDynamicAsync("ListQueue", null, "cmq-queue-sh.api.qcloud.com", "sh").Result;
            System.Console.WriteLine();
        }
    }
}