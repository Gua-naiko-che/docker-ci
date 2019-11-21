using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace tests
{
    public class UnitTest1
    {
        [Fact(Skip = "just testing infra")]
        public void Test1()
        {
            using var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:5001/");
            By titleSelector = By.CssSelector("h1");
            IWebElement title = driver.FindElement(titleSelector);
            Assert.Equal("Hello, world!", title.Text);
        }

        [Fact]
        public void TestGoogle()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.BinaryLocation = "/opt/google/chrome/chrome";

            ChromeDriverService service = ChromeDriverService.CreateDefaultService("/opt/selenium", "chromedriver");

            using var driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("https://www.google.com/");
            var logoSelector = By.CssSelector("#hplogo");
            var logo = driver.FindElement(logoSelector);
            Assert.Equal("Google", logo.GetAttribute("alt").ToString());
        }
    }
}