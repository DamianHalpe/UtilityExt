using UtilityExt.Test.TestClasses;

namespace UtilityExt.Test
{
    /// <summary>
    /// The enum extension test class.
    /// </summary>
    [TestClass]
    public class EnumXTest
    {
        /// <summary>
        /// Tests the enum display name.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <param name="assertValue">The assert value.</param>
        [DataTestMethod]
        [DataRow(DisplayEnumType.First, "First Value")]
        [DataRow(DisplayEnumType.Third, "Third")]
        public void TestEnumDisplayName(DisplayEnumType enumValue, string assertValue)
        {
            var displayName = enumValue.GetDisplayName();
            Assert.AreEqual(displayName, assertValue);
        }
    }
}
