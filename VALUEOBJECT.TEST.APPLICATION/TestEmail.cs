using VALUEOBJECT.APPLICATION;
using Xunit;

namespace VALUEOBJECT.TEST.APPLICATION
{
    public sealed class TestEmail
    {
        const string EmailValid = "hao@asakura.com";
        const string EmailInvalid = "xyz.com";

        [Fact]
        public void ToTestValidEmail()
        {
            var emailObject = new EmailObject(EmailValid);

            Assert.True(emailObject.IsValid);
        }

        [Fact]
        public void ToTestInvalidEmail()
        {
            var emailObject = new EmailObject(EmailInvalid);

            Assert.False(emailObject.IsValid);
        }
    }
}