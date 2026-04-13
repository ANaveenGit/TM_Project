using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

public class BaseTest1
{
    protected IWebDriver Driver;

    [OneTimeSetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile($"error_{DateTime.Now.Ticks}.png");
        }
        if (Driver != null)
        {
            Driver.Quit();
        }
        Driver.Dispose();
    }
}
public class BaseTest2
{
    protected IWebDriver Driver;

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile($"error_{DateTime.Now.Ticks}.png");
        }
        if (Driver != null)
        {
            Driver.Quit();
        }
        Driver.Dispose();
    }
}