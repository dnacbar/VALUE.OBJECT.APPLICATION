using VALUEOBJECT.APPLICATION.HELPERS.EXTENSION;
using VALUEOBJECT.APPLICATION.INTERFACES;

namespace VALUEOBJECT.APPLICATION
{
    public sealed class PhoneObject : IPhone
    {
        public PhoneObject(string phoneObject)
        {
            if (!phoneObject.IsFilled())
                return;

            Phone = phoneObject.Trim();
            IsValid = Validate();
        }

        public string Phone { get; private set; } = string.Empty;
        public bool IsValid {get; private set; }

        private bool Validate()
        {
            if (Phone.Length != 11)
                return false;

            if (!Phone.IsNumber())
                return false;

            return true;
        }
    }
}
