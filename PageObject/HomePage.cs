using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AirlinesTestingApp
{
    public class HomePage
    {
        private  IWebDriver driver;

        private const string url = "https://www.turkishairlines.com/";

        [FindsBy(How = How.ClassName, Using = "input.input-block-level.form-control")]
        public IWebElement departure { get; set; }

        [FindsBy(How = How.ClassName, Using = ".open > .dropdown-menu .input-block-level")]
        public IWebElement arrival { get; set; }

        By buttonCalendar = By.ClassName(".active > .opt");
        public IWebElement buttonCalendar { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'30')]")]
        public IWebElement inpuDate { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[contains(text(),'ОК')])[2]")]
        public IWebElement buttonOK { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Поиск')]")]
        public IWebElement buttonSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Премиальный билет')])[2])]")]
        public IWebElement awardTicket { get; set; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;


            //if (!"Login".Equals(driver.getTitle()))
            //{
            //    throw new IllegalStateException("This is not the login page");
            //}
        }

        public HomePage GoToHomePage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(url);
            return new HomePage(driver);
        }
        public void SelectDeparure()
        {
            driver.FindElement(departure).Click();
        }
        public void SelectArrival()
        {
            driver.FindElement(arrival).Click();
        }
        public void SelectButtonCalendar()
        {
            driver.FindElement(buttonCalendar).Click();
        }
        
        public void SelectButtonOK()
        {
            driver.FindElement(buttonOK).Click();
        }
        public void SelectSearch()
        {
            driver.FindElement(buttonSearch).Click();
        }

        public void SelectAwardTicket()
        {
            driver.FindElement(awardTicket).Click();
        }     
    }
}