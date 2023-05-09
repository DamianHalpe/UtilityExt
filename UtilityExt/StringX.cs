using Newtonsoft.Json.Linq;
using System.Text;

namespace UtilityExt
{
    /// <summary>
    /// The string extension class.
    /// </summary>
    public static class StringX
    {
        /// <summary>
        /// Removes the special characters.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replaceSpaceWith">The value to replace spaces with.</param>
        /// <returns>A string.</returns>
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

        /// <summary>
        /// Truncate string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="limit">The character limit.</param>
        /// <param name="postfix">The postfix.</param>
        /// <param name="useLastSpace">If true, use last space.</param>
        /// <returns>A string.</returns>
        public static string Truncate(this string value, int limit, string postfix = "...", bool useLastSpace = false)
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

        /// <summary>
        /// Use provided string is current string is empty.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <param name="emptyValue">The empty value.</param>
        /// <returns>A string.</returns>
        public static string IfEmptyThen(this string inputString, string emptyValue)
        {
            return string.IsNullOrWhiteSpace(inputString) ? emptyValue : inputString;
        }

        /// <summary>
        /// Null if blank.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A string.</returns>
        public static string? NullIfBlank(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// The substring extension.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <param name="start">The start.</param>
        /// <param name="length">The length.</param>
        /// <returns>A string.</returns>
        public static string SubStringX(this string inputString, int start, int length)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return string.Empty;
            }

            if (inputString.Length < start + length)
            {
                return string.Empty;
            }

            return inputString.Substring(start, length);
        }

        /// <summary>
        /// Delimits the string.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <param name="splitAt">The split at.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns>A string.</returns>
        public static string DelimitString(this string inputString, int[] splitAt, string delimiter = "-")
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return "";
            }

            if (splitAt.Length == 0)
            {
                return inputString;
            }

            if (inputString.Length < splitAt.Sum())
            {
                return inputString;
            }

            var outputString = "";
            int startPosition = 0;
            foreach (var delimitPoint in splitAt)
            {
                outputString += inputString.Substring(startPosition, delimitPoint) + delimiter;
                startPosition += delimitPoint;
            }

            return outputString.Remove(outputString.Length - 1, 1);
        }

        /// <summary>
        /// Trims both ends of the string and replaces 
        /// one or more sequential white space characters
        /// within the string with a single space.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replaceWith">The replace with.</param>
        /// <returns>A string.</returns>
        public static string? TrimAll(this string value, string replaceWith = " ")
        {
            if (value == null)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            bool lastWasSpace = false;
            foreach (var ch in value.Trim())
            {
                if (char.IsWhiteSpace(ch))
                {
                    if (!lastWasSpace)
                    {
                        lastWasSpace = true;
                        sb.Append(replaceWith);
                    }
                }
                else
                {
                    lastWasSpace = false;
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Pad the string on the left.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="trim">If true, trim.</param>
        /// <returns>A string.</returns>
        public static string LeftPadding(this string? value, int length, bool trim = false)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty.PadLeft(length);
            }

            if (trim)
            {
                return value.PadLeft(length).Substring(0, length);
            }

            return value.PadLeft(length);
        }

        /// <summary>
        /// Pad the string on the left.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="padding">The padding.</param>
        /// <returns>A string.</returns>
        public static string LeftPadding(this string value, int length, Char padding)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new String(padding, length);
            }
            else if (value.Length > length)
            {
                return value.RightSubString(length);
            }

            return value.PadLeft(length, padding);
        }

        /// <summary>
        /// Pad the string on the right.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="trim">If true, trim.</param>
        /// <returns>A string.</returns>
        public static string RightPadding(this string? value, int length, bool trim = false)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty.PadRight(length);
            }

            if (trim)
            {
                return value.PadRight(length).Substring(0, length);
            }

            return value.PadRight(length);
        }

        /// <summary>
        /// The right sub string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <returns>A string.</returns>
        public static string RightSubString(this string value, int length)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value.PadLeft(length);
            }

            if (length > value.Length)
            {
                return value.PadLeft(length - value.Length);
            }
            
            return value.Substring(value.Length - length);
        }

        /// <summary>
        /// Strips out any non ASCII or control characters.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>A string.</returns>
        public static string ToSafeAScii(this string inputString)
        {
            var ascii = inputString.TrimAll()
                                   .Where(ch => ch < 128 && !char.IsControl(ch))
                                   .ToArray();

            return new string(ascii);
        }

        /// <summary>
        /// Whether the string contains valid JSON.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>A bool.</returns>
        public static bool IsValidJson(this string json)
        {
            try
            {
                JToken.Parse(json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the line breaks.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replaceWith">The replace with string.</param>
        /// <returns>A string.</returns>
        public static string RemoveLineBreaks(this string value, string replaceWith = " ")
        {
            if (value == null)
            {
                return value;
            }

            return value.Replace("\r\n", replaceWith)
                        .Replace("\n", replaceWith)
                        .Replace("\r", replaceWith)
                        .Replace("\u2029", replaceWith)
                        .Replace("\u2028", replaceWith);
        }
    }
}