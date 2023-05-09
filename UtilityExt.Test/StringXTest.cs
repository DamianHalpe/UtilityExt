using UtilityExt;

namespace UtilityExt.Test
{
    /// <summary>
    /// The string extension test class.
    /// </summary>
    [TestClass]
    public class StringXTest
    {
        /// <summary>
        /// Tests the remove special character function.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replaceSpaces">The replace spaces.</param>
        /// <param name="expected">The assert value.</param>
        [DataTestMethod]
        [DataRow(null, "_", "")]
        [DataRow("", "_", "")]
        [DataRow("asc$test.txt", "", "asctest.txt")]
        [DataRow("asc test.txt", "", "asctest.txt")]
        [DataRow("asc test.txt", "_", "asc_test.txt")]
        [DataRow("asc!@#$%^&*() test.txt", "_", "asc_test.txt")]
        public void TestStringSpecialChars(string? value, string replaceSpaces, string expected)
        {
            var replaced = value.RemoveSpecialCharacters(replaceSpaces);
            Assert.AreEqual(replaced, expected);
        }

        /// <summary>
        /// Tests the truncate function.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="postfix">The postfix.</param>
        /// <param name="useLastSpace">If true, use last space.</param>
        /// <param name="expected">The assert value.</param>
        [DataTestMethod]
        [DataRow("", 10, "", false, "")]
        [DataRow("abc def ghi jkl", 10, "...", false, "abc def gh...")]
        [DataRow("abc def ghi jkl", 10, "...", true, "abc def...")]
        public void TestTruncate(string value, int limit, string postfix, bool useLastSpace, string expected)
        {
            var limited = value.Truncate(limit, postfix, useLastSpace);
            Assert.AreEqual(limited, expected);
        }

        /// <summary>
        /// Tests the if empty then function.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="emptyValue">The empty value.</param>
        /// <param name="expected">The assert value.</param>
        [DataTestMethod]
        [DataRow("test", "blank", "test")]
        [DataRow("", "blank", "blank")]
        [DataRow(null, "blank", "blank")]
        public void TestIfEmptyThen(string value, string emptyValue, string expected)
        {
            var returnValue = value.IfEmptyThen(emptyValue);
            Assert.AreEqual(returnValue, expected);
        }

        /// <summary>
        /// Tests the null if blank.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="expected">The expected.</param>
        [DataTestMethod]
        [DataRow("AAA", "AAA")]
        [DataRow("", null)]
        public void TestNullIfBlank(string value, string expected)
        {
            var returnValue = value.NullIfBlank();
            Assert.AreEqual(returnValue, expected);
        }

        /// <summary>
        /// Tests the substring extension function.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="start">The start.</param>
        /// <param name="length">The length.</param>
        /// <param name="expected">The assert value.</param>
        [DataTestMethod]
        [DataRow("/x:AAA/x:BBB", 3 , 3, "AAA")]
        [DataRow("/x:AAA/x:BBB", 12, 1, "")]
        public void TestSubStringX(string value, int start, int length, string expected)
        {
            var returnValue = value.SubStringX(start, length);
            Assert.AreEqual(returnValue, expected);
        }

        /// <summary>
        /// Tests the delimit string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="split">The split.</param>.
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="expected">The assert value.</param>
        [DataTestMethod]
        [DataRow("ABCDEF", new int[] { 2, 2, 2 }, "-", "AB-CD-EF")]
        [DataRow("ABCDEF", new int[] { 2, 2, 2, 2 }, "-", "ABCDEF")]
        public void TestDelimitString(string value, int[] split, string delimiter, string expected)
        {
            var returnValue = value.DelimitString(split, delimiter);
            Assert.AreEqual(returnValue, expected);
        }

        /// <summary>
        /// Tests the to safe ASCII.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="expected">The expected.</param>
        [DataTestMethod]
        [DataRow("This is ascii", "This is ascii")]
        [DataRow("ʣʥɶɸɾʈɞȢȕȊǰǱď@", "@")]
        [DataRow("@ `!Aa\"Bb#Cc$Dd%Ee&Ff'Gg(Hh)Ii*Jj+Kk,Ll-Mm.Nn/Oo0Pp1Qq2Rr3Ss4Tt5Uu6Vv7Ww8Xx9Yy:Zz;[{<\\|=]}>^~?", "@ `!Aa\"Bb#Cc$Dd%Ee&Ff'Gg(Hh)Ii*Jj+Kk,Ll-Mm.Nn/Oo0Pp1Qq2Rr3Ss4Tt5Uu6Vv7Ww8Xx9Yy:Zz;[{<\\|=]}>^~?")]
        public void TestToSafeAScii(string value, string expected)
        {
            var returnValue = value.ToSafeAScii();
            Assert.AreEqual(returnValue, expected);
        }

        /// <summary>
        /// Tests the remove line breaks.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replace">The replace.</param>
        /// <param name="expected">The expected.</param>
        [DataTestMethod]
        [DataRow("This is a string", " ", "This is a string")]
        [DataRow("This\r\nis\ra\nstring", " ", "This is a string")]
        public void TestRemoveLineBreaks(string value, string replace, string expected)
        {
            var returnValue = value.RemoveLineBreaks(replace);
            Assert.AreEqual(returnValue, expected);
        }

        /// <summary>
        /// Tests the trim all.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replace">The replace.</param>
        /// <param name="expected">The expected.</param>
        [DataTestMethod]
        [DataRow("Test the trim  function", "", "Testthetrimfunction")]
        [DataRow("Test the trim\rfunction", "_", "Test_the_trim_function")]
        [DataRow("Test the trim\nfunction", "-", "Test-the-trim-function")]
        [DataRow("Test the trim\r\nfunction", "  ", "Test  the  trim  function")]
        [DataRow(" Test the trim  function", "\r\n", "Test\r\nthe\r\ntrim\r\nfunction")]
        public void TestTrimAll(string value, string replace, string expected) 
        { 
            var returnValue = value.TrimAll(replace);
            Assert.AreEqual(returnValue, expected);
        }

        /// <summary>
        /// Tests the right padding.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="trim">If true, trim.</param>
        /// <param name="expected">The expected.</param>
        [DataTestMethod]
        [DataRow("", 4, false, "    ")]
        [DataRow("ABCDEF", 8, true, "ABCDEF  ")]
        [DataRow("ABCDEF", 4, true, "ABCD")]
        public void TestRightPadding(string value, int length, bool trim, string expected)
        {
            var returnValue = value.RightPadding(length, trim);
            Assert.AreEqual(returnValue, expected);
        }

        /// <summary>
        /// Tests the right sub string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="expected">The expected.</param>
        [DataTestMethod]
        [DataRow("ABCDEFG", 4, "DEFG")]
        [DataRow("ABCD", 8, "ABCD")]
        public void TestRightSubString(string value, int length, string expected)
        {
            var returnValue = value.RightSubString(length);
            Assert.AreEqual(returnValue, expected);
        }

        /// <summary>
        /// Tests the left padding.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lenght">The lenght.</param>
        /// <param name="padding">The padding.</param>
        /// <param name="expected">The expected.</param>
        [DataTestMethod]
        [DataRow("ABCD", 6, "-", "--ABCD")]
        [DataRow("ABCD", 2, "-", "CD")]
        public void TestLeftPadding(string value, int lenght, string padding, string expected)
        {
            var returnValue = value.LeftPadding(lenght, Char.Parse(padding));
            Assert.AreEqual(returnValue, expected);
        }
    }
}