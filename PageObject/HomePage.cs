using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AirlinesTestingApp.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private const string url = "https://www.turkishairlines.com/";

        By clickAddPassenger = By.CssSelector("span.cabin-view-type");
        By plusBaby = By.Xpath("(//span[@name='upperCount'])[2]");
        By minusAdult = By.CssSelector("span[name='lowerCount']");
        By clickSearch = By.Xpath("//a[contains(text(),'Search')]");
        By errorsMessages = By.ClassName("messages");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ClkickAddPassengers()
        {
            driver.FindElement(clickAddPassenger).Click();
        }

        public void PlusBaby()
        {
            driver.FindElement(plusBaby).Click();
        }

        public void MinusAdult()
        {
            driver.FindElement(minusAdult).Click();
        }

        public void ClickSearch()
        {
            driver.FindElement(clickSearch).Click();
        }

        public IWebElement GetErrorsMessages()
        {
            return driver.FindElement(errorsMessages);
        }
    }
}
