﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AirlinesTestingApp.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private const string url = "https://www.turkishairlines.com/";

        By clickAddPassenger = By.Xpath("//span[@id='personCounter']");
        By plusChild = By.Xpath("(//span[@name='upperCount'])[2]");
        By plusInfant= By.Xpath("(//span[@name='upperCount'])[3]");
        By plusAdult = By.Xpath("//span[@name='upperCount']");
        By minusAdult = By.Xpath("//span[@name='lowerCount']");
        By clickSearch = By.Xpath("//a[contains(text(),'Search')]");
        By errorsMessages = By.ClassName("messages");
        By inputArrival = By.Xpath("//input[@type='text'])[2]"); 
        By awardTicket = By.Xpath("//a[contains(text(),'Award ticket - Buy a ticket with Miles')]");
        By multiCity = By.Xpath(" //a[contains(text(),'Multi-city')]");




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

        public void PlusChild()
        {
            driver.FindElement(plusChild).Click();
        }

        public void PlusInfant(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                driver.FindElement(plusInfant).Click();
            }
        }

        public void MinusAdult()
        {
            driver.FindElement(minusAdult).Click();
        }

        public void PlusAdult(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                driver.FindElement(plusAdult).Click();
            }
        }

        public void ClickSearch()
        {
            driver.FindElement(clickSearch).Click();
        }

        public void InputArrival()
        {
            driver.FindElement(inputArrival).Click();          
        }

        public void AwardTicket()
        {
            driver.FindElement(awardTicket).Click();
        }

        public void MultiCity()
        {
            driver.FindElement(multiCity).Click();
        }


        public IWebElement GetErrorsMessages()
        {
            return driver.FindElement(errorsMessages);
        }
    }
}
