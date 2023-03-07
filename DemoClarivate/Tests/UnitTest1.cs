using DemoClarivate.Pages;
using DemoClarivate.Tests;

namespace DemoClarivate;

[TestClass]
public class UnitTest1 : BaseTest
{
    [TestMethod]
    public void TestToWriteTitlesOfPageOnTxtFile()
    {
        SearchResultsPage searchResultsPage = new HomePage()
                                            .SearchItem<SearchResultsPage>("ProQuest")
                                            .WriteResultsInTxtFile(filePath);

        Assert.IsFalse(searchResultsPage.IsFileEmpty(filePath), "The file is non-empty and has been written successfully.");
    }

    [TestMethod]
    public void TestToCaptureScreenshot()
    {
        string itemToSearchOnGoogle = "ProQuest";
        string itemToSearchOnProQuest = "QA";

        ProQuestSearchResultsPage searchResultsPage = new HomePage()
                    .SearchItem<SearchResultsPage>(itemToSearchOnGoogle)
                    .GoToProQuestWebsite<ProQuestHomePage>()
                    .SearchItem<ProQuestSearchResultsPage>(itemToSearchOnProQuest);

        string ssFileName = searchResultsPage.TakeFullPageScreenshot();
        Assert.IsTrue(searchResultsPage.DoesFileExist(ssFileName), "The screenshot has been taken successfully.");
    }
}
