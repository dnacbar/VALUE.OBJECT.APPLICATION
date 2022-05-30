namespace VALUEOBJECT.APPLICATION.HELPERS.EXTENSION
{
    public static class ExtensionString
    {
        public static bool IsNumber(this string strValue)
        {
            return strValue.All(x => int.TryParse(x.ToString(), out _));
        }

        public static bool IsOnlyText(this string strValue)
        {
            return strValue.All(char.IsLetter);
        }

        public static bool IsOnlyTextAndNumber(this string strValue)
        {
            return strValue.All(char.IsLetterOrDigit);
        }

        public static string RemoveSpecialCharacter(this string strValue)
        {
            var strResult = string.Empty;

            foreach (var item in strValue)
            {
                if (char.IsNumber(item) || char.IsLetter(item))
                    strResult += item;
            }

            return strResult;
        }

        public static bool IsFilled(this string strValue)
        {
            return !string.IsNullOrEmpty(strValue) && !string.IsNullOrWhiteSpace(strValue);
        }
    }
}
