using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace XUnitTestProject2
{
    public class Search
    {
        [Fact]
        public void SearchWillNotBeRealizedIfThePointOfArrivalIsNotEntered()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.turkishairlines.com/");
            IWebElement element = driver.FindElement(By.XPath("//input[@type='text'])[2]"));
            element.SendKeys("Москва");
            IWebElement buttun_OK = driver.FindElement(By.Id("executeSingleCitySubmit_i"));
            buttun_OK.Click();
            Assert.True(driver.Title.Contains("The information you have entered is incomplete."));
        }
    }
}
