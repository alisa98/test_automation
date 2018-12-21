package by.bsu.turkishairlines.page;

import java.time.LocalDate;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

public class IndexPage {
    private WebDriver driver;

    @FindBy(xpath = "//a[@aria-label='One way']")
    private WebElement oneWayRadio;

    @FindBy(xpath = "//a[@data-type='multi']")
    private WebElement multiCityRadio;

    @FindBy(xpath = "//button[@data-id='to_select']")
    private WebElement destinationButton;

    @FindBy(xpath = "//*[@id='destinationSelector']/div/div/div/div/input")
    private WebElement destinationInput;

    @FindBy(xpath = "//span[text()='Dates']")
    private WebElement calendarButton;

    @FindBy(xpath = "//*[@id='singleCityCalendarHolder']/div[1]/div/div/div[1]/div/div[1]/label/span[1]")
    private WebElement flexibleDatesCheckBox;

    @FindBy(id = "errorModalContainer")
    private WebElement sameDepartureAndArrivalPlaceError;

    @FindBy(name = "submit")
    private WebElement submitButton;

    @FindBy(id = "personCounter")
    private WebElement personChoice;

    @FindBy(xpath = "//a[starts-with(@aria-label,'Decrease Adult number to')]")
    private WebElement removeAdultButton;

    @FindBy(xpath = "//a[starts-with(@aria-label,'Increase Adult number to')]")
    private WebElement addAdultButton;

    @FindBy(xpath = "//a[starts-with(@aria-label,'Increase Infant number to')]")
    private WebElement addInfantButton;

    @FindBy(xpath = "//a[starts-with(@aria-label,'Increase Child number to')]")
    private WebElement addChildButton;

    @FindBy(id = "multiCityContainer")
    private WebElement multipleCityInput;

    @FindBy(xpath = "//*[@id='choosePerson']/div/div/div/div[3]/div[1]/div/div/p")
    private WebElement warning;

    @FindBy(css = "#bookerAvailabilityTab > div > div > div.col-xs-12.booker-menu-wrapper > div > a.white.mini-booker-link.award-link.pull-right-sm")
    private WebElement bonusMilesButton;

    @FindBy(xpath = "//*[@id='signinModal']/div/div/div/form/div/div[1]/div[1]")
    private WebElement signUpForm;

    public IndexPage(WebDriver driver) {
        this.driver = driver;
        driver.get("https://www.turkishairlines.com/en-us/flights/booking/");
        PageFactory.initElements(driver, this);
    }

    public void submitForm() {
        submitButton.click();
    }

    public void pickOneWayTicketOption() {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(oneWayRadio));
        oneWayRadio.click();
    }

    public void pickFlexibleDates() {
        flexibleDatesCheckBox.click();
    }

    public void setDestination(String code, String airport) {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(destinationButton));
        destinationButton.click();
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(destinationInput));
        destinationInput.sendKeys(code);
        new WebDriverWait(driver, 5).until(ExpectedConditions.elementToBeClickable(
                driver.findElement(By.xpath("//*[@id='destinationSelector']/div/div/div/ul/li[2]/a"))));
        driver.findElement(By.xpath("//*[@id='destinationSelector']/div/div/div/ul/li[2]/a")).click();
    }

    public void openCalendar() {
        calendarButton.click();
    }

    public String getDestination() {
        return destinationInput.getText();
    }

    public boolean isSameDepartureAndArrivalPlaceErrorVisible() {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(sameDepartureAndArrivalPlaceError));
        return sameDepartureAndArrivalPlaceError.isDisplayed();
    }

    public void pickDepartureDate(LocalDate date) {
        driver.findElement(By.xpath("//td[@data-month='" + (date.getMonthValue() - 1) + "' and @data-year='"
                + date.getYear() + "']/a[text()='" + date.getDayOfMonth() + "']"));
    }

    public boolean isReturnCalendarVisible() {
        return driver.findElements(By.id("selectFlightDate02")).size() == 0;
    }

    public void removeAdults(int number) {
        for (int i = 0; i < number; i++) {
            removeAdultButton.click();
            driver.manage().timeouts().implicitlyWait(1, TimeUnit.SECONDS);
        }
    }

    public void addAdults(int number) {
        for (int i = 0; i < number; i++) {
            if (!personChoice.isDisplayed()) {
                openPasangersChoice();
            }
            addAdultButton.click();
            driver.manage().timeouts().implicitlyWait(1, TimeUnit.SECONDS);
        }
    }

    public void addInfants(int number) {
        for (int i = 0; i < number; i++) {
            addInfantButton.click();
            driver.manage().timeouts().implicitlyWait(1, TimeUnit.SECONDS);
        }
    }

    public void addChilds(int number) {
        for (int i = 0; i < number; i++) {
            addChildButton.click();
            driver.manage().timeouts().implicitlyWait(1, TimeUnit.SECONDS);
        }
    }

    public void openPasangersChoice() {
        new WebDriverWait(driver, 5).until(ExpectedConditions.elementToBeClickable(personChoice));
        personChoice.click();
    }

    public boolean isWarningVisible() {
        if (driver.findElements(By.xpath("//*[@id='choosePerson']/div")).size() == 0) {
            openPasangersChoice();
        }
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(warning));
        return warning.isDisplayed();
    }

    public boolean isMultipleCityInputVisible() {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(multipleCityInput));
        return multipleCityInput.isDisplayed();
    }

    public void pickMultipleCityOption() {
        multiCityRadio.click();
    }

    public void pickToUseBonusMiles() {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(bonusMilesButton));
        bonusMilesButton.click();
    }

    public boolean isAsksForAccount() {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(signUpForm));
        return signUpForm.isDisplayed();
    }
}
