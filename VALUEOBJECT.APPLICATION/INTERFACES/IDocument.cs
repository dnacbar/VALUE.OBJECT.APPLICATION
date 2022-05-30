using VALUEOBJECT.APPLICATION.HELPERS.ENUM;

namespace VALUEOBJECT.APPLICATION.INTERFACES
{
    internal interface IDocument : IValueObject
    {
        public string Document { get; }
        public string DocumentFormatted { get; }
        public EnumDocumentType EnumDocumentType { get; }
    }
}
