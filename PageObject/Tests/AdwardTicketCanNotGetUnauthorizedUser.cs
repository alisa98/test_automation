using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObject.Tests
{
    [TestFixture]
    public class AdwardTicketCanNotGetUnauthorizedUser
    {
        private HomePage homePage;
        private const string ErrorMessage = "Sign in";

        [Test]
        public void AdwardTicketCanNotGetUnauthorizedUser()
        {
            OpenHomePage();
            AdwardTicket();
            AssertErrorsVisible();
        }
        private void OpenHomePage()
        {
            var homePage = new HomePage(new ChromeDriver());
            homePage.OpenHomePage();
        }
   
        private void AdwardTicket()
        {
            homePage.AwardTicket();
        }

        public void AssertErrorsVisible()
        {
            var messageText = homePage.GetErrorsMessages().Text;
            Assert.AreEqual(ErrorMessage, messageText);
        }
    }
}
