using FluentAssertions;
using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Flow_1
{
    [TestFixture]
    public class Test_Register_Form : BaseTest1
    {
        private Page1 Page;

        [OneTimeSetUp]
        public void Init()
        {
            Page = new Page1(Driver);
            Page.Navigate();
        }
        [SetUp]
        public void Continue()
        {
            Page.ClickRegisterContinue();
        }
        [TearDown]
        public void Back()
        {
            Page.ClickLoginOrRegister();
        }

        [TestCase("FirstName", "uythurhbvtuythurhbvtuythurhbvt768", true)] //Boundary value case for FirstName with above 32 characters(Negative)
        [TestCase("FirstName", "!@#$%^{}|\\:;\"'<>,./?", false)] //Special characters case for FirstName(Negative)
        [TestCase("FirstName", "A", false)] //Boundary value case for FirstName with 1 character(Positive)
        [TestCase("FirstName", "TMName", false)] //Valid case for FirstName(Positive)
        [TestCase("LastName", "uythurhbvtuythurhbvtuythurhbvt768", true)] //Boundary value case for LastName with above 32 characters(Negative)
        [TestCase("LastName", "!@#$%^{}|\\:;\"'<>,./?", false)] //Special characters case for LastName(Negative)
        [TestCase("LastName", "A", false)] //Boundary value case for LastName with 1 character(Positive)
        [TestCase("LastName", "TM123", false)] //Valid case for LastName(Positive)
        [TestCase("Address1", "uythurhbvtuythurhbvtuythurhbvt768uythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvt123456", true)] //Boundary value case for Address1 with above 128 characters(Negative)
        [TestCase("Address1", "A", true)] //Boundary value case for Address1 with 1 character(Negative)
        [TestCase("Address1", "!@#$%^{}|\\:;\"'<>,./?", false)] //Special characters case for Address1(Negative)
        [TestCase("Address1", "MG Road, Lalit Nagar", false)] //Valid case for Address1(Positive)
        [TestCase("City", "uythurhbvtuythurhbvtuythurhbvt768uythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvt123456", true)] //Boundary value case for City with above 128 characters(Negative)
        [TestCase("City", "A", true)] //Boundary value case for City with 1 character(Negative)
        [TestCase("City", "!@#$%^{}|\\:;\"'<>,./?", false)] //Special characters case for City(Negative)
        [TestCase("City", "Bengaluru", false)] //Valid case for City(Positive)
        [TestCase("ZIPCode", "78398637768", true)] //Boundary value case for ZIPCode with above 10 characters(Negative)
        [TestCase("ZIPCode", "A", true)] //Boundary value case for ZIPCode with 1 character(Negative)
        [TestCase("ZIPCode", "!@#$%^{}|\\:;\"'<>,./?", false)] //Special characters case for ZIPCode(Negative)
        [TestCase("ZIPCode", "123456", false)] //Valid case for ZIPCode(Positive)
        [TestCase("LoginName", "uythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvtuythurhbvt76890", true)] //Boundary value case for LoginName with above 64 characters(Negative)
        [TestCase("LoginName", "ABCD", true)] //Boundary value case for LoginName with 4 characters(Negative)
        [TestCase("LoginName", "!@#$%^{}|\\:;\"'<>,./?", true)] //Special characters case for LoginName(Negative)
        [TestCase("LoginName", "MyNameTM", false)] //Valid case for LoginName(Positive)
        [TestCase("Password", "uythurhbvtuythurhbvt7", true)] //Boundary value case for Password with above 20 characters(Negative)
        [TestCase("Password", "ABC", true)] //Boundary value case for Password with 3 characters(Negative)
        [TestCase("Password", "!@#$%^{}|\\:;\"'<>,./?", false)] //Special characters case for Password(Positive)
        [TestCase("Password", "TM@123", false)] //Valid case for Password(Positive)
        public void Test_Register_TextBoxs_Errors(string Element, string Value, bool Expected)
        {
            Page.ClickFields(Element, Value, Expected);
        }
        
        [TestCase("State", "Torfaen", false)] //Valid case for State dropdown(Positive)
        [TestCase("Country", "India", false)] //Valid case for Country dropdown(Positive)
        public void Test_Register_Dropdowns_Errors(string Element, string Value, bool Expected)
        {
            Page.DropDownFields(Element, Value, Expected);
        }

        [TestCase("FirstName")] //Test to check if the First Name field is empty or not(Negative)
        [TestCase("LastName")] //Test to check if the Last Name field is empty or not(Negative)
        [TestCase("Email")] //Test to check if the Email field is empty or not(Negative)
        [TestCase("Telephone")] //Test to check if the Telephone field is empty or not(Negative)
        [TestCase("Fax")] //Test to check if the Fax field is empty or not(Negative)
        [TestCase("Company")] //Test to check if the Company field is empty or not(Negative)
        [TestCase("Address1")] //Test to check if the Address1 field is empty or not(Negative)
        [TestCase("Address2")] //Test to check if the Address2 field is empty or not(Negative)
        [TestCase("City")] //Test to check if the City field is empty or not(Negative)
        [TestCase("ZIPCode")] //Test to check if the ZIPCode field is empty or not(Negative)
        [TestCase("LoginName")] //Test to check if the LoginName field is empty or not(Negative)
        [TestCase("Password")] //Test to check if the Password field is empty or not(Negative)
        [TestCase("PasswordConfirm")] //Test to check if the PasswordConfirm field is empty or not(Negative)
        public void Test_Register_TextBoxes_Empty_Or_Not(string Element)
        {
            Page.TextBoxesEmpty(Element);
        }

        [TestCase("State")] //Test to check if the State dropdown is empty or not(Negative)
        [TestCase("Country")] //Test to check if the Country dropdown is empty or not(Negative)
        public void Test_Register_Dropdowns_Empty_Or_Not(string Element)
        {
            Page.DropDownsEmpty(Element);
        }

        [TestCase("invalidemail", true)] //Invalid email format case(Negative)
        [TestCase("Test@.com", true)] //Invalid email format case(Negative)
        [TestCase("TestSDET@TM.com", false)] //Valid email format case(Positive)
        public void Test_Invalid_Email(string email, bool Expected)
        {
            Page.EmailValidation(email, Expected);
        }

        [TestCase("TM@12345", "TM@1234", true)] //Different values passed in Password fields(Negative)
        [TestCase("TM@123", "TM@123", false)] //Same values passed in Password fields(Positive)
        public void Test_Password_Validation(string password, string passwordconfirm, bool Expected)
        {
            Page.PasswordValidation(password, passwordconfirm, Expected);
        }

        [TestCase("SDET", "TM", "SDET@TM.com", "Electronic City", "Bengaluru", "Karnataka", "8373373", "India", "NameTM", "Ben@TM")] //Email alredy exists error case(Negative)
        [TestCase("SDET", "TM", "SDET3@TM.com", "Electronic City", "Bengaluru", "Karnataka", "8373373", "India", "NameTM", "Ben@TM")] //LoginName alredy exists error case(Negative)
        public void Test_Mandatory_Fields_Register_Form(string firstName, string lastName, string email, string address1, string city, string state, string zipCode, string country, string loginName, string password)
        {
            Page.FillMandatoryFields(firstName, lastName, email, address1, city, state, zipCode, country, loginName, password);
        }
    }
    public class Create_Register_Form : BaseTest2
    {
        private Page1 Page;

        [SetUp]
        public void Init()
        {
            Page = new Page1(Driver);
            Page.Navigate();
            Page.ClickRegisterContinue();
        }

        [TestCase("SDET", "TM", "SDETA@TM.com", "Electronic City", "Bengaluru", "Karnataka", "8373373", "India", "NameTMA", "Ben@TM")] //Successful registration case with only Mandatory Fields(Positive)
        public void Test_Mandatory_Fields_Register_Form(string firstName, string lastName, string email, string address1, string city, string state, string zipCode, string country, string loginName, string password)
        {
            Page.FillMandatoryFields(firstName, lastName, email, address1, city, state, zipCode, country, loginName, password);
        }

        [TestCase("SDET", "TM", "SDETB@TM.com", "84973830", "080-8727622", "TMServices", "Electronic City", "Bommasandra", "Bengaluru", "Karnataka", "8373373", "India", "NameTMB", "Ben@TM", true)] //Successful registration case with all fields filled and subscribe to newsletter(Positive)
        public void Test_All_Fields_Register_Form(string firstName, string lastName, string email, string telephone, string fax, string company, string address1, string address2, string city, string state, string zipCode, string country, string loginName, string password, bool subscribe)
        {
            Page.FillRegistrationForm(firstName, lastName, email, telephone, fax, company, address1, address2, city, state, zipCode, country, loginName, password, subscribe);
        }
    }
}