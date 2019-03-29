using SeleniumTests;
using System.Configuration;

namespace Dating_For_Natali
{
    public class DatingAction
    {
        public void InitializeSession()
        {
            TestFramework.OpenURL("https://www.badoo.com");

            TestFramework.Delay(2);
        }

        public void Login()
        {
            WebItems.SignInButton.Click();

            TestFramework.Delay(2);

            string login = ConfigurationManager.AppSettings["login"];
            string password = ConfigurationManager.AppSettings["password"];

            if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
            {
                WebItems.LoginField.SetValue(login);
                WebItems.PasswordField.SetValue(password);
                WebItems.SubmitButton.Click();
            }
            else
            {
                throw new ConfigurationErrorsException("Check config setting 'login' or 'password'");
            }
        }

        public void ParseProfile()
        {
            WebItems.PersonName.Click();
            string location = WebItems.PersonLocation.GetText();
            string configLocation = ConfigurationManager.AppSettings["Location"];
            bool flag = location.Contains(configLocation);

            string interest = WebItems.CountOfInterests.GetText();

            int countOfInterests;
            bool successed = int.TryParse(interest, out countOfInterests);

            // TODO:
            // 1. Parse profile. 
            // 2. Retrieve city info. You can use GetValue() method.
            // 3. Validate by city
        }
    }
}
