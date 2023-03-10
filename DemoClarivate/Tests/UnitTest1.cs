using DemoClarivate.Core;
using DemoClarivate.Pages;
using DemoClarivate.Tests;

namespace DemoClarivate;

[TestClass]
public class UnitTest1 : BaseTest
{
    [TestMethod]
    public void TestToWriteTitlesOfPageOnTxtFile()
    {
        string itemToSearchOnGoogle = RunSettingsHelper.SearchItemOnGoogle;

        SearchResultsPage searchResultsPage = new HomePage()
                                            .SearchItem<SearchResultsPage>(itemToSearchOnGoogle)
                                            .WriteResultsInTxtFile(filePath);

        List<string> expTitles = searchResultsPage.GetAllTitles();
        bool isDataCorrect = searchResultsPage.IsFileDataCorrect(filePath, expTitles);

        Assert.IsFalse(searchResultsPage.IsFileEmpty(filePath), "The file is non-empty and has been written successfully.");
        Assert.IsTrue(isDataCorrect, "The data in the file is written as expected.");
    }

    [TestMethod]
    public void TestToCaptureScreenshot()
    {
        string itemToSearchOnGoogle = RunSettingsHelper.SearchItemOnGoogle;
        string itemToSearchOnProQuest = RunSettingsHelper.SearchItemOnProQuest;

        ProQuestSearchResultsPage searchResultsPage = new HomePage()
                    .SearchItem<SearchResultsPage>(itemToSearchOnGoogle)
                    .GoToProQuestWebsite<ProQuestHomePage>()
                    .SearchItem<ProQuestSearchResultsPage>(itemToSearchOnProQuest);

        string ssFileName = searchResultsPage.TakeFullPageScreenshot();
        Assert.IsTrue(searchResultsPage.DoesFileExist(ssFileName), "The screenshot has been taken successfully.");
    }
}
