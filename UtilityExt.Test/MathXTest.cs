namespace UtilityExt.Test
{
    /// <summary>
    /// The math extension test class.
    /// </summary>
    [TestClass]
    public class MathXTest
    {
        /// <summary>
        /// Tests the zero if null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="checkValue">The check value.</param>
        [DataTestMethod]
        [DataRow(null, 0)]
        [DataRow(double.MinValue, double.MinValue)]
        [DataRow(double.MaxValue, double.MaxValue)]
        public void TestZeroIfNull(double? value, double checkValue)
        {
            var returnValue = value.ZeroIfNull();
            Assert.AreEqual(checkValue, returnValue);
        }

        /// <summary>
        /// Tests the round decimals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="decimals">The decimals.</param>
        /// <param name="checkValue">The check value.</param>
        [DataTestMethod]
        [DataRow(100.011, 2, "100.01")]
        [DataRow(100.011, 0, "100")]
        [DataRow(100.010, 3, "100.010")]
        [DataRow(null, 3, null)]
        public void TestRoundDecimals(double? value, int decimals, string checkValue)
        {
            var returnValue = value.RoundDecimals(decimals);
            if (checkValue == null)
            {
                Assert.AreEqual(null, returnValue);
            }
            else
            {
                if (decimal.TryParse(checkValue, out decimal checkVal))
                Assert.AreEqual(returnValue, checkVal);
            }
        }

        /// <summary>
        /// Tests the add doubles.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="checkValue">The check value.</param>
        [DataTestMethod]
        [DataRow(100.11, 100.02, "200.13")]
        [DataRow(100.0, 100.02, "200.02")]
        [DataRow(100.01, 100.0, "200.01")]
        [DataRow(100.01, null, "100.01")]
        [DataRow(null, 200.01, "200.01")]
        [DataRow(null, null, "0")]
        public void TestAddDoubles(double? value1, double? value2, string checkValue)
        {
            var returnValue = MathX.AddDoubles(value1, value2);
            if (decimal.TryParse(checkValue, out decimal checkVal))
                Assert.AreEqual(checkVal, returnValue);
        }

        /// <summary>
        /// Tests the inverse value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="roundTo">The round to.</param>
        /// <param name="checkValue">The check value.</param>
        [DataTestMethod]
        [DataRow(10.0, 2, "0.10")]
        [DataRow(100.0, 3, "0.010")]
        [DataRow(3.0, 3, "0.333")]
        [DataRow(null, 2, null)]
        public void TestInverseValue(double? value, int roundTo,  string checkValue)
        {
            var returnValue = MathX.InverseValue(value, roundTo);
            if (checkValue == null)
            {
                Assert.AreEqual(null, returnValue);
            }
            else
            {
                if (decimal.TryParse(checkValue, out decimal checkVal))
                    Assert.AreEqual(returnValue, checkVal);
            }
        }

        /// <summary>
        /// Tests the add integers.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="checkValue">The check value.</param>
        [DataTestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(null, 2, 2)]
        [DataRow(2, null, 2)]
        [DataRow(null, null, null)]
        public void TestAddInts(int? value1, int? value2, int? checkValue)
        {
            var returnValue = MathX.AddInts(value1, value2);
            Assert.AreEqual(checkValue, returnValue);
        }

        /// <summary>
        /// Tests the sum doubles.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="value3">The value3.</param>
        /// <param name="checkValue">The check value.</param>
        [DataTestMethod]
        [DataRow(new double[] { 1.0, 2.0, 3.0 } , "6.0")]
        [DataRow(new double[] { 1.0, 2.0, double.NegativeInfinity }, "3.0")]
        [DataRow(new double[] { double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity }, "0.0")]
        public void TestSumDoubles(double[] values, string checkValue)
        {
            var array = new List<double?>();
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == double.NegativeInfinity)
                {
                    array.Add(null);
                }
                else
                {
                    array.Add(values[i]);
                }
            }

            var returnValue = array.SumDoubles();
            if (decimal.TryParse(checkValue, out decimal checkVal))
                Assert.AreEqual(returnValue, checkVal);
        }
    }
}
