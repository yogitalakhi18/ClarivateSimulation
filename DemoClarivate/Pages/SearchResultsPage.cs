using OpenQA.Selenium;
using System;

namespace DemoClarivate.Pages
{
    /// <summary>
    /// Page appears after searching item on Google main page
    /// </summary>
	public class SearchResultsPage : BasePage
	{
        private List<IWebElement> searchResults => Driver.FindElements(By.CssSelector("div#search h3")).ToList();
        private IWebElement lnkWebsite => Driver.FindElement(By.XPath("//a[@href='https://www.proquest.com/']"));

        public List<string> GetAllTitles(List<IWebElement> elements)
        {
            List<string> titles = new List<string>();
            elements.ForEach(x => titles.Add(x.Text));
            return titles;
        }

        public SearchResultsPage WriteResultsInTxtFile(string filePath)
        {
            List<string> dataToWrite = GetAllTitles(searchResults);
            File.WriteAllLines(filePath, dataToWrite);
            return this;
        }

        public T GoToProQuestWebsite<T>() where T : new()
        {
            WaitUntilEnabled(lnkWebsite);
            lnkWebsite.Click();
            return new T();
        }
    }
}

