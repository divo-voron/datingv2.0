using SeleniumTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_For_Natali
{
   public static class WebItems
    {
        public static WebItem SignInButton
        {
            get
            {
                return new WebItem()
                {
                    ClassName = "js-signin-link"
                };
            }
        }

        public static WebItem LoginField
        {
            get
            {
                return new WebItem()
                {
                    ClassName = "js-signin-login"
                };
            }
        }
        public static WebItem PasswordField
        {
            get
            {
                return new WebItem()
                {
                    ClassName = "js-signin-password"
                };
            }
        }
        public static WebItem SubmitButton
        {
            get
            {
                return new WebItem()
                {
                    ClassName = "sign-form__submit"
                };
            }
        }

        public static WebItem PersonName
        {
            get
            {
                return new WebItem()
                {
                    ClassName = "js-profile-header-name"
                };
            }
        }

        public static WebItem PersonLocation
        {
            get
            {
                return new WebItem()
                {
                    ClassName = "js-location-label"
                };
            }
        }

        public static WebItem CountOfInterests
        {
            get
            {
                return new WebItem()
                {
                    ClassName = "js-interests-board"
                };
            }
        }
    }
}
