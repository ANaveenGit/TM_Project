using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TM_Assignment1.Utils;

public class Page1
{
    private readonly IWebDriver driver;

    public Page1(IWebDriver driver)
    {
        this.driver = driver;
    }

    By LoginOrRegister => By.XPath("//*[text()='Login or register']");
    By RegisterContinue => By.XPath("//*[@title='Continue']");
    By NewAccountPage => By.XPath("//*[normalize-space(text()) ='Create Account']");
    By SubscribeYes => By.Id("AccountFrm_newsletter1");
    By SubsribeNo => By.Id("AccountFrm_newsletter0");
    By PolicyAgree => By.Id("AccountFrm_agree");
    By NewAcContinue => By.XPath("//*[@title='Continue']");
    By RegisterError => By.XPath("//*[@class='alert alert-error alert-danger']");
    By SuccessMessage => By.XPath("//*[text()='Your Account Has Been Created!']");
   
    private readonly Dictionary<string, By> fieldLocators = new Dictionary<string, By>
    {
        { "FirstName", By.Id("AccountFrm_firstname") },
        { "LastName", By.Id("AccountFrm_lastname") },
        { "Email", By.Id("AccountFrm_email") },
        { "Telephone", By.Id("AccountFrm_telephone") },
        { "Fax", By.Id("AccountFrm_fax") },
        { "Company", By.Id("AccountFrm_company") },
        { "Address1", By.Id("AccountFrm_address_1") },
        { "Address2", By.Id("AccountFrm_address_2") },
        { "City", By.Id("AccountFrm_city") },
        { "State", By.Id("AccountFrm_zone_id") },
        { "ZIPCode", By.Id("AccountFrm_postcode") },
        { "Country", By.Id("AccountFrm_country_id") },
        { "LoginName", By.Id("AccountFrm_loginname") },
        { "Password", By.Id("AccountFrm_password") },
        { "PasswordConfirm", By.Id("AccountFrm_confirm") }
    };
    private readonly Dictionary<string, By> errorLocators = new Dictionary<string, By>
    {
        { "FirstName", By.XPath("//*[text()='First Name must be between 1 and 32 characters!']") },
        { "LastName", By.XPath("//*[text()='Last Name must be between 1 and 32 characters!']") },
        { "Email", By.XPath("//*[text()='Email Address does not appear to be valid!']") },
        { "Address1", By.XPath("//*[text()='Address 1 must be between 3 and 128 characters!']") },
        { "City", By.XPath("//*[text()='City must be between 3 and 128 characters!']") },
        { "State", By.XPath("//*[text()='Please select a region / state!']") },
        { "ZIPCode", By.XPath("//*[text()='Zip/postal code must be between 3 and 10 characters!']") },
        { "Country", By.XPath("//*[text()='Please select a country!']") },
        { "LoginName", By.XPath("//*[text()='Login name must be alphanumeric only and between 5 and 64 characters!']") },
        { "Password", By.XPath("//*[text()='Password must be between 4 and 20 characters!']") },
        { "PasswordConfirm", By.XPath("//*[text()='Password confirmation does not match password!']") }
    };
    private readonly Dictionary<string, string> errors = new Dictionary<string,string>
    {
        { "FirstName", "First Name must be between 1 and 32 characters!" },
        { "LastName", "Last Name must be between 1 and 32 characters!" },
        { "Email", "Email Address does not appear to be valid!" },
        { "Address1", "Address 1 must be between 3 and 128 characters!" },
        { "City", "City must be between 3 and 128 characters!" },
        { "State", "Please select a region / state!" },
        { "ZIPCode", "Zip/postal code must be between 3 and 10 characters!" },
        { "Country", "Please select a country!" },
        { "LoginName", "Login name must be alphanumeric only and between 5 and 64 characters!" },
        { "Password", "Password must be between 4 and 20 characters!" },
        { "PasswordConfirm", "Password confirmation does not match password!" }
    };

    public void Navigate()
    {
        driver.Navigate().GoToUrl("https://automationteststore.com/index.php?rt=account/login");
    }
    public void ClickRegisterContinue()
    {
        driver.FindElement(RegisterContinue).Click();
        Assert.That(Util.IsElementVisible(driver, NewAccountPage), Is.EqualTo(true), "New Account page is not displayed");
    }
    public void ClickNewAcContinue()
    {
        driver.FindElement(NewAcContinue).Click();
    }
    public void ClickLoginOrRegister()
    {
        driver.FindElement(LoginOrRegister).Click();
    }
    public void TextBoxesEmpty(string Element)
    {
        if (driver.FindElement(fieldLocators[Element]).Text == "")
            Console.WriteLine($"Pass: Textbox Field '{Element}' is empty in the New Register Form");
        else
            Assert.Fail($"Fail: Textbox Field '{Element}' is not empty in the New Register Form");
    }
    public void DropDownsEmpty(string Element)
    {
        if (new SelectElement(driver.FindElement(fieldLocators[Element])).SelectedOption.Text == "--- Please Select ---")
            Console.WriteLine($"Pass: Dropdown Field '{Element}' is empty in the New Register Form");
        else
            Assert.Fail($"Fail: Dropdown Field '{Element}' is not empty in the New Register Form");
    }
    public void ClickFields(string Element, string Value, bool Expected)
    {
        driver.FindElement(fieldLocators[Element]).Clear();
        driver.FindElement(fieldLocators[Element]).SendKeys(Value);
        ClickNewAcContinue();
        Assert.That(Util.IsElementVisible(driver, errorLocators[Element]), Is.EqualTo(Expected), $"Fail: '{Element}' Field is not working as expected");
        if (Expected)
            Console.WriteLine($"Pass: '{Element}' Field: Error thrown as '{errors[Element]}' for the Invalid input '{Value}'");
        else
            Console.WriteLine($"Pass: For a valid input '{Value}', error message for '{Element}' is not displayed");
    }
    public void DropDownFields(string Element, string Value, bool Expected)
    {
        new SelectElement(driver.FindElement(fieldLocators[Element])).SelectByText("--- Please Select ---");
        new SelectElement(driver.FindElement(fieldLocators[Element])).SelectByText(Value);
        ClickNewAcContinue();
        Assert.That(Util.IsElementVisible(driver, errorLocators[Element]), Is.EqualTo(Expected), $"Fail: '{Element}' Field is not working as expected");
        if (Expected)
            Console.WriteLine($"Pass: '{Element}' Field: Error thrown as '{errors[Element]}' for the Invalid input '{Value}'");
        else
            Console.WriteLine($"Pass: For a valid input '{Value}', error message for '{Element}' is not displayed");
    }
    public void EmailValidation(string Value, bool Expected)
    {
        driver.FindElement(fieldLocators["Email"]).Clear();
        driver.FindElement(fieldLocators["Email"]).SendKeys(Value);
        ClickNewAcContinue();
        Assert.That(Util.IsElementVisible(driver, errorLocators["Email"]), Is.EqualTo(Expected), $"Fail: 'Email' Field is not working as expected");
        if (Expected)
            Console.WriteLine($"Pass: 'Email' Field: Error thrown as '{errors["Email"]}' for the Invalid input '{Value}'");
        else
            Console.WriteLine($"Pass: For a valid input '{Value}', error message for 'Email' is not displayed");
    }
    public void PasswordValidation(string password, string passwordconfirm, bool Expected)
    {
        driver.FindElement(fieldLocators["Password"]).Clear();
        driver.FindElement(fieldLocators["Password"]).SendKeys(password);
        driver.FindElement(fieldLocators["PasswordConfirm"]).Clear();
        driver.FindElement(fieldLocators["PasswordConfirm"]).SendKeys(passwordconfirm);
        ClickNewAcContinue();
        Assert.That(Util.IsElementVisible(driver, errorLocators["PasswordConfirm"]), Is.EqualTo(Expected), $"Fail: 'Password Confirm' Field is not working as expected");
        if (Expected)
            Console.WriteLine($"Pass: 'Password Confirm' Field: Error thrown as '{errors["PasswordConfirm"]}' for entering the different Password inputs");
        else
            Console.WriteLine($"Pass: For a same Password inputs, error message under 'Password Confirm' field is not displayed");
    }

    public void FillMandatoryFields(string firstName, string lastName, string email, string address1, string city, string state, string zipCode, string country, string loginName, string password)
    {
        driver.FindElement(fieldLocators["FirstName"]).SendKeys(firstName);
        driver.FindElement(fieldLocators["LastName"]).SendKeys(lastName);
        driver.FindElement(fieldLocators["Email"]).SendKeys(email);
        driver.FindElement(fieldLocators["Address1"]).SendKeys(address1);
        driver.FindElement(fieldLocators["City"]).SendKeys(city);
        driver.FindElement(fieldLocators["ZIPCode"]).SendKeys(zipCode);
        new SelectElement(driver.FindElement(fieldLocators["Country"])).SelectByText(country);
        new SelectElement(driver.FindElement(fieldLocators["State"])).SelectByText(state);
        driver.FindElement(fieldLocators["LoginName"]).SendKeys(loginName);
        driver.FindElement(fieldLocators["Password"]).SendKeys(password);
        driver.FindElement(fieldLocators["PasswordConfirm"]).SendKeys(password);
        driver.FindElement(PolicyAgree).Click();
        ClickNewAcContinue();
        if (Util.IsElementVisible(driver, RegisterError))
            Console.WriteLine("Account creation failed - Error message displayed: " + driver.FindElement(RegisterError).Text);
        else
        {
            Assert.That(Util.IsElementVisible(driver, SuccessMessage), Is.EqualTo(true), "Account creation failed - Success message not displayed");
            Console.WriteLine("Pass: Account created successfully with mandatory fields filled");
        }
    }
    public void FillRegistrationForm(string firstName, string lastName, string email, string telephone, string fax, string company, string address1, string address2, string city, string state, string zipCode, string country, string loginName, string password, bool subscribe)
    {
        driver.FindElement(fieldLocators["FirstName"]).SendKeys(firstName);
        driver.FindElement(fieldLocators["LastName"]).SendKeys(lastName);
        driver.FindElement(fieldLocators["Email"]).SendKeys(email);
        driver.FindElement(fieldLocators["Telephone"]).SendKeys(telephone);
        driver.FindElement(fieldLocators["Fax"]).SendKeys(fax);
        driver.FindElement(fieldLocators["Company"]).SendKeys(company);
        driver.FindElement(fieldLocators["Address1"]).SendKeys(address1);
        driver.FindElement(fieldLocators["Address2"]).SendKeys(address2);
        driver.FindElement(fieldLocators["City"]).SendKeys(city);
        driver.FindElement(fieldLocators["ZIPCode"]).SendKeys(zipCode);
        new SelectElement(driver.FindElement(fieldLocators["Country"])).SelectByText(country);
        new SelectElement(driver.FindElement(fieldLocators["State"])).SelectByText(state);
        driver.FindElement(fieldLocators["LoginName"]).SendKeys(loginName);
        driver.FindElement(fieldLocators["Password"]).SendKeys(password);
        driver.FindElement(fieldLocators["PasswordConfirm"]).SendKeys(password);
        if (subscribe)
            driver.FindElement(SubscribeYes).Click();
        else
            driver.FindElement(SubsribeNo).Click();
        driver.FindElement(PolicyAgree).Click();
        ClickNewAcContinue();
        if (Util.IsElementVisible(driver, RegisterError))
        {
            Assert.Fail("Account creation failed - Error message displayed: " + driver.FindElement(RegisterError).Text);
        }
        Assert.That(Util.IsElementVisible(driver, SuccessMessage), Is.EqualTo(true), "Account creation failed - Success message not displayed");
        Console.WriteLine("Pass: Account created successfully with all fields filled and subscribe to newsletter option selected as " + subscribe);
    }
}