using OpenQA.Selenium;
using System;

namespace DemoClarivate.Pages
{
	/// <summary>
	/// Search results page on ProQuest website, appears after searching item on the website
	/// </summary>
	public class ProQuestSearchResultsPage : BasePage
	{
		private List<IWebElement> searchResults => Driver.FindElements(By.CssSelector("ul.resultItems li")).ToList();

		public ProQuestSearchResultsPage()
		{
			webDriverWait.Until(x => searchResults.Count > 0);
		}
    }
}

