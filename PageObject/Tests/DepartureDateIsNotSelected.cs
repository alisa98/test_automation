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
    public class DepartureDateIsNotSelected
    {
        private HomePage homePage;
        private const string ErrorMessage = "Please select a date for your flight. Unless your flight is round trip, please click “one way”.";

        [Test]
        public void OneInfantOnOneAdult()
        {
            OpenHomePage();
            Inputarrival();
            ClickSearch();
            AssertErrorsVisible();
        }
        private void OpenHomePage()
        {
            var homePage = new HomePage(new ChromeDriver());
            homePage.OpenHomePage();
        }

        private void InputDeparture()
        {
            homePage.InputArrival();
            homePage.SendKeys("Kiev");
        }

        private void ClickSearch()
        {
            homePage.ClickSearch();
        }

        public void AssertErrorsVisible()
        {
            var messageText = homePage.GetErrorsMessages().Text;
            Assert.AreEqual(ErrorMessage, messageText);
        }
    }
}
