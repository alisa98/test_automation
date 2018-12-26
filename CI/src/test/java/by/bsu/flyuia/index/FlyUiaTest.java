package by.bsu.flyuia.index;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.testng.Assert;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Test;

import by.bsu.flyuia.page.IndexPage;

public class FlyUiaTest {
    private WebDriver driver;

    @Test
    public void ableToHideReturnDateCalendarAfterOneWayChoice() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.pickOneWayTicketOption();
        Assert.assertTrue(indexPage.isReturnCalendarVisible());
    }

    @Test
    public void preventsInputWithSameFromTo() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.setTo("MINSK (ALL AIRPORTS, MSQ) - BY");
        indexPage.setFrom("MINSK (ALL AIRPORTS, MSQ) - BY");
        Assert.assertTrue(indexPage.isDestinationEmpty());
    }

    @Test
    public void preventsEmptySearch() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.submitForm();
        Assert.assertTrue(indexPage.isSubmitButtonVisible());
    }

    @Test
    public void isAbleToDisplayMultipleDestinationsChoice() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.pickMultipleCityOption();
        Assert.assertEquals(driver.getCurrentUrl(),
                "https://book.flyuia.com/EN/default/multicity/search?flyuiacountrycode=ua&flyuialanguagecode=en&currency=UAH");
    }

    @Test
    public void isAbleToDisplayMealChoice() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.pickMealOption();
        Assert.assertEquals(driver.getCurrentUrl(),
                "https://www.flyuia.com/ua/en/services/pre-order-meal#pre-ordered-meal");
    }

    @Test
    public void isAbleToDisplayHandlingChoice() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.pickHandlingOption();
        Assert.assertEquals(driver.getCurrentUrl(),
                "https://www.flyuia.com/ua/en/information/baggage/checked-and-hand#xbaggage");
    }

    @Test
    public void isAbleToDisplayCarRentChoice() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.pickCarRentOption();
        Assert.assertEquals(driver.getCurrentUrl(), "https://www.flyuia.com/ua/en/services/rent-a-car");
    }

    @Test
    public void isAbleToDisplayInsuranceChoice() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.pickInsuranceOption();
        Assert.assertEquals(driver.getCurrentUrl(), "https://www.flyuia.com/ua/en/services/travel-insurance");
    }

    @Test
    public void isAbleToDisplayHotelChoice() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.pickHotelOption();
        Assert.assertEquals(driver.getCurrentUrl(), "https://www.flyuia.com/ua/en/services/book-a-hotel");
    }

    @Test
    public void preventsDirectInput() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.setTo("MINSK (ALL AIRPORTS, MSQ) - BY");
        indexPage.setFrom("YEREVAN (ALL AIRPORTS, EVN) - AM");
        Assert.assertTrue(indexPage.isDestinationEmpty());
    }

    @BeforeClass
    public void setupTest() {
        System.setProperty("webdriver.chrome.driver", "src/test/resources/chromedriver");
        ChromeOptions options = new ChromeOptions();
        options.addArguments(
                "--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
        options.addArguments("--start-maximized");
        driver = new ChromeDriver(options);
    }

    @AfterClass
    public void teardown() {
        if (driver != null) {
            driver.quit();
        }
    }
}