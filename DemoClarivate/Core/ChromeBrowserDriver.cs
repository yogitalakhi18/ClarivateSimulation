using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace DemoClarivate.Core
{
    /// <summary>
    /// Chrome Browser Driver wrapper class, handles ChromeOptions assignment and browser instance creation part
    /// </summary>
	public class ChromeBrowserDriver
	{
        public static IWebDriver? Driver;

        public static IWebDriver CreateWebDriver()
        {
            ChromeOptions option = new ChromeOptions
            {
                AcceptInsecureCertificates = true,
            };
            option.AddArguments("test-type", "start-maximized", "no-default-browser-check", "--disable-extensions");

            Driver = new ChromeDriver(option);
            return Driver;
        }

        public static IWebDriver GetWebDriver()
        {
            if (Driver == null)
                return CreateWebDriver();
            else
                return Driver;
        }
    }
}
