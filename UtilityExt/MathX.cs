namespace UtilityExt
{
    public static class MathX
    {
        public static double ZeroIfNull(this double? value)
        {
            return value ?? 0;
        }

        public static decimal? RoundDecimals(this double? value, int decimals)
        {
            if (value != null) return RoundDecimals((double)value, decimals);
            return null;
        }

        public static decimal? RoundDecimals(this double value, int decimals)
        {
            if (!double.IsInfinity(value)) return Math.Round((decimal)value, decimals);
            return null;
        }

        public static string? FormatDecimals(this decimal? value, string format)
        {
            if (value != null) return ((decimal)value).ToString(format);
            return null;
        }

        public static decimal AddDoubles(double? value1, double? value2)
        {
            var double1 = value1.ZeroIfNull();
            var double2 = value2.ZeroIfNull();
            if (double.IsInfinity(double1)) double1 = 0;
            if (double.IsInfinity(double2)) double2 = 0;
            return (decimal)double1 + (decimal)double2;
        }

        public static double? RoundUpDouble(this double? value, int decimals)
        {
            var result = RoundDouble(value, decimals);
            if (result != null && result < value) result = Convert.ToDouble(AddDoubles(result, Math.Pow(10, -decimals)));
            return result;
        }

        public static double? RoundDouble(this double? value, int decimals)
        {
            var result = value.RoundDecimals(decimals);
            if (result != null) return Convert.ToDouble(result);
            return null;
        }

        public static decimal RoundDecimals(this decimal value, int decimals)
        {
            return Math.Round(value, decimals);
        }

        public static decimal? RoundDecimals(this decimal? value, int decimals)
        {
            if (value == null) return null;
            return Math.Round((decimal)value, decimals);
        }

        public static int? AddInts(int? value1, int? value2)
        {
            if (value1 == null) return value2;
            if (value2 == null) return value1;
            return value1 + value2;
        }

        public static decimal? InverseValue(double? doubleValue, int roundTo = 2)
        {
            if (doubleValue != null && doubleValue != 0) return (1 / doubleValue).RoundDecimals(roundTo);
            return null;
        }

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
