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

        [Theory]
        [MemberData(nameof(ListOfValidNumericAuth))]
        public void ToTestPasswordValid(AuthenticatesObject authenticatesObject)
        {
            Assert.True(authenticatesObject.IsValid);
        }

        [Theory]
        [MemberData(nameof(ListOfInvalidNumericAuth))]
        public void ToTestPasswordInvalid(AuthenticatesObject authenticatesObject)
        {
            Assert.False(authenticatesObject.IsValid);
        }

        [Theory]
        [MemberData(nameof(ListOfInvalidNumericAuthWithNoSixNumbers))]
        public void ToTestPasswordInvalidWithNoSixNumbers(AuthenticatesObject authenticatesObject)
        {
            Assert.False(authenticatesObject.IsValid);
        }
    }
}