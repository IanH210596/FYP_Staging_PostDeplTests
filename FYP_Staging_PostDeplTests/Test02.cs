﻿// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
// Framework required for using Firefox driver in test
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
// Framework required for using the Randomizer Class
using NUnit.Framework.Internal;

// Post Deployment Test using Google Chrome Web Browser
[TestFixture]
public class Test02
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
    [SetUp]
    public void SetUp()
    {
        driver = new FirefoxDriver("C:\\SeleniumWebDrivers\\GeckoDriver"); //LOCAL: N/A OR ON AZURE: "C:\\SeleniumWebDrivers\\GeckoDriver"
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();

        //waitForElement instance to be used to ensure driver waits for an element to become selectable while page loads for at least a timespance of 10 seconds before an error is thrown
        waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // Creating instance of the Randomizer() class and using it to generate random strings for use in the Post Deployment Test
        random = new Randomizer();
        randomFirstName = random.GetString(10);
        randomLastName = random.GetString(10);
        randomMobile = random.GetString(10);
        randomEmail = random.GetString(10);
        randomPassword01 = random.GetString(10);
        randomPassword02 = random.GetString(10);


        randomPpsn = random.GetString(10);

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
    public void PostDeploymentTest02()
    {
        driver.Navigate().GoToUrl("http://localhost:4200/"); //LOCAL: http://localhost:4200/ OR AZURE: http://20.67.229.253/
        driver.Manage().Window.Size = new System.Drawing.Size(1936, 1176);

        driver.FindElement(By.CssSelector(".registerLink")).Click();

        driver.FindElement(By.Id("register")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("firstNameError")).Displayed);
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
        Assert.That(driver.FindElement(By.Id("emailError")).Text, Is.EqualTo("Please enter a valid Email."));
        Assert.That(driver.FindElement(By.Id("confirmPasswordMismatchError")).Text, Is.EqualTo("Password does not match."));

        driver.FindElement(By.Id("emailInput")).Clear();
        driver.FindElement(By.Id("emailInput")).SendKeys(randomEmail + "@testdomain.com");
        driver.FindElement(By.Id("confirmPasswordInput")).Clear();
        driver.FindElement(By.Id("confirmPasswordInput")).SendKeys(randomPassword01);

        driver.FindElement(By.Id("register")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("errorBtn")).Displayed);
        driver.FindElement(By.Id("errorBtn")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("saveBtn")).Displayed);
        driver.FindElement(By.Id("saveBtn")).Click();


        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("ppsnError")).Displayed);
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
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-4 > .mat-option-text")).Text, Is.EqualTo("Pfizer"));
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-5 > .mat-option-text")).Text, Is.EqualTo("Astrazenaca"));
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-6 > .mat-option-text")).Text, Is.EqualTo("Johnson and Johnson"));
        Assert.That(driver.FindElement(By.CssSelector("#mat-option-7 > .mat-option-text")).Text, Is.EqualTo("Moderna"));
        driver.FindElement(By.CssSelector("#mat-option-4 > .mat-option-text")).Click();

        driver.FindElement(By.Id("saveBtn")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.CssSelector(".mat-simple-snackbar > span")).Displayed);
        var elements = driver.FindElements(By.CssSelector(".mat-simple-snackbar > span"));
        Assert.True(elements.Count > 0);
        driver.FindElement(By.CssSelector(".mat-simple-snackbar > div > .mat-button")).Click();

        driver.FindElement(By.Id("saveBtn")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("errorBtn")).Displayed);
        driver.FindElement(By.Id("errorBtn")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("logoutBtn")).Displayed);
        driver.FindElement(By.Id("logoutBtn")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("login")).Displayed);
        driver.FindElement(By.Id("login")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("emailError")).Displayed);
        Assert.That(driver.FindElement(By.Id("emailError")).Text, Is.EqualTo("Please enter a valid Email."));
        Assert.That(driver.FindElement(By.Id("passwordError")).Text, Is.EqualTo("Please enter a Password."));

        driver.FindElement(By.Id("emailInput")).SendKeys(randomEmail + "testdomain.com");
        driver.FindElement(By.Id("passwordInput")).SendKeys(randomPassword01);
        driver.FindElement(By.Id("login")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("emailError")).Displayed);
        Assert.That(driver.FindElement(By.Id("emailError")).Text, Is.EqualTo("Please enter a valid Email."));

        driver.FindElement(By.Id("emailInput")).Clear();
        driver.FindElement(By.Id("passwordInput")).Clear();
        driver.FindElement(By.Id("emailInput")).SendKeys(randomEmail + "@testdomain.com");
        driver.FindElement(By.Id("passwordInput")).SendKeys(randomPassword02);
        driver.FindElement(By.Id("login")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("errorBtn")).Displayed);
        Assert.That(driver.FindElement(By.CssSelector("app-error > div > p")).Text, Is.EqualTo("Invalid User Credentials!"));
        driver.FindElement(By.Id("errorBtn")).Click();

        driver.FindElement(By.Id("emailInput")).Clear();
        driver.FindElement(By.Id("passwordInput")).Clear();
        driver.FindElement(By.Id("emailInput")).SendKeys(randomEmail + "@testdomain.com");
        driver.FindElement(By.Id("passwordInput")).SendKeys(randomPassword01);
        driver.FindElement(By.Id("login")).Click();

        waitForElement.Until(webDriver => webDriver.FindElement(By.Id("ppsnInput")).Displayed);
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
        Assert.True(elementsNew.Count > 0);
        driver.FindElement(By.CssSelector(".mat-simple-snackbar > div > .mat-button")).Click();
    }
}
