namespace VALUEOBJECT.APPLICATION.INTERFACES
{
    public interface IAuthentication
    {
        bool IsValid { get; }
        object AuthenticationObject { get; }
    }
}
