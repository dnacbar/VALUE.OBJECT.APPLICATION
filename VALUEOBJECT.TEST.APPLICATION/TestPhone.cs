using VALUEOBJECT.APPLICATION;
using Xunit;

namespace VALUEOBJECT.TEST.APPLICATION
{
    public sealed class TestPhone
    {
        const string ValidPhone = "11949310477";
        const string InvalidPhone = "1A949310477";

        [Fact]
        public void ToTestValidPhone()
        {
            var phoneObject = new PhoneObject(ValidPhone);

            Assert.True(phoneObject.IsValid);
        }

        [Fact]
        public void ToTestInvalidPhone()
        {
            var phoneObject = new PhoneObject(InvalidPhone);

            Assert.False(phoneObject.IsValid);
        }
    }
}