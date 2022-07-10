using System;
using System.Collections.Generic;
using VALUEOBJECT.APPLICATION;
using Xunit;

namespace VALUEOBJECT.TEST.APPLICATION
{
    public sealed class TestAuthenticatesNumeric
    {
        public static IEnumerable<AuthenticatesObject[]> ListOfValidNumericAuth()
        {

            yield return new[] { new AuthenticatesObject(new NumericAuthentication("019256")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("303030")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("880088")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("091827")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("908010")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("823921")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("784519")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("266588")) };
        }

        public static IEnumerable<AuthenticatesObject[]> ListOfInvalidNumericAuth()
        {
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("123456")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("987654")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("123692")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("765444")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("998700")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("159678")) };
        }

        public static IEnumerable<AuthenticatesObject[]> ListOfInvalidNumericAuthWithNoSixNumbers()
        {
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("159")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("48572814")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("8")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("02669359")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("0266937")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication(string.Empty)) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication(null)) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("ABC")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("051oito")) };
            yield return new[] { new AuthenticatesObject(new NumericAuthentication("NOVENTA90")) };
        }

        [Fact]
        public void ToTestPasswordValid()
        {
            foreach (var item in ListOfValidNumericAuth())
            {
                Assert.True(item[0].IsValid);
            }
        }

        [Fact]
        public void ToTestPasswordInvalid()
        {
            foreach (var item in ListOfInvalidNumericAuth())
            {
                Assert.False(item[0].IsValid);
            }
        }

        [Fact]
        public void ToTestPasswordInvalidWithNoSixNumbers()
        {
            foreach (var item in ListOfInvalidNumericAuthWithNoSixNumbers())
            {
                Assert.False(item[0].IsValid);
            }
        }
    }
}