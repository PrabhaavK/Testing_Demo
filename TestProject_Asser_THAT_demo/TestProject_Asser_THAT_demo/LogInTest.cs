using System;

namespace TestProject_Asser_THAT_demo
{
    public class Test
    {
        LogInClass logInobj;
        [SetUp]
        public void SetUp()
        {
            logInobj = new LogInClass();
        }
        [TearDown]
        public void Remove()
        {
            logInobj = null;
        }

        [Test]
        public void LoginTestForEmpty()
        {
            string? expected = " user or password is null";
            string? actual = null;
            actual = logInobj.Login("", "");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoginTestForCorrectLogIn()
        {
            string expected = "Welcome Admin";
            var actual = logInobj.Login("Admin","admin");

            Assert.That(actual, Is.EqualTo("Welcome admin"));
        }

        [Test]
        public void LogoutTestForInCorrectLogin()
        {
            string expected = "Invalid  User or Password";
            string actual = logInobj.Login("admin","admin");

            Assert.AreEqual(expected, actual);
        }
        
    }
}
