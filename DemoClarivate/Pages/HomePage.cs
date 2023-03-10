using OpenQA.Selenium;
using System;

namespace DemoClarivate.Pages
{
    /// <summary>
    /// Main google page, appears right after moving to google site url
    /// </summary>
	public class HomePage : BasePage
	{
        private IWebElement searchBar => Driver.FindElement(By.CssSelector("input[name='q']"));

        public HomePage()
        {
            if (btnAcceptAllCookies.Displayed)
                btnAcceptAllCookies.Click();
        }

        public T SearchItem<T>(string itemToSearch) where T : new()
        {
            WaitUntilDisplayed(searchBar);
            searchBar.SendKeys(itemToSearch);
            searchBar.SendKeys(Keys.Enter);
            return new T();
        }
    }
}
