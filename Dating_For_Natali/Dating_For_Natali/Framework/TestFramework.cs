using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SeleniumTests
{
    public class TestFramework
    {
        static RemoteWebDriver _WebDriver;
        private static readonly string pathToFirefox = ConfigurationManager.AppSettings["PathToFireFox"];
        private static readonly string nameOfDriver = ConfigurationManager.AppSettings["NameOfDriver"];
        private static readonly string pathToDriver = Environment.CurrentDirectory;

        public static RemoteWebDriver WebDriver
        {
            get
            {
                if (_WebDriver == null)
                {
                    FirefoxDriverService service;
                    if (!string.IsNullOrEmpty(nameOfDriver))
                    {
                        service = FirefoxDriverService.CreateDefaultService(pathToDriver, nameOfDriver);
                    }
                    else
                    {
                        throw new ConfigurationErrorsException("Check config setting 'NameOfDriver'");
                    }
                    var profile = new FirefoxProfile();
                    profile.SetPreference("security.sandbox.content.level", 5);

                    _WebDriver = new FirefoxDriver(service, new FirefoxOptions()
                    {
                        Profile = profile,
                        BrowserExecutableLocation = pathToFirefox
                    }, new TimeSpan(0, 0, 90));
                }
                return _WebDriver;
            }
        }
        public static void Dispose()
        {
            if (_WebDriver != null)
                _WebDriver.Quit();
            _WebDriver = null;
        }

        public static void OpenURL(string URL)
        {
            WebDriver.Navigate().GoToUrl(URL);
        }
        public static void Back()
        {
            _WebDriver.Navigate().Back();
        }

        public static string OpenInOtherWindow(string link)
        {
            var currentWindow = WebDriver.CurrentWindowHandle;

            WebDriver.ExecuteScript("window.open()");

            var newWindow = WebDriver.WindowHandles.FirstOrDefault(x => x.Equals(currentWindow) == false);

            WebDriver.SwitchTo().Window(newWindow);
            WebDriver.Navigate().GoToUrl(link);

            return newWindow;
        }
        public static IWebElement FindWebElement(WebItem webItem)
        {
            if (webItem.ID != "")
                return WebDriver.FindElementById(webItem.ID);

            if (webItem.ClassName != "")
                return WebDriver.FindElementByClassName(webItem.ClassName);

            if (webItem.XPathQuery != "")
                return WebDriver.FindElementByXPath(webItem.XPathQuery);

            if (webItem.Name != "")
                return WebDriver.FindElementByName(webItem.Name);

            return null;
        }
        public static void Delay(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }
    }
}
