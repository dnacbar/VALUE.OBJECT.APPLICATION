using VALUEOBJECT.APPLICATION.HELPERS.ENUM;
using VALUEOBJECT.APPLICATION.HELPERS.EXTENSION;
using VALUEOBJECT.APPLICATION.INTERFACES;

namespace VALUEOBJECT.APPLICATION
{
    public sealed class DocumentObject : IDocument
    {
        public DocumentObject(string documentObject)
        {
            if (!documentObject.IsFilled() || !documentObject.IsNumber())
                return;

            Document = documentObject.Trim();

            if (!Validates())
                return;

            if (Document.Length == 11)
            {
                NaturalPersonDocument.Document = Document;
                IsValid = NaturalPersonDocument.IsValid;
                DocumentFormatted = NaturalPersonDocument.DocumentFormatted;
                EnumDocumentType = IsValid ? EnumDocumentType.NaturalPerson : EnumDocumentType.Invalid;
            }
            else
            {
                JuridicalPersonDocument.Document = Document;
                IsValid = JuridicalPersonDocument.IsValid;
                DocumentFormatted = JuridicalPersonDocument.DocumentFormatted;
                EnumDocumentType = IsValid ? EnumDocumentType.JuridicalPerson : EnumDocumentType.Invalid;
            }
        }

        public string Document { get; } = string.Empty;
        public string DocumentFormatted { get; } = string.Empty;
        public bool IsValid { get; private set; }
        public EnumDocumentType EnumDocumentType { get; }

        public bool Validates()
        {
            return Document.Length == 11 || Document.Length == 14;
        }

        private static class NaturalPersonDocument
        {
            public static string Document
            {
                get { return document; }
                set
                {
                    document = value;
                    IsValid = Validates();
                    FormatsDocument();
                }
            }
            public static string DocumentFormatted { get; private set; } = string.Empty;
            public static bool IsValid { get; private set; }

            private static string document = string.Empty;

            private static void FormatsDocument()
            {
                DocumentFormatted = Document.Substring(0, 3) + "." + Document.Substring(3, 3) + "." + Document.Substring(6, 3) + "-" + Document.Substring(9, 2);
            }
            private static bool Validates()
            {
                int[] validator1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] validator2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                int sumDocument, restOfDivision;
                string documentDigit, tempDocument;

                tempDocument = Document.Substring(0, 9);
                sumDocument = 0;

                for (int i = 0; i < 9; i++)
                    sumDocument += int.Parse(tempDocument[i].ToString()) * validator1[i];

                restOfDivision = sumDocument % 11;

                if (restOfDivision < 2)
                    restOfDivision = 0;
                else
                    restOfDivision = 11 - restOfDivision;

                documentDigit = restOfDivision.ToString();
                tempDocument += documentDigit;

                sumDocument = 0;

                for (int i = 0; i < 10; i++)
                    sumDocument += int.Parse(tempDocument[i].ToString()) * validator2[i];

                restOfDivision = sumDocument % 11;

                if (restOfDivision < 2)
                    restOfDivision = 0;
                else
                    restOfDivision = 11 - restOfDivision;

                documentDigit += restOfDivision.ToString();

                return Document.EndsWith(documentDigit);
            }
        }

        private static class JuridicalPersonDocument
        {
            public static string Document
            {
                get { return document; }
                set
                {
                    document = value;
                    IsValid = Validates();
                    FormatsDocument();
                }
            }
            public static string DocumentFormatted { get; private set; } = string.Empty;
            public static bool IsValid { get; private set; }

            private static string document = string.Empty;

            private static void FormatsDocument()
            {
                DocumentFormatted = Document.Substring(0, 3) + "." + Document.Substring(3, 3) + "." + Document.Substring(6, 3) + "-" + Document.Substring(9, 2);
            }
            private static bool Validates()
            {
                int[] validator1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] validator2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                int sumDocument, restOfDivision;
                string digitDocument, tempDocument;

                tempDocument = Document.Substring(0, 12);
                sumDocument = 0;

                for (int i = 0; i < 12; i++)
                    sumDocument += int.Parse(tempDocument[i].ToString()) * validator1[i];

                restOfDivision = (sumDocument % 11);

                if (restOfDivision < 2)
                    restOfDivision = 0;
                else
                    restOfDivision = 11 - restOfDivision;

                digitDocument = restOfDivision.ToString();

                tempDocument += digitDocument;

                sumDocument = 0;

                for (int i = 0; i < 13; i++)
                    sumDocument += int.Parse(tempDocument[i].ToString()) * validator2[i];

                restOfDivision = (sumDocument % 11);

                if (restOfDivision < 2)
                    restOfDivision = 0;
                else
                    restOfDivision = 11 - restOfDivision;

                digitDocument += restOfDivision.ToString();

                return Document.EndsWith(digitDocument);
            }
        }
    }
}
