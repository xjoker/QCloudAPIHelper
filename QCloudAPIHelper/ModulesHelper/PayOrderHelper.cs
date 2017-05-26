using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QCloudAPIHelper.APIEnum;

namespace QCloudAPIHelper.ModulesHelper
{
    /// <summary>
    /// 支付状态枚举
    /// </summary>
    public enum PayStatus
    {
        Unpaid = 1,
        Paid,
        In_the_delivery,
        Shipped,
        Delivery_Failure,
        Refund,
        Closed_single,
        Order_Expiration,
        The_order_has_expired,
        The_product_has_expired,
        Lieu_of_payment,
        In_Payment
    }

    /// <summary>
    /// 支付订单
    /// </summary>
    public class PayOrderReturn
    {
        /// <summary>
        /// 公共错误码, 0表示成功，其他值表示失败。
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 模块错误信息描述，与接口相关。
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 英文错误描述
        /// </summary>
        public string codeDesc { get; set; }
        public List<PayOrderData> data { get; set; }
    }

    /// <summary>
    /// 支付订单Data类型
    /// </summary>
    public class PayOrderData
    {
        /// <summary>
        /// 支付成功的订单号数组
        /// </summary>
        public List<string> dealNames { get; set; }
        /// <summary>
        /// 支付成功的订单对应的资源ID数组
        /// </summary>
        public List<string> resourceIds { get; set; }
        /// <summary>
        /// 支付成功的订单对应的自增ID数组
        /// </summary>
        public List<string> dealIds { get; set; }
    }


    /// <summary>
    /// 查询订单返回类型
    /// </summary>
    public class PayOrderQueryReturnType
    {
        /// <summary>
        /// 公共错误码, 0表示成功，其他值表示失败。
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 模块错误信息描述，与接口相关。
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 英文错误描述
        /// </summary>
        public string codeDesc { get; set; }

        public PayOrderQueryData data { get; set; }
    }

    public class PayOrderQueryData
    {
        public string totalNum { get; set; }
        public dynamic deals { get; set; }
    }

    /// <summary>
    /// 支付订单接口帮助类
    /// </summary>
    public static class PayOrderHelper
    {
        /// <summary>
        /// 支付订单
        /// </summary>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="ownerUin">订单拥有者uin</param>
        /// <param name="agentPay">代付标志，1：代付；0：自付</param>
        /// <param name="dealNames">订单号数组</param>
        /// <returns></returns>
        public static PayOrderReturn PayOrder(
           QCloudHelper q,
           Region r,
           int ownerUin,
           int agentPay,
           List<string> dealNames)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "ownerUin", ownerUin },
                { "agentPay", agentPay }
            };


            if (dealNames != null)
            {
                for (int i = 0; i < dealNames.Count; i++)
                {
                    baseParams.Add($"dealNames.{i}", dealNames[i]);
                }
            }

            var returnJson = q.RequestAPi("PayDealsNew", baseParams, APIUrl.Pay, r);
            return JsonConvert.DeserializeObject<PayOrderReturn>(returnJson);
        }


        /// <summary>
        /// 查询客户订单
        /// https://cloud.tencent.com/document/product/563/8070
        /// </summary>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="creatTimeRangeStart">下单时间范围起始，格式为2016-11-11 00:00:00</param>
        /// <param name="creatTimeRangeEnd">下单时间范围结束，格式为2016-11-11 00:00:00</param>
        /// <param name="page">分页号，从0开始</param>
        /// <param name="rows">页码大小，最大值为30</param>
        /// <param name="order">页码大小，最大值为30</param>
        /// <param name="status">订单的状态</param>
        /// <param name="ownerUin">下单人uin</param>
        /// <param name="payerMode">支付方式，0:自付;1:代付</param>
        /// <returns></returns>
        public static PayOrderQueryReturnType PayOrderQuery(
           QCloudHelper q,
           Region r,
           string creatTimeRangeStart = null,
           string creatTimeRangeEnd = null,
           int? page = null,
           int? rows = null,
           int? order = null,
           PayStatus? status = null,
           int? ownerUin = null,
           int? payerMode = null
            )
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal);

            if (creatTimeRangeStart != null)
            {
                baseParams.Add("creatTimeRangeStart", creatTimeRangeStart);
            }

            if (creatTimeRangeEnd != null)
            {
                baseParams.Add("creatTimeRangeEnd", creatTimeRangeEnd);
            }


            if (page != null)
            {
                baseParams.Add("page", page);
            }

            if (rows != null)
            {
                baseParams.Add("rows", rows);
            }

            if (status != null)
            {
                baseParams.Add("status", status.Value);
            }

            if (ownerUin != null)
            {
                baseParams.Add("ownerUin", ownerUin);
            }

            if (payerMode != null)
            {
                baseParams.Add("payerMode", payerMode);
            }

            var returnJson = q.RequestAPi("QueryClientDeals", baseParams, APIUrl.Pay, r);
            return JsonConvert.DeserializeObject<PayOrderQueryReturnType>(returnJson);
        }


    }
}
