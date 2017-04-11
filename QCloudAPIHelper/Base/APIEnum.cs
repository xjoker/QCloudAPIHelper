using System;
using System.Reflection;

namespace QCloudAPIHelper
{
    /// <summary>
    /// Enum 拓展定义
    /// </summary>
    public class EnumDescription : Attribute
    {
        private string _Description;
        public EnumDescription(string description)
        {
            _Description = description;
        }

        public string Remark
        {
            get
            {
                return _Description;
            }
        }
    }

    /// <summary>
    /// Enum 获取拓展的方法
    /// </summary>
    public static class RemarkExtend
    {
        public static string GetRemark(this Enum eValue)
        {
            Type type = eValue.GetType();
            FieldInfo field = type.GetField(eValue.ToString());
            EnumDescription enumDescription = (EnumDescription)field.GetCustomAttribute(typeof(EnumDescription));
            return enumDescription.Remark;
        }
    }

    /// <summary>
    /// API 枚举类
    /// </summary>
    public class APIEnum
    {
        /// <summary>
        /// 腾讯云API枚举
        /// </summary>
        public enum APIUrl
        {
            [EnumDescription("account.api.qcloud.com")]
            Account,
            [EnumDescription("bill.api.qcloud.com")]
            Bill,
            [EnumDescription("cbs.api.qcloud.com")]
            Cbs,
            [EnumDescription("cdb.api.qcloud.com")]
            Cdb,
            [EnumDescription("cdn.api.qcloud.com")]
            Cdn,
            [EnumDescription("cmem.api.qcloud.com")]
            Cmem,
            [EnumDescription("cvm.api.qcloud.com")]
            Cvm,
            [EnumDescription("eip.api.qcloud.com")]
            Eip,
            [EnumDescription("image.api.qcloud.com")]
            Image,
            [EnumDescription("lb.api.qcloud.com")]
            Lb,
            [EnumDescription("live.api.qcloud.com")]
            Live,
            [EnumDescription("market.api.qcloud.com")]
            Market,
            [EnumDescription("monitor.api.qcloud.com")]
            Monitor,
            [EnumDescription("scaling.api.qcloud.com")]
            Scaling,
            [EnumDescription("csec.api.qcloud.com")]
            Sec,
            [EnumDescription("snapshot.api.qcloud.com")]
            Snapshot,
            [EnumDescription("tdsql.api.qcloud.com")]
            Tdsql,
            [EnumDescription("trade.api.qcloud.com")]
            Trade,
            [EnumDescription("vod.api.qcloud.com")]
            Vod,
            [EnumDescription("vpc.api.qcloud.com")]
            Vpc,
            [EnumDescription("wenzhi.api.qcloud.com")]
            Wenzhi,
            [EnumDescription("yunsou.api.qcloud.com")]
            Yunsou
        }

        /// <summary>
        /// 签名方式
        /// 目前支持HmacSHA256和HmacSHA1
        /// </summary>
        public enum SignatureMethod
        {
            HmacSHA256,
            HmacSHA1
        }

        /// <summary>
        /// 请求方法
        /// </summary>
        public enum RequestMethod
        {
            POST,
            GET
        }

        /// <summary>
        /// 监控统计周期。当前支持60s和300s两种粒度，如不传，默认使用300s粒度。
        /// </summary>
        public enum Period
        {
            OneMinute=60,
            FiveMinute=300
        }

        /// <summary>
        /// 腾讯云云服务器可用区域
        /// </summary>
        public enum CVMRegion
        {
            /// <summary>
            /// 华南地区(广州)
            /// </summary>
            gz,
            /// <summary>
            /// 华东地区(上海)
            /// </summary>
            sh,
            /// <summary>
            /// 东南亚地区(香港)
            /// </summary>
            hk,
            /// <summary>
            /// 北美地区(多伦多)
            /// </summary>
            ca,
            /// <summary>
            /// 华东地区(上海金融)
            /// </summary>
            shjr,
            /// <summary>
            /// 华北地区(北京)
            /// </summary>
            bj,
            /// <summary>
            /// 东南亚地区(新加坡)
            /// </summary>
            sg,
            /// <summary>
            /// 华南地区(深圳金融)
            /// </summary>
            szjr,
            /// <summary>
            /// 华南地区(广州OPEN)
            /// </summary>
            gzopen,
            /// <summary>
            /// 美国西部(硅谷)
            /// </summary>
            usw
        }
    }

}
