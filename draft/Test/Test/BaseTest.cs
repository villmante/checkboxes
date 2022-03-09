using draft.Drivers;
using draft.Page;
using NUnit.Framework;
using OpenQA.Selenium;

namespace draft.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static BasicCheckBoxPage _page;


        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetFirefoxDriver();

            _page = new BasicCheckBoxPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}

