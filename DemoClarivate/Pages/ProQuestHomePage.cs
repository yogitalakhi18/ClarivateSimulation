using OpenQA.Selenium;
using System;

namespace DemoClarivate.Pages
{
    /// <summary>
    /// ProQuest Home page, appears after moving to ProQuest website url
    /// </summary>
	public class ProQuestHomePage : BasePage
	{
        private IWebElement txtSearchBar => Driver.FindElement(By.CssSelector("textarea#searchTerm"));
        private IWebElement iconSearch => Driver.FindElement(By.Id("expandedSearch"));

        public T SearchItem<T>(string searchKeyword) where T : new()
        {
            txtSearchBar.SendKeys(searchKeyword);
            iconSearch.Click();
            return new T();
        }
    }
}
