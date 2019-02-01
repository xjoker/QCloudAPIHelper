using System;
using System.Linq;

namespace QCloudAPIHelper.Base
{
    public static class EnumHelper
    {
        /// <summary>
        /// 获取Enum项的Display描述信息
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            var displayName = enumValue.GetType()?
                .GetMember(enumValue.ToString())?
                .Select(x => x.GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), true)?
                .FirstOrDefault())?.FirstOrDefault() as System.ComponentModel.DisplayNameAttribute;
            return displayName?.DisplayName ?? enumValue.ToString();
        }
    }
}