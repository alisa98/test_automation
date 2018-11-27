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
    public class Test
    {
        private HomePage homePage;
        private const string errorMessage = "The information you have entered is incomplete.";

        [Test]

        public void OneBabyOnOneAdult()
        {
            OpenHomePage();
            AddBabyAndMinusAdult();
            AssertErrorsVisible();
        }    

        private void AddBabyAndMinusAdult()
        {
            var homePage = new HomePage(new ChromeDriver());
            homePage.OpenHomePage();

            homePage.AddPassengers();
            homePage.PlusBaby();
            homePage.MinusAdult();
        }

        private void AssertErrorsVisible()
        {
            var messageText = homePage.GetErrorsMessages().Text;
            Assert.AreEqual(errorMessage, messageText);
        }
    }
}
