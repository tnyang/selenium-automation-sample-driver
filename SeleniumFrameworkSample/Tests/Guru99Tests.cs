using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using SeleniumFrameworkV2Sample.PageObjects;
using System;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class Guru99Tests : WebDriverTestBase
    {
        String userid = "mngr98273";
        String password = "aqytysA";

        [Test]
        [Category("GURU991")]
        public void Guru99Test1()
        {
            Guru99LoginPage guru99login = new Guru99LoginPage();
            guru99login.OpenPage("/V4/");
            Guru99HomePage guruHomePage = guru99login.loginToGuru99(userid, password);

            //verify login success
            String homeText = guruHomePage.getHomePageDashboardUserName();
            Console.WriteLine("homeText to verify: " + homeText);

            Assert.AreEqual(homeText.Equals("Manger Id : " + userid), true, "Current text: " + homeText);
        }

        [Test]
        [Category("GURU99")]
        public void Guru99Test2()
        {
            Guru99LoginPage guru99login = new Guru99LoginPage();
            guru99login.OpenPage("/V4/");
            Guru99HomePage guruHomePage = guru99login.loginToGuru99(userid, password);

            //verify login success
            String homeText = guruHomePage.getHomePageDashboardUserName();
            Console.WriteLine("homeText to verify: " + homeText);

            Assert.AreEqual(homeText.Equals("Manger Id : " + userid), true, "Current text: " + homeText);
        }

        [Test]
        [Category("GURU99")]
        public void Guru99Test3()
        {
            Guru99LoginPage guru99login = new Guru99LoginPage();
            guru99login.OpenPage("/V4/");
            Guru99HomePage guruHomePage = guru99login.loginToGuru99(userid, password);

            //verify login success
            String homeText = guruHomePage.getHomePageDashboardUserName();
            Console.WriteLine("homeText to verify: " + homeText);

            Assert.AreEqual(homeText.Equals("Manger Id : " + userid), true, "Current text: " + homeText);
        }

        [Test]
        [Category("GURU99")]
        public void Guru99Test4()
        {
            Guru99LoginPage guru99login = new Guru99LoginPage();
            guru99login.OpenPage("/V4/");
            Guru99HomePage guruHomePage = guru99login.loginToGuru99(userid, password);

            //verify login success
            String homeText = guruHomePage.getHomePageDashboardUserName();
            Console.WriteLine("homeText to verify: " + homeText);

            Assert.AreEqual(homeText.Equals("Manger Id : " + userid), true, "Current text: " + homeText);
        }

        [Test]
        [Category("GURU99")]
        public void Guru99Test5()
        {
            Guru99LoginPage guru99login = new Guru99LoginPage();
            guru99login.OpenPage("/V4/");
            Guru99HomePage guruHomePage = guru99login.loginToGuru99(userid, password);

            //verify login success
            String homeText = guruHomePage.getHomePageDashboardUserName();
            Console.WriteLine("homeText to verify: " + homeText);

            Assert.AreEqual(homeText.Equals("Manger Id : " + userid), true, "Current text: " + homeText);
        }

        [Test]
        [Category("GURU99")]
        public void Guru99Test6()
        {
            Guru99LoginPage guru99login = new Guru99LoginPage();
            guru99login.OpenPage("/V4/");
            Guru99HomePage guruHomePage = guru99login.loginToGuru99(userid, password);

            //verify login success
            String homeText = guruHomePage.getHomePageDashboardUserName();
            Console.WriteLine("homeText to verify: " + homeText);

            Assert.AreEqual(homeText.Equals("Manger Id : " + userid), true, "Current text: " + homeText);
        }

        [Test]
        [Category("GURU99")]
        public void Guru99Test7()
        {
            Guru99LoginPage guru99login = new Guru99LoginPage();
            guru99login.OpenPage("/V4/");
            Guru99HomePage guruHomePage = guru99login.loginToGuru99(userid, password);

            //verify login success
            String homeText = guruHomePage.getHomePageDashboardUserName();
            Console.WriteLine("homeText to verify: " + homeText);

            Assert.AreEqual(homeText.Equals("Manger Id : " + userid), true, "Current text: " + homeText);
        }

        [Test]
        [Category("GURU99")]
        public void Guru99Test8()
        {
            Guru99LoginPage guru99login = new Guru99LoginPage();
            guru99login.OpenPage("/V4/");
            Guru99HomePage guruHomePage = guru99login.loginToGuru99(userid, password);

            //verify login success
            String homeText = guruHomePage.getHomePageDashboardUserName();
            Console.WriteLine("homeText to verify: " + homeText);

            Assert.AreEqual(homeText.Equals("Manger Id : " + userid), true, "Current text: " + homeText);
        }

        [Test]
        [Category("GURU99")]
        public void Guru99Test9()
        {
            Guru99LoginPage guru99login = new Guru99LoginPage();
            guru99login.OpenPage("/V4/");
            Guru99HomePage guruHomePage = guru99login.loginToGuru99(userid, password);

            //verify login success
            String homeText = guruHomePage.getHomePageDashboardUserName();
            Console.WriteLine("homeText to verify: " + homeText);

            Assert.AreEqual(homeText.Equals("Manger Id : " + userid), true, "Current text: " + homeText);
        }

        [Test]
        [Category("GURU99")]
        public void Guru99Test10()
        {
            Guru99LoginPage guru99login = new Guru99LoginPage();
            guru99login.OpenPage("/V4/");
            Guru99HomePage guruHomePage = guru99login.loginToGuru99(userid, password);

            //verify login success
            String homeText = guruHomePage.getHomePageDashboardUserName();
            Console.WriteLine("homeText to verify: " + homeText);

            Assert.AreEqual(homeText.Equals("Manger Id : " + userid), true, "Current text: " + homeText);
        }


    }
}
