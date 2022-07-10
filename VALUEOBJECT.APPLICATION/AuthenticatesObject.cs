using System.Text.RegularExpressions;
using VALUEOBJECT.APPLICATION.HELPERS.EXTENSION;
using VALUEOBJECT.APPLICATION.INTERFACES;

namespace VALUEOBJECT.APPLICATION
{
    public struct AuthenticatesObject : IAuthenticatesObject
    {
        public AuthenticatesObject(IAuthentication authentication)
        {
            if (authentication.AuthenticationObject == null)
                return;


            IsValid = authentication.IsValid;
        }

        public bool IsValid { get; private set; } = false;
    }

    public struct PasswordAuthentication : IAuthentication
    {
        public PasswordAuthentication(string passwordObject, Regex regexObject)
        {
            if (!passwordObject.IsFilled())
                return;

            Regex = regexObject;
            AuthenticationObject = passwordObject;
        }

        public object AuthenticationObject
        {
            get { return password; }
            private set
            {
                password = (string)value;
                Validates();
            }
        }

        public bool IsValid { get; private set; } = false;

        private Regex Regex { get; set; } = null!;

        private string password = string.Empty;

        private void Validates()
        {
            IsValid = Regex.IsMatch(AuthenticationObject.ToString());
        }
    }

    public struct NumericAuthentication : IAuthentication
    {
        public NumericAuthentication(string numericObject = "000000")
        {
            if (string.IsNullOrEmpty(numericObject) || numericObject.Length != 6 || !int.TryParse(numericObject, out int _))
                return;

            AuthenticationObject = numericObject;
        }

        public object AuthenticationObject
        {
            get { return numeric; }
            private set
            {
                numeric = (string)value;
                Validates();
            }
        }

        public bool IsValid { get; private set; } = false;

        private string numeric = "00000";

        private void Validates()
        {
            string numberObject = AuthenticationObject.ToString();
            var listSequentialNumber = new List<string>();

            for (int i = 0; i <= 9; i++)
            {
                if (ValidatesEqualsNumber(i))
                {
                    IsValid = false;
                    return;
                }

                if (i < 5)
                {
                    listSequentialNumber.Add(ValidatesSequentialNumber(numberObject, i));

                    if (i >= 1)
                    {
                        if (listSequentialNumber[i] == listSequentialNumber[i - 1])
                        {
                            if (listSequentialNumber[i] == string.Empty)
                                continue;

                            IsValid = false;
                            return;
                        }
                    }
                }
            }
            IsValid = true;
        }

        private bool ValidatesEqualsNumber(int i)
        {
            if (AuthenticationObject.ToString() == "".PadRight(6, (char)i))
                return true;

            return false;
        }

        private string ValidatesSequentialNumber(string numberObject, int i)
        {
            if (numberObject[i] + 1 == numberObject[i + 1])
            {
                return "ASC";
            }
            else if (numberObject[i] - 1 == numberObject[i + 1])
            {
                return "DESC";
            }
            else
                return string.Empty;
        }
    }
}
