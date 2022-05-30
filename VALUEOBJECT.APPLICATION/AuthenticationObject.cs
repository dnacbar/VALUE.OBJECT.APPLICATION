using System.Text.RegularExpressions;
using VALUEOBJECT.APPLICATION.HELPERS.ENUM;
using VALUEOBJECT.APPLICATION.INTERFACES;

namespace VALUEOBJECT.APPLICATION
{
    public sealed class AuthenticationObject : IAuthenticationObject
    {
        public AuthenticationObject(object authenticationObject, EnumAuthenticationType enumAuthenticationType = EnumAuthenticationType.Password)
        {
            if (authenticationObject == null)
                return;

            Authentication = authenticationObject;
            EnumAuthenticationType = enumAuthenticationType;

            if (EnumAuthenticationType == EnumAuthenticationType.Password)
            {
                PasswordAuthentication.Password = authenticationObject.ToString();
                IsValid = PasswordAuthentication.IsValid;
            }
            else if (EnumAuthenticationType == EnumAuthenticationType.Numeric)
            {
                NumericAuthentication.Numeric = authenticationObject.ToString();
                IsValid = NumericAuthentication.IsValid;
            }
        }

        public object Authentication { get; } = null!;
        public bool IsValid { get; private set; }
        public EnumAuthenticationType EnumAuthenticationType { get; private set; }

        private static class PasswordAuthentication
        {
            public static string Password
            {
                get { return password; }
                set
                {
                    password = value;
                    Validate();
                }
            }
            public static bool IsValid { get; private set; }

            private static string password = string.Empty;

            private static void Validate()
            {
                IsValid = Regex.Match(Password.ToString(), @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,25}$").Success;
            }
        }

        private static class NumericAuthentication
        {
            public static string Numeric
            {
                get { return numeric; }
                set
                {
                    Numeric = value;
                    Validate();
                }
            }
            public static bool IsValid { get; private set; }

            private static string numeric = string.Empty;

            private static void Validate()
            {
                IsValid = Numeric.Length < 8 || Numeric.Length > 12;
            }
        }
    }
}
