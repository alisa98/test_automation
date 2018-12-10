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
    public class NoMmoreThan6FlightsCanBeAdded
    {
        private HomePage homePage;
        
        [Test]
        public void OneInfantOnOneAdult()
        {
            OpenHomePage();
            MultiCity();
            AddRoute();
            AssertErrorsVisible();
        }

        private void OpenHomePage()
        {
            var homePage = new HomePage(new ChromeDriver());
            homePage.OpenHomePage();
        }

        private void MultiCity()
        {
            homePage.MultiCity();         
        }

        private void AddRoute()
        {
            homePage.AddRoute(4);
        }

        private bool IsElementPresent()
        {
          return homePage.FindElement(addRoute).Count()>0;
        }



        public void AssertErrorsVisible()
        {
            Assert.IsFalse(IsElementPresent());
        }
    }
}
