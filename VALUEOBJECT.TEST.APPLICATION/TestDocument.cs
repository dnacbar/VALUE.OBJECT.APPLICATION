using VALUEOBJECT.APPLICATION;
using VALUEOBJECT.APPLICATION.HELPERS.ENUM;
using Xunit;

namespace VALUEOBJECT.TEST.APPLICATION
{
    public sealed class TestDocument
    {
        const string NaturalPerson = "41841060801";
        const string JuridicalPerson = "50595326000187";

        const string NaturalPersonInvalid = "41841060821";
        const string JuridicalPersonInvalid = "50595326000188";

        [Fact]
        public void ToTestNaturalPerson()
        {
            var documentObject = new DocumentObject(NaturalPerson);

            Assert.True(documentObject.IsValid);
            Assert.True(documentObject.EnumDocumentType == EnumDocumentType.NaturalPerson);
        }

        [Fact]
        public void ToTestJuridicalPerson()
        {
            var documentObject = new DocumentObject(JuridicalPerson);

            Assert.True(documentObject.IsValid);
            Assert.True(documentObject.EnumDocumentType == EnumDocumentType.JuridicalPerson);
        }

        [Fact]
        public void ToTestNaturalPersonInvalid()
        {
            var documentObject = new DocumentObject(NaturalPersonInvalid);

            Assert.False(documentObject.IsValid);
            Assert.True(documentObject.EnumDocumentType == EnumDocumentType.Invalid);
        }


        [Fact]
        public void ToTestJuridicalPersonInvalid()
        {
            var documentObject = new DocumentObject(JuridicalPersonInvalid);

            Assert.False(documentObject.IsValid);
            Assert.True(documentObject.EnumDocumentType == EnumDocumentType.Invalid);
        }

    }
}