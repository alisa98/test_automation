package by.bsu.flyuia.page;

import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

public class IndexPage {
    private WebDriver driver;

    @FindBy(xpath = "//*[@id='promo-sub']/div/div/div[1]/span[@class='close']")
    private WebElement closeDialogButton;

    @FindBy(id = "SEARCH_WIDGET_FORM_BUTTONS_ONE_WAY")
    private WebElement oneWayRadio;

    @FindBy(id = "SEARCH_WIDGET_FORM_BUTTONS_MULTICITY")
    private WebElement multiCityOption;

    @FindBy(id = "mat-input-0")
    private WebElement fromInput;

    @FindBy(id = "mat-input-1")
    private WebElement toInput;

    @FindBy(xpath = "//span[text()='Dates']")
    private WebElement calendarButton;

    @FindBy(id = "errorModalContainer")
    private WebElement sameDepartureAndArrivalPlaceError;

    @FindBy(id = "SEARCH_WIDGET_FORM_BUTTONS_SEARCH_FLIGHTS")
    private WebElement submitButton;

    @FindBy(xpath = "//div[@id='1']/div/sw-root/sw-layout/sw-search-flights/div[2]/form/div[4]/div[1]/sw-form-control-passengers/div[1]")
    private WebElement passangersChoice;

    @FindBy(xpath = "/html/body/div[10]/div/div/div[2]/div/div[2]/div[1]/button[1]")
    private WebElement removeAdultButton;

    @FindBy(xpath = "//a[starts-with(@aria-label,'Increase Adult number to')]")
    private WebElement addAdultButton;

    @FindBy(xpath = "/html/body/div[10]/div/div/div[2]/div/div[2]/div[3]/button[2]")
    private WebElement addInfantButton;

    @FindBy(xpath = "//a[starts-with(@aria-label,'Increase Child number to')]")
    private WebElement addChildButton;

    @FindBy(id = "multiCityContainer")
    private WebElement multipleCityInput;

    @FindBy(xpath = "div[text()='Children cannot trevel without adults']")
    private WebElement warning;

    @FindBy(xpath = "//*[@id='signinModal']/div/div/div/form/div/div[1]/div[1]")
    private WebElement signUpForm;

    @FindBy(xpath = "//*[@id='start-screen']/div[1]/ul/li[2]/a")
    private WebElement mealChoice;

    @FindBy(xpath = "//*[@id='start-screen']/div[1]/ul/li[3]/a")
    private WebElement handlingChoice;

    @FindBy(xpath = "//*[@id='start-screen']/div[1]/ul/li[4]/a")
    private WebElement carRentOption;

    @FindBy(xpath = "//*[@id='start-screen']/div[1]/ul/li[5]/a")
    private WebElement insuranceOption;

    @FindBy(xpath = "//*[@id=\"start-screen\"]/div[1]/ul/li[6]/a")
    private WebElement hotelOption;

    public IndexPage(WebDriver driver) {
        this.driver = driver;
        driver.get("https://www.flyuia.com/ua/en/home");
        PageFactory.initElements(driver, this);
    }

    public void closeDialog() {
        this.closeDialogButton.click();
    }

    public void submitForm() {
        submitButton.click();
    }

    public boolean isSubmitButtonVisible() {
        return submitButton.isDisplayed();
    }

    public void pickOneWayTicketOption() {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(oneWayRadio));
        oneWayRadio.click();
    }

    public void setFrom(String airport) {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(fromInput));
        fromInput.click();
        fromInput.sendKeys(airport);
        fromInput.sendKeys(Keys.ENTER);
    }

    @FindBy(xpath = "//*[@id=\"cdk-overlay-8\"]/div/div[2]/sw-form-control-select/sw-form-control-container/div")
    private WebElement selectACountryButton;

    public void selectCountry() {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(selectACountryButton));
        selectACountryButton.click();
    }

    @FindBy(xpath = "//*[@id=\"1\"]/div/sw-root/sw-layout/sw-search-flights/div[2]/form/div[1]/sw-form-control-suggester/div/i")
    private WebElement fromInputButton;

    public void openFromChoice() {
        fromInputButton.click();
    }

    public void setTo(String airport) {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(toInput));
        toInput.click();
        toInput.sendKeys(airport);
        toInput.sendKeys(Keys.ENTER);
    }

    public void openCalendar() {
        calendarButton.click();
    }

    public boolean isSameDepartureAndArrivalPlaceErrorVisible() {
        return sameDepartureAndArrivalPlaceError.isDisplayed();
    }

    public boolean isReturnCalendarVisible() {
        return driver.findElements(By.id("mat-input-5")).size() == 0;
    }

    public void removeAdults(int number) {
        for (int i = 0; i < number; i++) {
            removeAdultButton.click();
        }
    }

    public void addAdults(int number) {
        for (int i = 0; i < number; i++) {
            new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(addAdultButton));
            addAdultButton.click();
        }
    }

    public void addInfants(int number) {
        for (int i = 0; i < number; i++) {
            new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(addInfantButton));
            addInfantButton.click();
        }
    }

    public void addChilds(int number) {
        for (int i = 0; i < number; i++) {
            new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(addChildButton));
            addChildButton.click();
        }
    }

    public void openPasangersChoice() {
        new WebDriverWait(driver, 5).until(ExpectedConditions.elementToBeClickable(passangersChoice));
        passangersChoice.click();
    }

    public boolean isWarningVisible() {
        if (driver.findElements(By.xpath("//div[text()='Children cannot trevel without adults']")).size() == 0) {
            openPasangersChoice();
        }
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(warning));
        return warning.isDisplayed();
    }

    public boolean isMultipleCityInputVisible() {
        new WebDriverWait(driver, 5).until(ExpectedConditions.visibilityOf(multipleCityInput));
        return multipleCityInput.isDisplayed();
    }

    public void pickMealOption() {
        mealChoice.click();
    }

    public void pickHotelOption() {
        hotelOption.click();
    }

    public void pickHandlingOption() {
        handlingChoice.click();
    }

    public void pickCarRentOption() {
        carRentOption.click();
    }

    public void pickInsuranceOption() {
        insuranceOption.click();
    }

    public void pickMultipleCityOption() {
        multiCityOption.click();
    }

    public boolean isDestinationEmpty() {
        return toInput.getText().isEmpty();
    }

    public boolean isSubmitButtonActive() {
        return submitButton.getAttribute("class").equals("active");
    }
}
