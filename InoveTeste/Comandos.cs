using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;

namespace InoveTeste
{
    class Comandos
    {
#region Browser
        public static IWebDriver GetBrowserLocal(IWebDriver driver, String browser)
        {
            switch (browser)
            {
                case "Internet Explorer":
                    driver = new InternetExplorerDriver();
                    driver.Manage().Window.Maximize();
                    break;

                case "Chrome":
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;

                default:
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
            }
            return driver;
        }

        public static IWebDriver GetBrowserRemote(IWebDriver driver, String browser, String uri)
        {
            switch (browser)
            {
                case "Internet Explorer":
                    InternetExplorerOptions cap_ie = new InternetExplorerOptions();
                    driver = new RemoteWebDriver(new Uri(uri), cap_ie);
                    driver.Manage().Window.Maximize();
                    break;

                case "Chrome":
                    ChromeOptions cap_chrome = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri(uri), cap_chrome);
                    driver.Manage().Window.Maximize();
                    break;

                default:
                    FirefoxOptions cap_firefox = new FirefoxOptions();
                    driver = new RemoteWebDriver(new Uri(uri), cap_firefox);
                    driver.Manage().Window.Maximize();
                    break;
            }
            return driver;
        }
        #endregion

        #region JavaScript
        public static void ExecuteJS(IWebDriver driver, String script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script);
        }
        #endregion
    }
}
