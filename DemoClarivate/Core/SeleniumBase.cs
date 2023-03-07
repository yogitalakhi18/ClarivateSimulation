using OpenQA.Selenium;

namespace DemoClarivate.Core
{
    /// <summary>
    /// Base class for BasePage and BaseTest classes, provides WebDriver instance if doesn't exist
    /// </summary>
	public class SeleniumBase
	{
        private IWebDriver driver = (IWebDriver)ChromeBrowserDriver.GetWebDriver();
        protected static string currentTimeStamp = DateTime.Now.ToString("MMddHHmmss");

        public IWebDriver GetDriver()
        {
            return this.driver;
        }
    }
}
