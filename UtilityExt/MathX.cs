namespace UtilityExt
{
    /// <summary>
    /// The math extension class.
    /// </summary>
    public static class MathX
    {
        /// <summary>
        /// Return zero if null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A double.</returns>
        public static double ZeroIfNull(this double? value)
        {
            return value ?? 0;
        }

        /// <summary>
        /// Rounds the decimals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="decimals">The decimals.</param>
        /// <returns>A decimal? .</returns>
        public static decimal? RoundDecimals(this double? value, int decimals)
        {
            if (value != null) return RoundDecimals((double)value, decimals);
            return null;
        }

        /// <summary>
        /// Rounds the decimals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="decimals">The decimals.</param>
        /// <returns>A decimal? .</returns>
        public static decimal? RoundDecimals(this double value, int decimals)
        {
            if (!double.IsInfinity(value)) return Math.Round((decimal)value, decimals);
            return null;
        }

        /// <summary>
        /// Formats the decimals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <returns>A string? .</returns>
        public static string? FormatDecimals(this decimal? value, string format)
        {
            if (value != null) return ((decimal)value).ToString(format);
            return null;
        }

        /// <summary>
        /// Adds the doubles.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>A decimal.</returns>
        public static decimal AddDoubles(double? value1, double? value2)
        {
            var double1 = value1.ZeroIfNull();
            var double2 = value2.ZeroIfNull();
            if (double.IsInfinity(double1)) double1 = 0;
            if (double.IsInfinity(double2)) double2 = 0;
            return (decimal)double1 + (decimal)double2;
        }

        /// <summary>
        /// Rounds up double value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="decimals">The decimals.</param>
        /// <returns>A double? .</returns>
        public static double? s(this double? value, int decimals)
        {
            var result = RoundDouble(value, decimals);
            if (result != null && result < value) result = Convert.ToDouble(AddDoubles(result, Math.Pow(10, -decimals)));
            return result;
        }

        /// <summary>
        /// Rounds the double value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="decimals">The decimals.</param>
        /// <returns>A double? .</returns>
        public static double? RoundDouble(this double? value, int decimals)
        {
            var result = value.RoundDecimals(decimals);
            if (result != null) return Convert.ToDouble(result);
            return null;
        }

        /// <summary>
        /// Rounds the decimal value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="decimals">The decimals.</param>
        /// <returns>A decimal.</returns>
        public static decimal RoundDecimals(this decimal value, int decimals)
        {
            return Math.Round(value, decimals);
        }

        /// <summary>
        /// Rounds the decimal value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="decimals">The decimals.</param>
        /// <returns>A decimal? .</returns>
        public static decimal? RoundDecimals(this decimal? value, int decimals)
        {
            if (value == null) return null;
            return Math.Round((decimal)value, decimals);
        }

        /// <summary>
        /// Adds the integer values.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>An int? .</returns>
        public static int? AddInts(int? value1, int? value2)
        {
            if (value1 == null) return value2;
            if (value2 == null) return value1;
            return value1 + value2;
        }

        /// <summary>
        /// Inverse the value.
        /// </summary>
        /// <param name="doubleValue">The double value.</param>
        /// <param name="roundTo">The round to.</param>
        /// <returns>A decimal? .</returns>
        public static decimal? InverseValue(double? doubleValue, int roundTo = 2)
        {
            if (doubleValue != null && doubleValue != 0) return (1 / doubleValue).RoundDecimals(roundTo);
            return null;
        }

        /// <summary>
        /// Sums the list of doubles.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>A decimal.</returns>
        public static decimal SumDoubles(this IEnumerable<double?> collection)
        {
            decimal total = 0;

            if (collection == null) return total;

            foreach (var value in collection)
            {
                if (value != null) total += (decimal)value;
            }

            return total;
        }
    }
}
