using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace UtilityExt
{
    /// <summary>
    /// The enum extention class.
    /// </summary>
    public static class EnumX
    {
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>A string.</returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            string displayName = "";
            if (enumValue != null)
            {
                displayName = enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .First()
                    .GetCustomAttribute<DisplayAttribute>()?
                    .GetName() ?? enumValue.ToString();

                if (string.IsNullOrEmpty(displayName))
                {
                    displayName = enumValue.ToString();
                }
            }

            return displayName;
        }
    }
}
