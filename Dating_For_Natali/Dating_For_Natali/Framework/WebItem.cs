using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class WebItem
    {
        private WebDriverWait wait;
        public string ID { get; set; }
        public string ClassName { get; set; }
        public string XPathQuery { get; set; }
        public string Name { get; set; }

        public WebItem(string id = "", string className = "", string xPathQuery = "", string name = "")
        {
            ID = id;
            ClassName = className;
            XPathQuery = xPathQuery;
            Name = name;

            wait = new WebDriverWait(TestFramework.WebDriver, TimeSpan.FromSeconds(30 * 3));
        }

        public void Click()
        {
            TestFramework.FindWebElement(this).Click();
        }

        public void SetValue(string value)
        {
            var element = TestFramework.FindWebElement(this);
            element.SendKeys(value);
        }

        public string GetValue(string attrName)
        {
            return TestFramework.FindWebElement(this).GetAttribute(attrName);
        }

        public IWebElement GetParent()
        {
            return TestFramework.FindWebElement(this).FindElement(By.XPath(".."));
        }
        public ICollection<IWebElement> GetItems(By value)
        {
            return TestFramework.FindWebElement(this).FindElements(value);
        }

        public string GetText()
        {
            return TestFramework.FindWebElement(this).Text;
        }

        public bool IsEnabled()
        {
            return TestFramework.FindWebElement(this).Enabled;
        }

        public bool IsDisplayed()
        {
            return TestFramework.FindWebElement(this).Displayed;
        }
        public void WaitLoad()
        {
            var element = TestFramework.FindWebElement(this);
            wait.Until(d => element.Displayed);
        }
    }
}
