using System;
using Xunit;

namespace Test
{
    public class Program
    {
        private HomePAge homePage;

        [Fact]
        public void AwardTicketCanOnlyBePurchasedByMemberOfTheMilesSmilesProgramWhoIsLoggedIn()
        {
            IWebDriver driver = new ChromeDriver();
            homePage.GoToHomePage(driver);
            homePage.SelectAwardTicket(driver);
            Assert.True(driver.Title.Contains("Still not part of the Miles&Smiles family?"));
        }   
    }
}