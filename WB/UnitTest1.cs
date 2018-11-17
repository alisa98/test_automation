using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.turkishairlines.com/");

            IWebElement element = driver.FindElement(By.XPath("//input[@type='text'])[2]"));           
            element.SendKeys("Москва");          

            IWebElement buttun_OK = driver.FindElement(By.Id("executeSingleCitySubmit_i"));
            buttun_OK.Click();

            String title = driver.Title;
            Assert.AreEqual(true, title.Contains(expectedTitle), "The information you have entered is incomplete.");
        }
    }
}