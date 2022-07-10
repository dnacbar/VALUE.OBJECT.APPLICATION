using System.Collections.Generic;
using System.Text.RegularExpressions;
using VALUEOBJECT.APPLICATION;
using Xunit;

namespace VALUEOBJECT.TEST.APPLICATION
{
    public sealed class TestAuthenticatesPassword
    {
        const string regexPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,25}$";
        public static IEnumerable<AuthenticatesObject[]> ListOfValidPasswordAuth()
        {
            var regexObject = new Regex(regexPattern);

            yield return new[] { new AuthenticatesObject(new PasswordAuthentication(".,deatH91835bAk", regexObject)) };
            yield return new[] { new AuthenticatesObject(new PasswordAuthentication("[{!.,<Dunk>012345<hAk>}]", regexObject)) };
            yield return new[] { new AuthenticatesObject(new PasswordAuthentication("<ddelomnsebTa80/>", regexObject)) };
            yield return new[] { new AuthenticatesObject(new PasswordAuthentication("~ÇigKrm1d4t#eg0()", regexObject)) };
            yield return new[] { new AuthenticatesObject(new PasswordAuthentication("Oit7Wb!@#9wbe7AX$_7Bt", regexObject)) };
        }

        public static IEnumerable<AuthenticatesObject[]> ListOfInvalidPasswordAuth()
        {
            var regexObject = new Regex(regexPattern);

            yield return new[] { new AuthenticatesObject(new PasswordAuthentication(".d3HbAk", regexObject)) };
            yield return new[] { new AuthenticatesObject(new PasswordAuthentication("[{!.,<Dunk>82-10-92<hAk>}]", regexObject)) };
            yield return new[] { new AuthenticatesObject(new PasswordAuthentication("essaSenhaEhMuitoFort3", regexObject)) };
            yield return new[] { new AuthenticatesObject(new PasswordAuthentication("<30-04-1992/>", regexObject)) };
            yield return new[] { new AuthenticatesObject(new PasswordAuthentication("OitWD0bem", regexObject)) };
            yield return new[] { new AuthenticatesObject(new PasswordAuthentication("ChuX00PanaAzedaL3g4uAmigo", regexObject)) };
        }

        [Fact]
        public void ToTestPasswordValid()
        {
            foreach (var item in ListOfValidPasswordAuth())
            {
                Assert.True(item[0].IsValid);
            }
        }

        [Fact]
        public void ToTestPasswordInvalid()
        {
            var isValid = new AuthenticatesObject(new PasswordAuthentication("ChuX00PanaAzedaL3g4uAmigo", new Regex(regexPattern))).IsValid;
            Assert.False(isValid);
        }
    }
}