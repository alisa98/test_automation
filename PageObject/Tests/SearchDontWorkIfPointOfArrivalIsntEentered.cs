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
    public class SearchDontWorkIfPointOfArrivalIsntEentered

    {
        private HomePage homePage;
        private const string ErrorMessage = "The information you have entered is incomplete.";

        [Test]
        private void SearchWithoutArrival()
        {
            OpenHomePage();
            ClickSearch();
            AssertErrorsVisible();
        }
        private void OpenHomePage()
        {
            var homePage = new HomePage(new ChromeDriver());
            homePage.OpenHomePage();
        }

        public void CickSearch()
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