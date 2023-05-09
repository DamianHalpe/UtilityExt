using System.Text;

namespace UtilityExt
{
    public static class StringX
    {
        public static string RemoveSpecialCharacters(this string? value, string replaceSpaceWith = "")
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(value)) return "";
            foreach (char c in value)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
                else if (c == ' ')
                {
                    sb.Append(replaceSpaceWith);
                }
            }

            return sb.ToString();
        }

        public static string LimitTo(this string value, int limit, string postfix = "...", bool useLastSpace = false)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Length < limit) return value;

            var limited = value.Substring(0, limit);
            if (useLastSpace)
            {
                var lastSpaceIndex = limited.LastIndexOf(' ');
                if (lastSpaceIndex > 0)
                {
                    limited = limited.Substring(0, lastSpaceIndex);
                }
            }

            return $"{limited}{postfix}";
        }
    }
}