using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using WDSE.ScreenshotMaker;
using DemoClarivate.Core;
using WDSE.Decorators;
using OpenQA.Selenium;
using System;
using WDSE;

namespace DemoClarivate.Pages
{
    /// <summary>
    /// BasePage for all the page classes, contains common methods to use across all pages
    /// </summary>
	public class BasePage : SeleniumBase
	{
        public static IWebDriver Driver;
        public static WebDriverWait webDriverWait;
        private static string screenshotFolderPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Screenshots");
        protected IWebElement btnAcceptAllCookies => Driver.FindElement(By.XPath("//div[text()='Accept all'] | //button[text()='Accept all']"));

        public BasePage()
        {
            Driver = GetDriver();
            webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
        }

        public bool WaitUntilDisplayed(IWebElement element)
        {
            return webDriverWait.Until(x => element.Displayed);
        }

        public bool WaitUntilEnabled(IWebElement element)
        {
            return webDriverWait.Until(x => element.Enabled);
        }

        public string TakeFullPageScreenshot()
        {
            string ssFileName = $"{screenshotFolderPath}/{currentTimeStamp}.Png";

            if (!Directory.Exists(screenshotFolderPath))
            {
                DirectoryInfo folder = Directory.CreateDirectory(screenshotFolderPath);
            }

            var vcd = new VerticalCombineDecorator(new ScreenshotMaker());
            Driver.TakeScreenshot(vcd).ToMagickImage().Write(string.Format(ssFileName), ImageMagick.MagickFormat.Png);

            return ssFileName;
        }

        public string TakeScreenshot()
        {
            string ssFileName = $"{screenshotFolderPath}/Screenshot{currentTimeStamp}.Png";

            if (!Directory.Exists(screenshotFolderPath))
            {
                DirectoryInfo folder = Directory.CreateDirectory(screenshotFolderPath);
            }

            //Code to take normal screenshot
             Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
             ss.SaveAsFile(ssFileName, ScreenshotImageFormat.Png);

            return ssFileName;
        }

        public bool DoesFileExist(string fileName)
        {
            if (File.Exists(fileName))
                return true;
            else
                return false;
        }

        public bool IsFileEmpty(string filePath)
        {
            if (!(new FileInfo(filePath).Length == 0))
                return false;
            else
                return true;
        }
    }
}

