using System;
using System.ComponentModel;
using System.Reflection;

namespace BPAccounting.Core
{
    public static class EnumHelpers
    {
        public static string GetDescription(this Enum currentEnum)
        {
            string description = String.Empty;

            DescriptionAttribute da;

            FieldInfo fi = currentEnum.GetType().GetField(currentEnum.ToString());

            da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));

            if (da != null)
                description = da.Description;
            else
                description = currentEnum.ToString();

            return description;
        }
    }
}
