using System;

namespace Divar.Framework.Tools.Enums
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum @enum)
        {

            Type genericEnumType = @enum.GetType();

            System.Reflection.MemberInfo[] memberInfo =
                genericEnumType.GetMember(@enum.ToString());

            if (memberInfo.Length <= 0) return @enum.ToString();

            var attributes = memberInfo[0].GetCustomAttributes
                (typeof(System.ComponentModel.DescriptionAttribute), false);

            return attributes.Length > 0 ? ((System.ComponentModel.DescriptionAttribute) 
                attributes[0]).Description : @enum.ToString();
        }
    }
}