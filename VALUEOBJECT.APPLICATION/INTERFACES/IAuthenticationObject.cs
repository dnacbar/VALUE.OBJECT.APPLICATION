using VALUEOBJECT.APPLICATION.HELPERS.ENUM;

namespace VALUEOBJECT.APPLICATION.INTERFACES
{
    public interface IAuthenticationObject : IValueObject
    {
        object Authentication { get; }
        EnumAuthenticationType EnumAuthenticationType { get; }
    }
}
