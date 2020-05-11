using System;
using System.ComponentModel;
using System.Reflection;

namespace ReadyTech.Axis.Service.Models
{
    public static class EnumMixins
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return GetEnumAttributeValue<DescriptionAttribute>(value, x => x.Description) ?? value.ToString();
        }

        private static string GetEnumAttributeValue<TAttribute>(Enum value, Func<TAttribute, string> valueAccessor)
            where TAttribute : Attribute
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            //This can occur if it is a composite enum value. 
            //In the case of composites we cannot reliably determine the correct value so we just return null
            if (fi == null)
                return null;

            var attributes =
                (TAttribute[])fi.GetCustomAttributes(
                    typeof(TAttribute),
                    false);

            if (attributes.Length > 0)
                return valueAccessor(attributes[0]);
            return null;
        }
    }
}
