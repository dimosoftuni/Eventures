using Eventures.Tests.Common;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Eventures.WebApp.UITests
{
    public class BaseTests
    {
        protected WebDriver driver;
        private ChromeOptions chromeOptions;
        private TestDb testDb;
        private TestEventuresApp<Startup> testEventuresApp;
        protected string baseUrl;

        [SetUp]
        public void PrepareApp()
        {
            this.testDb = new TestDb();
            this.testEventuresApp = new TestEventuresApp<Startup>(testDb, "../../../../Eventures.WebApp");
            this.chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            this.driver = new ChromeDriver(chromeOptions);
            this.baseUrl = testEventuresApp.ServerUri;
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
            testEventuresApp.Dispose();
        }
    }
}
