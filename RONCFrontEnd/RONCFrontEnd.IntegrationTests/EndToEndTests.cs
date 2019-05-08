using System;
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
            
            //Thread.Sleep(TimeSpan.FromSeconds(5));

            var div = webdriver.FindElementByTagName("div");
            
            try
            {
                div.Text.ShouldBe("biggun");
            }
            finally
            {
                webdriver.Quit();
            }
            
            
        }
    }
}