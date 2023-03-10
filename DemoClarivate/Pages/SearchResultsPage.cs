using OpenQA.Selenium;
using System;

namespace DemoClarivate.Pages
{
    /// <summary>
    /// Page appears after searching item on Google main page
    /// </summary>
	public class SearchResultsPage : BasePage
	{
        private List<IWebElement> searchResults => Driver.FindElements(By.CssSelector("div#search a>h3")).ToList();
        private IWebElement lnkWebsite => Driver.FindElement(By.XPath("//a[@href='https://www.proquest.com/']"));

        public List<string> GetAllTitles()
        {
            List<string> titles = new List<string>();
            searchResults.ForEach(x => titles.Add(x.Text));
            titles.RemoveAll(x => string.IsNullOrEmpty(x));
            return titles;
        }

        public SearchResultsPage WriteResultsInTxtFile(string filePath)
        {
            List<string> dataToWrite = GetAllTitles();
            File.WriteAllLines(filePath, dataToWrite);
            return this;
        }

        public bool IsFileDataCorrect(string filePath, List<string> expectedData)
        {
            List<string> writtenData = File.ReadAllLines(filePath).ToList();
            return expectedData.SequenceEqual(writtenData);
        }

        public T GoToProQuestWebsite<T>() where T : new()
        {
            WaitUntilEnabled(lnkWebsite);
            lnkWebsite.Click();
            return new T();
        }
    }
}

