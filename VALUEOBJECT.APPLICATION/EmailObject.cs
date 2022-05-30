using VALUEOBJECT.APPLICATION.HELPERS.EXTENSION;
using VALUEOBJECT.APPLICATION.INTERFACES;

namespace VALUEOBJECT.APPLICATION
{
    public sealed class EmailObject : IEmail
    {
        public EmailObject(string emailObject)
        {
            if (!emailObject.IsFilled())
                return; 

            Email = emailObject.Trim();
            IsValid = ValidateEmail();
        }

        public string Email { get; private set; } = string.Empty;
        public bool IsValid { get; private set; }

        private bool ValidateEmail()
        {
            if (!Email.Contains("@"))
                return false;

            if (Email.Length < 3)
                return false;

            return true;
        }
    }
}
