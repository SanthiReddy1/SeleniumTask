using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

namespace SeleniumTask.DriverExtension
{
    public class DriverIntialization
    {
        public string ExecutionMode = ConfigurationManager.AppSettings["ExceutionMode"];
        public string Browser = ConfigurationManager.AppSettings["Browser"];

        IWebDriver driver;
        public IWebDriver IntializeBrowser()
        {
            if (ExecutionMode == "Grid")
            {
                //IWebDriver driver = setRemoteBrowser(Browser);
            }
            if (ExecutionMode == "Linear")
            {
                driver = SetBrowser();
            }
            return driver;
        }
        public IWebDriver SetBrowser()
        {
            switch (Browser)
            {
                case "Chrome":
                    driver = new ChromeDriver(Base.GetProjectLocation() + @"\\Drivers");
                    break;
                case "ie":
                    break;
                    
            }
            return driver;
        }
            /*public IWebDriver setRemoteBrowser(string Browser)
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                capabilities.SetCapability(CapabilityType.BrowserName, Browser);
                capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                driver = new RemoteWebDriver(new Uri("http://ip/wd/hub"), capabilities, TimeSpan.FromSeconds(300));
                driver.Manage().Cookies.DeleteAllCookies();
                return driver;
            }*/
        }
}
