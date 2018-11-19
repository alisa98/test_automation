using System;
using Xunit;

namespace XUnitTestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.turkishairlines.com/");

            IWebElement element = driver.FindElement(By.XPath("//input[@type='text'])[2]"));
            element.SendKeys("Москва");

            IWebElement buttun_OK = driver.FindElement(By.Id("executeSingleCitySubmit_i"));
            buttun_OK.Click();

            String title = driver.Title;
            Assert.True(title.Contains(expectedTitle), "The information you have entered is incomplete.");

        }
    }
}
