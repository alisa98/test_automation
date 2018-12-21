package by.bsu.turkishairlines.index;

import java.time.LocalDate;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.testng.Assert;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Test;

import by.bsu.turkishairlines.page.IndexPage;

public class TurkishAirlinesTest {
    private WebDriver driver;

    @Test
    public void ableToHideReturnDateCalendarAfterOneWayChoice() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.pickOneWayTicketOption();
        indexPage.setDestination("MZR", "Mazar-i-Sharif Airport");
        indexPage.openCalendar();
        indexPage.pickDepartureDate(LocalDate.now());
        Assert.assertTrue(indexPage.isReturnCalendarVisible());
    }

    @Test
    public void preventsSameFromAndToPlaces() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.setDestination("MSQ", "Minsk National Airport");
        indexPage.openCalendar();
        indexPage.pickFlexibleDates();
        indexPage.submitForm();
        Assert.assertTrue(indexPage.isSameDepartureAndArrivalPlaceErrorVisible());
    }

    @Test
    public void preventsInfantsWithoutAdults() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.openPasangersChoice();
        indexPage.addInfants(1);
        indexPage.openPasangersChoice();
        indexPage.removeAdults(1);
        Assert.assertTrue(indexPage.isWarningVisible());
    }

    @Test
    public void preventsZeroPassangersBooking() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.openPasangersChoice();
        indexPage.removeAdults(1);
        Assert.assertTrue(indexPage.isWarningVisible());
    }

    @Test
    public void warnAbounAdultPresenceOnChildTravel() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.openPasangersChoice();
        indexPage.removeAdults(1);
        indexPage.addChilds(1);
        Assert.assertTrue(indexPage.isWarningVisible());
    }

    @Test
    public void preventMoreThanOneInfantPerAdult() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.openPasangersChoice();
        indexPage.addInfants(2);
        Assert.assertTrue(indexPage.isWarningVisible());
    }

    @Test
    public void preventBookingOverMaxQuantityLimit() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.openPasangersChoice();
        indexPage.addAdults(8);
        Assert.assertTrue(indexPage.isWarningVisible());
    }

    @Test
    public void allowsToPickMultipleCitiesAsDestinations() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.pickMultipleCityOption();
        Assert.assertTrue(indexPage.isMultipleCityInputVisible());
    }

    @Test
    public void asksForAccountOnBonusMilesUseRequest() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.pickToUseBonusMiles();
        Assert.assertTrue(indexPage.isAsksForAccount());
    }

    @Test
    public void ableToSeparateChildrenFromAdults() {
        IndexPage indexPage = new IndexPage(driver);
        indexPage.openPasangersChoice();
        indexPage.removeAdults(1);
        indexPage.openPasangersChoice();
        indexPage.addChilds(1);
        indexPage.addInfants(1);
        Assert.assertTrue(indexPage.isWarningVisible());
    }

    @BeforeClass
    public void setupTest() {
        System.setProperty("webdriver.chrome.driver", "src/test/resources/chromedriver.exe");
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