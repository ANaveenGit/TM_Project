using OpenQA.Selenium;

namespace TM_Assignment1.Utils
{
    public class Util
    {
        public static Boolean IsElementVisible(IWebDriver driver, By Element)
        {
            var elements = driver.FindElements(Element);
            if (elements.Count > 0)
                return true;
            else
                return false;
        }
    }
}
