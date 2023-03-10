using DemoClarivate.Core;
using OpenQA.Selenium;
using System;

namespace DemoClarivate.Tests
{
    /// <summary>
    /// Base class for all test classes, contains common functionalities to use across test classes
    /// </summary>
    [TestClass]
	public class BaseTest : SeleniumBase
	{
        public static IWebDriver Driver;
        public static TestContext _testContext { get; set; }

        private static string folderPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        public static string filePath = @$"{folderPath}/FileToWrite{currentTimeStamp}.txt";

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            RunSettingsHelper.ReadRunSettings(testContext);
            _testContext = testContext;
        }

        public BaseTest()
        {
            Driver = GetDriver();
            Driver.Navigate().GoToUrl(RunSettingsHelper.SiteUrl);
        }

        [TestCleanup]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}
