# TM_Assignment1

TM_Assignment1 is a test automation project designed to validate the registration form of a web application 'Automation Test Store'. It uses NUnit as the test framework, Selenium WebDriver for browser automation, and FluentAssertions for assertions.

## Prerequisites

Before setting up and running the project, ensure you have the following installed:

- **Visual Studio 2022** (or later)
- **.NET 9 SDK**
- **Google Chrome** (latest version)
- **ChromeDriver** (compatible with your Chrome version)
- **NuGet Packages**:
  - `NUnit`
  - `NUnit3TestAdapter`
  - `Selenium.WebDriver`
  - `Selenium.Support`
  - `FluentAssertions`

## Project Structure

The project is organized as follows:

- **Main Test**: Contains the test classes (`Test1.cs`) for validating the registration form.
- **Test Pages**: Contains the `Page1.cs` file, which encapsulates all interactions with the registration page.
- **Local Station**: Contains base test classes (`BaseTest1.cs`, `BaseTest2.cs`) for WebDriver setup and teardown.
- **Utils**: Contains utility classes for additional functionality.

## Setup Instructions

1. **Clone the Repository**:

2. **Open the Project**:
Open the `TM_Assignment1.sln` file in Visual Studio 2022.

3. **Restore NuGet Packages**:
In Visual Studio, go to __Tools > NuGet Package Manager > Manage NuGet Packages for Solution__, and restore the required packages.

4. **Configure ChromeDriver**:
- Ensure `chromedriver.exe` is available in your system's PATH or place it in the project directory.
- Update the WebDriver initialization in `BaseTest1.cs` or `BaseTest2.cs` if necessary.

5. **Build the Project**:
- In Visual Studio, build the solution by pressing `Ctrl+Shift+B` or selecting __Build > Build Solution__.

## Execution Instructions

### Running Tests in Visual Studio

1. Open the __Test Explorer__ window:
- Go to __Test > Test Explorer__.

2. Run All Tests:
- Click the __Run All__ button in the Test Explorer to execute all tests.

3. Run Specific Tests:
- Select individual tests or test classes in the Test Explorer and click __Run Selected Tests__.

### Running Tests via Command Line

1. Open a terminal and navigate to the project directory.

2. Use the following command to run the tests:

3. To run specific tests, use the `--filter` option:

### Test Results

- Test results will be displayed in the Test Explorer or the terminal output.
- For detailed logs, check the output window in Visual Studio.
- A total of 54 test cases were covered in the project, including both Positive and Negative scenarios.
- Out of these, 2 test cases failed, as they did not work as expected. You will see an Assert.Fail message for these scenarios.
- The remaining 52 test cases passed, as they worked as expected. You will see a Pass message for these scenarios.


## Key Features

- **Parameterized Tests**: Tests are parameterized using `[TestCase]` attributes for various input scenarios.
- **Page Object Model**: The `Page1` class encapsulates all interactions with the registration page.
- **Error Validation**: Tests cover boundary values, special characters, and empty field validations.
- **Positive Scenarios**: Includes tests for successful registration with mandatory and all fields.

## Troubleshooting

- **ChromeDriver Version Mismatch**: Ensure the ChromeDriver version matches your installed Chrome browser version.
- **Test Failures**: Verify that the web application under test is accessible and the locators in `Page1.cs` are up-to-date.
