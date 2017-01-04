namespace BrowserStack.Barebones.Tests
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
#if BROWSERSTACK
    using BrowserStack;
    using System.Collections.Generic;
#else
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
#endif

    [TestFixture("chrome")]
    [TestFixture("firefox")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class HomePageTests
    {
        private RemoteWebDriver driver;

        private WebDriverWait wait;

        private string browserName;

        public HomePageTests(string browserName)
        {
            this.browserName = browserName;
        }

        [SetUp]
        public void Setup()
        {
#if BROWSERSTACK
            const string ACCESS_USER = "";
            const string ACCESS_KEY = "";
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("browserstack.user", ACCESS_USER);
            capabilities.SetCapability("browserstack.key", ACCESS_KEY);
            capabilities.SetCapability("browser", this.browserName);
            capabilities.SetCapability("browserstack.local", "true");
            
            var uri = new Uri("http://hub-cloud.browserstack.com/wd/hub/");
            this.driver = new RemoteWebDriver(uri, capabilities);
#else
            if (this.browserName == "chrome")
            {
                this.driver = new ChromeDriver();
            }
            else if (this.browserName == "firefox")
            {
                this.driver = new FirefoxDriver();
            }
#endif
      
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(1));            
        }

        [TearDown]
        public void Teardown()
        {
            if (this.driver != null)
            {
                this.driver.Quit();
            }
        }

        [Test]
        public void CheckAboutPageTitle()
        {
            this.driver.Navigate().GoToUrl("http://localhost:61569/");
            this.driver.FindElementByLinkText("About").Click();
            
            Assert.DoesNotThrow(
                () => this.wait.Until(ExpectedConditions.TitleIs("About - My ASP.NET Application"))
            );
        }

        [Test]
        public void CheckContactPageTitle()
        {
            this.driver.Navigate().GoToUrl("http://localhost:61569/");
            this.driver.FindElementByLinkText("Contact").Click();

            Assert.DoesNotThrow(
                () => wait.Until(ExpectedConditions.TitleIs("Contagct - My ASP.NET Application"))
            );
        }
    }
}
