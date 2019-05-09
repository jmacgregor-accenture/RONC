using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Shouldly;
using Xunit;

namespace RONCFrontEnd.IntegrationTests
{
    public class EndToEndTests
    {
        [Fact]
        public void HomePageIsCorrect()
        {
            // TODO something here, possibly the way we're getting the Environment.CurrentDirectory and the hardcoded result, is throwing a "System.ComponentModel.Win32Exception; exec format error"
            //var service = FirefoxDriverService.CreateDefaultService("/home/travis/build/dunn-accenture/RONC/RONCFrontEnd/RONCFrontEnd.IntegrationTests/bin/Debug/netcoreapp2.2/", "geckodriver");   
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless");
            var webdriver = new FirefoxDriver("/home/travis/build/dunn-accenture/RONC/RONCFrontEnd/RONCFrontEnd.IntegrationTests/bin/Debug/netcoreapp2.2/",firefoxOptions);
            
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