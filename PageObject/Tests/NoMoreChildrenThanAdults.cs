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
    public class NoMoreChildrenThanAdults
    {
        private HomePage homePage;
        private const string ErrorMessage = "All infant passengers must be accompanied by at least one adult for reservations made online (website/mobile applications).";

        [Test]
        public void NoMoreChildrenThanAdults()
        {
            OpenHomePage();
            AddInfantAddAdult();
            AssertErrorsVisible();
        }
        private void OpenHomePage()
        {
            var homePage = new HomePage(new ChromeDriver());
            homePage.OpenHomePage();
        }

        public void AddInfantAddAdult()
        {
            homePage.ClkickAddPassengers();
            homePage.PlusInfant(4);
            homePage.PlusAdult(2);
            homePage.ClickSearch();
        }

        public void AssertErrorsVisible()
        {
            var messageText = homePage.GetErrorsMessages().Text;
            Assert.AreEqual(ErrorMessage, messageText);
        }
    }
}
