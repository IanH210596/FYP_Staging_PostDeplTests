﻿// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
// Framework required for using Edge driver in test
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
// Framework required for using the Randomizer Class
using NUnit.Framework.Internal;

// Post Deployment Test using MS Edge Web Browser
[TestFixture]
public class Test03
{
    private IWebDriver driver;
    public WebDriverWait waitForElement;
    public Randomizer random;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;
    public string randomFirstName;
    public string randomLastName;
    public string randomMobile;
    public string randomEmail;
    public string randomPassword01;
    public string randomPassword02;
    public string randomPpsn;
    public DateTime randomDateOfBirth;
    public string randomDateOfBirthString;
    private Random gen = new Random();
    public string randomNationality;
    public string randomAddressOne;
    public string randomAddressTwo;
    public string randomCity;
    public string randomPostCode;
    private IWebElement elementToClick;
    [SetUp]
    public void SetUp()
    {
        EdgeOptions options = new EdgeOptions();
        //filepath of the directory housing msedgedriver.exe on an Azure Pipeline vs2017-win2016 agent: https://github.com/actions/virtual-environments/blob/main/images/win/Windows2016-Readme.md
        string msedgedriverDir = @"C:\SeleniumWebDrivers\EdgeDriver"; //LOCAL: "C:\Users\ianh\Selenium\edgedriver_win64" OR ON AZURE: "C:\SeleniumWebDrivers\EdgeDriver"

        //name of the Edge Driver
        string msedgedriverExe = @"msedgedriver.exe";
        EdgeDriverService service = EdgeDriverService.CreateDefaultService(msedgedriverDir, msedgedriverExe);

        //Creating instance of the EdgeDriver
        driver = new EdgeDriver(service, options, TimeSpan.FromMinutes(3));

        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();

        //waitForElement instance to be used to ensure driver waits for an element to become selectable while page loads for at least a timespance of 30 seconds before an error is thrown
        waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        // Creating instance of the Randomizer() class and using it to generate random strings for use in the Post Deployment Test
        random = new Randomizer();
        randomFirstName = random.GetString(10);
        randomLastName = random.GetString(10);
        randomMobile = random.GetString(10);
        randomEmail = random.GetString(10);
        randomPassword01 = random.GetString(10);
        randomPassword02 = random.GetString(10);


        randomPpsn = random.GetString(10);

        // logic to generate a random date of birth assuming a date of birth between 100 years and 18 years ago
        DateTime maxDateTime = DateTime.Today.AddYears(-18);
        DateTime exampleMinDateTime = DateTime.Today.AddYears(-100);
        int range = (maxDateTime - exampleMinDateTime).Days;
        randomDateOfBirth = exampleMinDateTime.AddDays(gen.Next(range));
        randomDateOfBirthString = randomDateOfBirth.ToString("yyyy-MM-dd");

        randomNationality = random.GetString(10);
        randomAddressOne = random.GetString(10);
        randomAddressTwo = random.GetString(10);
        randomCity = random.GetString(10);
        randomPostCode = random.GetString(10);
    }
    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
    }
    [Test]
    public void PostDeploymentTest03()
    {
        // Post Deployment Test Navigates to URL for the Staging Environment Frontend Load Balancer and starts at login page for web application
        driver.Navigate().GoToUrl("http://20.67.229.253/"); //LOCAL: http://localhost:4200/ OR AZURE: http://20.67.229.253/
        driver.Manage().Window.Size = new System.Drawing.Size(1936, 1176);

        // Start: Test Steps to Register a New User
        driver.FindElement(By.CssSelector(".registerLink")).Click();

        driver.FindElement(By.Id("register")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("firstNameError")).Displayed);        
        // Verify errors displayed when no registration form inputs are provided before clicking Register button
        Assert.That(driver.FindElement(By.Id("firstNameError")).Text, Is.EqualTo("Please enter a First Name."));
        Assert.That(driver.FindElement(By.Id("lastNameError")).Text, Is.EqualTo("Please enter a Last Name."));
        Assert.That(driver.FindElement(By.Id("mobileError")).Text, Is.EqualTo("Please enter a Mobile Number."));
        Assert.That(driver.FindElement(By.Id("emailError")).Text, Is.EqualTo("Please enter a valid Email."));
        Assert.That(driver.FindElement(By.Id("passwordError")).Text, Is.EqualTo("Please enter a Password."));
        Assert.That(driver.FindElement(By.Id("confirmPasswordRequiredError")).Text, Is.EqualTo("Please enter a Password."));


        driver.FindElement(By.Id("firstNameInput")).SendKeys(randomFirstName);
        driver.FindElement(By.Id("lastNameInput")).SendKeys(randomLastName);
        driver.FindElement(By.Id("mobileInput")).SendKeys(randomMobile);
        driver.FindElement(By.Id("emailInput")).SendKeys(randomEmail + "testdomain.com");
        driver.FindElement(By.Id("passwordInput")).SendKeys(randomPassword01);
        driver.FindElement(By.Id("confirmPasswordInput")).SendKeys(randomPassword02);
        driver.FindElement(By.Id("confirmPasswordInput")).Click();

        driver.FindElement(By.Id("register")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("emailError")).Displayed);
        // Verify errors if an invalid email is used and passwords do not match
        Assert.That(driver.FindElement(By.Id("emailError")).Text, Is.EqualTo("Please enter a valid Email."));
        Assert.That(driver.FindElement(By.Id("confirmPasswordMismatchError")).Text, Is.EqualTo("Password does not match."));

        driver.FindElement(By.Id("emailInput")).Clear();
        driver.FindElement(By.Id("emailInput")).SendKeys(randomEmail + "@testdomain.com");
        driver.FindElement(By.Id("confirmPasswordInput")).Clear();
        driver.FindElement(By.Id("confirmPasswordInput")).SendKeys(randomPassword01);

        driver.FindElement(By.Id("register")).Click();
        // End: Test Steps to Register a New User

        // Start: Test Steps to Add Vaccination Details for a User
        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector("#errorBtn")).Displayed);
        elementToClick = driver.FindElement(By.CssSelector("#errorBtn"));
        waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementToClick));
        elementToClick.Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector("#saveBtn")).Displayed);
        elementToClick = driver.FindElement(By.CssSelector("#saveBtn"));
        waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementToClick));
        elementToClick.Click();


        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("ppsnError")).Displayed);
        // Verify errors displayed when no vaccination details form inputs are provided before clicking save button
        Assert.That(driver.FindElement(By.Id("ppsnError")).Text, Is.EqualTo("Please enter a PPSN."));
        Assert.That(driver.FindElement(By.Id("dateOfBirthError")).Text, Is.EqualTo("Please enter a Date of Birth."));
        Assert.That(driver.FindElement(By.Id("genderError")).Text, Is.EqualTo("Please select a Gender."));
        Assert.That(driver.FindElement(By.Id("nationalityError")).Text, Is.EqualTo("Please enter a Nationality."));
        Assert.That(driver.FindElement(By.Id("addressOneError")).Text, Is.EqualTo("Please enter an Address 1."));
        Assert.That(driver.FindElement(By.Id("addressTwoError")).Text, Is.EqualTo("Please enter an Address 2."));
        Assert.That(driver.FindElement(By.Id("cityError")).Text, Is.EqualTo("Please enter a City."));
        Assert.That(driver.FindElement(By.Id("postCodeError")).Text, Is.EqualTo("Please enter a Post Code."));
        Assert.That(driver.FindElement(By.Id("vaccinePreferenceError")).Text, Is.EqualTo("Please enter a Vaccine Preference."));

        driver.FindElement(By.Id("ppsnInput")).SendKeys(randomPpsn);
        driver.FindElement(By.Id("dateOfBirthInput")).SendKeys(randomDateOfBirthString);


        driver.FindElement(By.Id("genderInput")).Click();
        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector("#mat-option-0 > .mat-option-text")).Displayed);
        // verify the options displayed for the gender select dropdown
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-0 > .mat-option-text")).Text, Is.EqualTo("Male"));
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-1 > .mat-option-text")).Text, Is.EqualTo("Female"));
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-2 > .mat-option-text")).Text, Is.EqualTo("Other"));
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-3 > .mat-option-text")).Text, Is.EqualTo("Prefer not to say"));
        driver.FindElement(By.CssSelector("#mat-option-0 > .mat-option-text")).Click();

        driver.FindElement(By.Id("nationalityInput")).SendKeys(randomNationality);
        driver.FindElement(By.Id("addressOneInput")).SendKeys(randomAddressOne);
        driver.FindElement(By.Id("addressTwoInput")).SendKeys(randomAddressTwo);
        driver.FindElement(By.Id("cityInput")).SendKeys(randomCity);
        driver.FindElement(By.Id("postCodeInput")).SendKeys(randomPostCode);

        driver.FindElement(By.Id("vaccinePreferenceInput")).Click();
        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector("#mat-option-4 > .mat-option-text")).Displayed);
        // verify the options displayed for the vaccine preference select dropdown
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-4 > .mat-option-text")).Text, Is.EqualTo("Pfizer"));
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-5 > .mat-option-text")).Text, Is.EqualTo("Astrazenaca"));
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-6 > .mat-option-text")).Text, Is.EqualTo("Johnson and Johnson"));
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-7 > .mat-option-text")).Text, Is.EqualTo("Moderna"));
        driver.FindElement(By.CssSelector("#mat-option-4 > .mat-option-text")).Click();

        driver.FindElement(By.Id("saveBtn")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector(".mat-simple-snackbar > span")).Displayed);
        var elements = driver.FindElements(By.CssSelector(".mat-simple-snackbar > span"));
        // verify success message snackbar displayed if vaccination details are added successfully
        Assert.True(elements.Count > 0);
        driver.FindElement(By.CssSelector(".mat-simple-snackbar > div > .mat-button")).Click();
        // End: Test Steps to Add Vaccination Details for a User

        // Start: Test Steps to Edit/Update Vaccination Details for a User - Part 1
        driver.FindElement(By.Id("saveBtn")).Click();

        // error dislayed if attempting to save vaccination details again without any change in the details
        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector("#errorBtn")).Displayed);
        elementToClick = driver.FindElement(By.CssSelector("#errorBtn"));
        waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementToClick));
        elementToClick.Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector("#logoutBtn")).Displayed);
        elementToClick = driver.FindElement(By.CssSelector("#logoutBtn"));
        waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementToClick));
        elementToClick.Click();
        // End: Test Steps to Edit/Update Vaccination Details for a User - Part 1

        // Start: Test Steps to Login a User
        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector("#login")).Displayed);
        elementToClick = driver.FindElement(By.CssSelector("#login"));
        waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementToClick));
        elementToClick.Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("emailError")).Displayed);
        // Verify errors displayed if attempting to login without providing any login form inputs
        Assert.That(driver.FindElement(By.Id("emailError")).Text, Is.EqualTo("Please enter a valid Email."));
        Assert.That(driver.FindElement(By.Id("passwordError")).Text, Is.EqualTo("Please enter a Password."));

        driver.FindElement(By.Id("emailInput")).SendKeys(randomEmail + "testdomain.com");
        driver.FindElement(By.Id("passwordInput")).SendKeys(randomPassword01);
        driver.FindElement(By.Id("login")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("emailError")).Displayed);
        // Verify error displayed if attempting to login with an invalid email
        Assert.That(driver.FindElement(By.Id("emailError")).Text, Is.EqualTo("Please enter a valid Email."));

        driver.FindElement(By.Id("emailInput")).Clear();
        driver.FindElement(By.Id("passwordInput")).Clear();
        driver.FindElement(By.Id("emailInput")).SendKeys(randomEmail + "@testdomain.com");
        driver.FindElement(By.Id("passwordInput")).SendKeys(randomPassword02);
        driver.FindElement(By.Id("login")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector("#errorBtn")).Displayed);
        elementToClick = driver.FindElement(By.CssSelector("#errorBtn"));
        // Verify error displayed if attempting to login with the incorrect password for a user
        Assert.That(driver.FindElement(By.CssSelector("app-error > div > p")).Text, Is.EqualTo("Invalid User Credentials!"));
        waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementToClick));
        elementToClick.Click();

        driver.FindElement(By.Id("emailInput")).Clear();
        driver.FindElement(By.Id("passwordInput")).Clear();
        driver.FindElement(By.Id("emailInput")).SendKeys(randomEmail + "@testdomain.com");
        driver.FindElement(By.Id("passwordInput")).SendKeys(randomPassword01);
        driver.FindElement(By.Id("login")).Click();
        // End: Test Steps to Login a User

        // Start: Test Steps to Edit/Update Vaccination Details for a User - Part 2
        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("ppsnInput")).Displayed);
        // Verify the previously added vaccination details for the user are retrieved and displayed in the vaccination details form upon login
        Assert.That(driver.FindElement(By.Id("ppsnInput")).GetAttribute("value"), Is.EqualTo(randomPpsn));

        Assert.That(driver.FindElement(By.Id("dateOfBirthInput")).GetAttribute("value"), Is.EqualTo(randomDateOfBirth.ToString("M/d/yyyy")));

        Assert.That(driver.FindElement(By.CssSelector("#genderInput > div > div > span > .mat-select-min-line")).Text, Is.EqualTo("Male"));

        Assert.That(driver.FindElement(By.Id("nationalityInput")).GetAttribute("value"), Is.EqualTo(randomNationality));

        Assert.That(driver.FindElement(By.Id("addressOneInput")).GetAttribute("value"), Is.EqualTo(randomAddressOne));

        Assert.That(driver.FindElement(By.Id("addressTwoInput")).GetAttribute("value"), Is.EqualTo(randomAddressTwo));

        Assert.That(driver.FindElement(By.Id("cityInput")).GetAttribute("value"), Is.EqualTo(randomCity));

        Assert.That(driver.FindElement(By.Id("postCodeInput")).GetAttribute("value"), Is.EqualTo(randomPostCode));

        Assert.That(driver.FindElement(By.CssSelector("#vaccinePreferenceInput > div > div > span > .mat-select-min-line")).Text, Is.EqualTo("Pfizer"));

        driver.FindElement(By.Id("ppsnInput")).Clear();
        driver.FindElement(By.Id("ppsnInput")).SendKeys(randomPpsn+"TestUpdate");

        driver.FindElement(By.Id("saveBtn")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector(".mat-simple-snackbar > span")).Displayed);
        var elementsNew = driver.FindElements(By.CssSelector(".mat-simple-snackbar > span"));
        // verify success message snackbar displayed if vaccination details are updated successfully
        Assert.True(elementsNew.Count > 0);
        driver.FindElement(By.CssSelector(".mat-simple-snackbar > div > .mat-button")).Click();
        // End: Test Steps to Edit/Update Vaccination Details for a User - Part 2
    }
}
