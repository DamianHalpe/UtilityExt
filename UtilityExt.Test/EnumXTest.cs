using UtilityExt.Test.TestClasses;

namespace UtilityExt.Test
{
    [TestClass]
    public class EnumXTest
    {
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
