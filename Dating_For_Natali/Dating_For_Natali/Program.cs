using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTests;

namespace Dating_For_Natali
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFramework.OpenURL("https://www.badoo.com");

            TestFramework.Delay(2);

            WebItems.SignInButton.Click();
            TestFramework.Delay(2);
            WebItems.LoginField.SetValue(ConfigurationManager.AppSettings["login"]);
            WebItems.PasswordField.SetValue(ConfigurationManager.AppSettings["password"]);
            WebItems.SubmitButton.Click();

            //TestFramework.Dispose();
        }
    }
}
