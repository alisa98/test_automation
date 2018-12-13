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
    public class MultiCityAllFieldsAreFilled
    {
        private HomePage homePage;
        private const string ErrorMessage = "Please select a date for your flight.";

        [Test]
        public void MultiCityAllFieldsAreFilled()
        {
            OpenHomePage();
            MultiCity();
            InputDeparture();       
            AssertErrorsVisible();
        }
        private void OpenHomePage()
        {
            var homePage = new HomePage(new ChromeDriver());
            homePage.OpenHomePage();
        }
        public void MultiCity()
        {
            homePage.MultiCity();
        }

        private void InputDeparture()
        {
            homePage.InputArrival();
            homePage.SendKeys("Kiev");
            homePage.ClickSearch();
        }      

        public void AssertErrorsVisible()
        {
            var messageText = homePage.GetErrorsMessages().Text;
            Assert.AreEqual(ErrorMessage, messageText);
        }
    }
}
