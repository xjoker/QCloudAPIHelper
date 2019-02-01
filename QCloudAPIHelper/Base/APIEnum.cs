using System.ComponentModel.DataAnnotations;

namespace QCloudAPIHelper
{
    /// <summary>
    /// 腾讯云API枚举
    /// </summary>
    public enum APIUrl
    {
        [Display(Name = "account.api.qcloud.com")]
        Account,

        [Display(Name = "bill.api.qcloud.com")]
        Bill,

        [Display(Name = "cbs.api.qcloud.com")]
        Cbs,

        [Display(Name = "cdb.api.qcloud.com")]
        Cdb,

        [Display(Name = "cdn.api.qcloud.com")]
        Cdn,

        [Display(Name = "cmem.api.qcloud.com")]
        Cmem,

        [Display(Name = "cvm.api.qcloud.com")]
        Cvm,

        [Display(Name = "eip.api.qcloud.com")]
        Eip,

        [Display(Name = "image.api.qcloud.com")]
        Image,

        [Display(Name = "lb.api.qcloud.com")]
        Lb,

        [Display(Name = "live.api.qcloud.com")]
        Live,

        [Display(Name = "market.api.qcloud.com")]
        Market,

        [Display(Name = "monitor.api.qcloud.com")]
        Monitor,

        [Display(Name = "redis.api.qcloud.com")]
        Redis,

        [Display(Name = "scaling.api.qcloud.com")]
        Scaling,

        [Display(Name = "csec.api.qcloud.com")]
        Sec,

        [Display(Name = "snapshot.api.qcloud.com")]
        Snapshot,

        [Display(Name = "tdsql.api.qcloud.com")]
        Tdsql,

        [Display(Name = "trade.api.qcloud.com")]
        Trade,

        [Display(Name = "vod.api.qcloud.com")]
        Vod,

        [Display(Name = "vpc.api.qcloud.com")]
        Vpc,

        [Display(Name = "wenzhi.api.qcloud.com")]
        Wenzhi,

        [Display(Name = "yunsou.api.qcloud.com")]
        Yunsou,

        [Display(Name = "partners.api.qcloud.com")]
        Pay
    }

    public enum APIUrlv3
    {
        [Display(Name = "cvm.tencentcloudapi.com")]
        Cvm,
    }

    /// <summary>
    /// 签名方式
    /// 目前支持HmacSHA256和HmacSHA1
    /// </summary>
    public enum SignatureMethod
    {
        HmacSHA256,
        HmacSHA1,
        TC3_HmacSHA256
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
        OneMinute = 60,
        FiveMinute = 300
    }

    /// <summary>
    /// 腾讯云云服务器可用区域
    /// </summary>
    public enum Region
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