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
    public class CheckIn
    {
        private HomePage homePage;
        private const string ErrorMessage = "Your eTicket number is incomplete or incorrect. Please enter the 13-digit numerical code which appears in the “Ticket number” box on your ticket. If you do not know your eTicket number, you can leave this field blank and enter your reservation code (PNR).";

        [Test]
        public void OneInfantOnOneAdult()
        {
            OpenHomePage();
            CheckIn();
            TicketNumber();    
            AssertErrorsVisible();
        }
        private void OpenHomePage()
        {
            var homePage = new HomePage(new ChromeDriver());
            homePage.OpenHomePage();
        }
   
        private void TicketNumber()
        {
            homePage.TicketNumber();
            homePage.SendKeys("123456789");
        }       

        public void AssertErrorsVisible()
        {
            var messageText = homePage.GetErrorsMessages().Text;
            Assert.AreEqual(ErrorMessage, messageText);
        }
    }
}
