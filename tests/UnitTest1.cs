using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--whitelisted-ips=''");
            options.BinaryLocation = "/opt/google/chrome/chrome";

            ChromeDriverService service = ChromeDriverService.CreateDefaultService("/opt/selenium", "chromedriver");

            using var driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("http://webapp:80");
            By titleSelector = By.CssSelector("h1");
            IWebElement title = driver.FindElement(titleSelector);
            Assert.Equal("Hello, world!", title.Text);
        }
    }
}