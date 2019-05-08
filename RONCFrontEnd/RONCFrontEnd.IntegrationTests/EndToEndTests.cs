using Xunit;
using OpenQA.Selenium.Firefox;
using Shouldly;

namespace RevengeOfTheNewsChallenger.IntegrationTests
{
    public class EndToEndTests
    {
        [Fact]
        public void HomePageIsCorrect()
        {
            var webdriver = new FirefoxDriver();
            
            webdriver.Navigate().GoToUrl("http://localhost:5000/");

            var div = webdriver.FindElementByTagName("div");
            
            div.Text.ShouldBe("biggun");
            
            webdriver.Quit();
        }
    }
}