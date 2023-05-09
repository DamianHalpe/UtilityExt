using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace UtilityExt
{
    public static class EnumX
    {
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
