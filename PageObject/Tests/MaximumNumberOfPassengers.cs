using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace WebDriver
{
    [TestFixture]
    public class MaximumNumberOfPassengers
    {
        private HomePage homePage;
        private const string ErrorMessage = "The maximum number of passengers, excluding infants, that can be selected is 9 for domestic flights, 7 for international flights, and 5 for award tickets.";

        [Test]
        public void OneInfantOnOneAdult()
        {
            OpenHomePage();
            AddAdult();
            AssertErrorsVisible();
        }
        private void OpenHomePage()
        {
            var homePage = new HomePage(new ChromeDriver());
            homePage.OpenHomePage();
        }

        public void AddAdult()
        {
            homePage.ClkickAddPassengers();
            homePage.PlusAdult(8);
            homePage.ClickSearch();
        }

        public void AssertErrorsVisible()
        {
            var messageText = homePage.GetErrorsMessages().Text;
            Assert.AreEqual(ErrorMessage, messageText);
        }
    }
}
