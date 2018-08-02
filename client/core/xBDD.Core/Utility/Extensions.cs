using System.Text;

namespace xBDD.Utility
{
    public static class Extensions
    {
        
        public static string ConvertNamespaceToAreaName(this string text)
        {
            return text.AddSpacesToSentence(true).Replace(".", " - ");
        }
        public static string AddSpacesToSentence(this string text, bool preserveAcronyms)
        {
            text = text.Replace('_', ' ');
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            char? lastChar = null;
            for (int i = 1; i < text.Length; i++)
            {
                char currentChar = text[i];
                char? nextChar = null;
                if ((i+1) < text.Length)
                    nextChar = text[i + 1];
                var charIsUpperLetter = char.IsLetter(currentChar) && char.IsUpper(currentChar);
                //var nextCharIsNotUpperLetter = (nextChar.HasValue ? !(char.IsLetter(nextChar.Value) && char.IsUpper(nextChar.Value)) : false);
                //var lastCharIsNotAnUpperLetter = (lastChar.HasValue? !(char.IsLetter(lastChar.Value) && char.IsUpper(lastChar.Value)) : false);
                //var lastCharIsNotSpace = (lastChar.HasValue ? lastChar.Value != ' ' : true);
                var lastCharIsLowerLetter = (lastChar.HasValue ? char.IsLetter(lastChar.Value) && char.IsLower(lastChar.Value) : false);
                var lastCharIsUpperLetter = (lastChar.HasValue ? char.IsLetter(lastChar.Value) && char.IsUpper(lastChar.Value) : false);
                var nextCharIsLowerLetter = (nextChar.HasValue ? char.IsLetter(nextChar.Value) && char.IsLower(nextChar.Value) : false);

                var shouldAddSpace =
                    (lastCharIsLowerLetter && charIsUpperLetter) || //aB
                    (lastCharIsUpperLetter && charIsUpperLetter && nextCharIsLowerLetter);//BBa
                if (shouldAddSpace)
                    newText.Append(' ');

                newText.Append(text[i]);
                lastChar = currentChar;
            }
            return newText.ToString();
        }
    }
}
