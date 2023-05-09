using UtilityExt;

namespace UtilityExt.Test
{
    [TestClass]
    public class StringXTest
    {
        [DataTestMethod]
        [DataRow(null, "_", "")]
        [DataRow("", "_", "")]
        [DataRow("asc$test.txt", "", "asctest.txt")]
        [DataRow("asc test.txt", "", "asctest.txt")]
        [DataRow("asc test.txt", "_", "asc_test.txt")]
        [DataRow("asc!@#$%^&*() test.txt", "_", "asc_test.txt")]
        public void TestStringSpecialChars(string? value, string replaceSpaces, string assertValue)
        {
            var replaced = value.RemoveSpecialCharacters(replaceSpaces);
            Assert.AreEqual(replaced, assertValue);
        }

        [DataTestMethod]
        [DataRow("", 10, "", false, "")]
        [DataRow("abc def ghi jkl", 10, "...", false, "abc def gh...")]
        [DataRow("abc def ghi jkl", 10, "...", true, "abc def...")]
        public void TestStringLimit(string value, int limit, string postfix, bool useLastSpace, string assertValue)
        {
            var limited = value.LimitTo(limit, postfix, useLastSpace);
            Assert.AreEqual(limited, assertValue);
        }
    }
}