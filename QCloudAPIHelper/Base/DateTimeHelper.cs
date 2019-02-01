using System;

namespace QCloudAPIHelper.Base
{
    public static class DatetimeHelper
    {
        /// <summary>
        /// 转换时间为QCloud定义的时间格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string DateTimeConvertQCloudFormat(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}