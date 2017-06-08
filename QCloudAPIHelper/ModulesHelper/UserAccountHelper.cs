using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using static QCloudAPIHelper.APIEnum;

namespace QCloudAPIHelper.ModulesHelper
{
    #region 支付状态等返回类型
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
    #endregion

    #region 查询账单列表返回类型
    /// <summary>
    /// 查询账单列表返回类型
    /// </summary>
    public class PayDescribBillsRetrunType
    {
        public int code { get; set; }
        public string message { get; set; }
        public PayDescribBillsDatalist data { get; set; }
    }
    /// <summary>
    /// bill_type 对应关系
    /// </summary>
    public enum bill_type
    {
        全部 = 0,
        充值,
        购买,
        提现,
        月结冻结,
        月结扣费,
        月结解冻,
        退款,
        小时冻结,
        小时扣费,
        小时解冻,
        系统充值,
        其他扣款
    }

    public class PayDescribBillsDatalist
    {
        public List<PayDescribBillsDatalistType> datalist { get; set; }
        public PayDescribBillsPageType page { get; set; }
        public PayDescribBillsCountType count { get; set; }
        public PayDescribBillsPay_dataType pay_data { get; set; }
    }

    public class PayDescribBillsDatalistType
    {
        public string bill_id { get; set; }
        public string date { get; set; }
        public bill_type bill_type { get; set; }
        public double amount { get; set; }
        public double balance { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string @class { get; set; }
        public string cnt { get; set; }
        public string source { get; set; }
        public string operation_type { get; set; }
    }

    public class PayDescribBillsPageType
    {
        public int cur { get; set; }
        public int total { get; set; }
    }

    public class PayDescribBillsCountType
    {
        public int begin { get; set; }
        public string end { get; set; }
        public string total { get; set; }
    }

    public class PayDescribBillsPay_dataType
    {
        public double total_cost { get; set; }
        public double total_pay { get; set; }
    }

    #endregion

    #region 获取订单信息 返回值

    /// <summary>
    /// 获取订单信息 返回值
    /// </summary>
    public class PayOrderDescribeDealsByCondRetrunType
    {
        public int code { get; set; }
        public string message { get; set; }
        public string codeDesc { get; set; }
        public PayOrderDescribeDealsByCondDataType data { get; set; }
    }

    public class PayOrderDescribeDealsByCondDataType
    {
        public string totalNum { get; set; }
        public List<PayOrderDescribeDealsByCondDealType> deals { get; set; }
    }

    public class PayOrderDescribeDealsByCondDealType
    {
        public string dealName { get; set; }
        public string dealId { get; set; }
        public PayOrderDescribeDealsByCondGoodsCategoryId goodsCategoryId { get; set; }
        public dynamic goodsDetail { get; set; }
        public string creatTime { get; set; }
        public string billId { get; set; }
        public dynamic taskDetail { get; set; }
        public int realTotalCost { get; set; }
        public string voucherDecline { get; set; }
        public string projectId { get; set; }
    }

    /// <summary>
    /// 产品分类ID 
    /// </summary>
    public enum PayOrderDescribeDealsByCondGoodsCategoryId
    {
        CVM新购 = 1,
        CDB新购 = 2,
        CMEM新购 = 3,
        CEE新购 = 4,
        CVM续费 = 15,
        带宽升级 = 16,
        CDB预付费购买 = 17,
        CDB续费 = 18,
        带宽包购买 = 19,
        CVM升级 = 21,
        CDB升级 = 22,
        新购DDOS包 = 23,
        续费DDOS包 = 24,
        升级DDOS包 = 25,
        新购VPN包 = 26,
        续费VPN包 = 27,
        升级VPN包 = 28,
        新购云视频套餐 = 29,
        续费云视频套餐 = 30,
        升级云视频套餐 = 31,
        新购CDN包 = 32,
        服务市场代运维产品 = 33,
        新版负载均衡 = 34,
        新购大禹套餐 = 35,
        大禹流量包 = 36,
        redis购买 = 37,
        redis续费 = 38,
        redis升级 = 39,
        视频直播购买 = 40,
        CVM降配 = 41,
        cvm后付费切预付费 = 42,
        cdb后付费切预付费 = 43,
        服务市场软件类 = 45,
        wenzhi购买_月套餐 = 46,
        wenzhi续费 = 47,
        wenzhi升级 = 48,
        VPC专线购买 = 49,
        VPC专线续费 = 50,
        SSLVPN购买_月套餐 = 51,
        SSLVPN续费 = 52,
        SSLVPN升级 = 53,
        预付费CDB只读实例购买 = 54,
        CDB只读实例续费 = 55,
        CDB只读实例升级 = 56,
        SQLServer预付费购买 = 65,
        SQLServer续费 = 66,
        SQLServer升级 = 67,
        TDSQL预付费购买 = 69,
        TDSQL续费 = 70,
        TDSQL升级 = 71,
        云数据库Mysql新购=100016,
        云数据库Mysql续费 = 100017
    }

    public enum PayOrderDescribeDealsByCondStatus
    {
        未支付 = 1,
        已支付,
        发货中,
        已发货,
        发货失败,
        已退款,
        已关单,
        订单过期,
        订单已失效,
        产品已失效,
        代付拒绝,
        支付中
    }


    #endregion


    /// <summary>
    /// 查询账单详情返回类型
    /// </summary>
    public class PayDescribeBillDetailRetrunType
    {
        public int code { get; set; }
        public string message { get; set; }
        public string OriginalClass { get; set; }
        public string OriginalType { get; set; }
        public string OriginalConfig { get; set; }
        public string FOfferID { get; set; }
        public string FDeviceId { get; set; }
        public string FDealId { get; set; }
        public string regionId { get; set; }
        public string FUnitPrice { get; set; }
        public string FUnitPriceUnit { get; set; }
        public string FCountUnit { get; set; }
        public string FAmt { get; set; }
        public string FCount { get; set; }
        public ArrayList FDeviceType { get; set; }
        public bool is_expire { get; set; }
        public string FPriceGraduated { get; set; }
        public string FProxyUin { get; set; }
        public string FProxyFlag { get; set; }
    }

    /// <summary>
    /// 用户账户接口帮助类
    /// </summary>
    public static class UserAccountHelper
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

        /// <summary>
        /// 查询账单列表
        /// </summary>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="startDate">开始时间，默认为今天</param>
        /// <param name="endDate">结束时间时间，默认为今天</param>
        /// <param name="offset">偏移量，默认为0</param>
        /// <param name="limit">默认为20，最大100</param>
        /// <param name="projectId">项目ID，默认为0表示默认项目</param>
        /// <param name="orderType">0为正序，1为倒序</param>
        /// <returns></returns>
        public static PayDescribBillsRetrunType PayOrderDescribeBillsQuery(
            QCloudHelper q,
            Region r,
            string startDate = null,
            string endDate = null,
            int offset = 0,
            int limit = 20,
            int projectId = 0,
            int? orderType = null)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "offset", offset },
                { "limit", limit },
                { "projectId", projectId }
            };

            if (startDate != null)
            {
                baseParams.Add("startDate", startDate);
            }

            if (endDate != null)
            {
                baseParams.Add("endDate", endDate);
            }

            if (orderType != null)
            {
                baseParams.Add("orderType", orderType);
            }

            var returnJson = q.RequestAPi("DescribeBills", baseParams, APIUrl.Bill, r);
            return JsonConvert.DeserializeObject<PayDescribBillsRetrunType>(returnJson);
        }

        /// <summary>
        /// 查询账单详情
        /// </summary>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="billId">账单ID</param>
        /// <param name="startDate">账单的开始时间，可以填写账单的创建时间</param>
        /// <param name="endDate">账单的结束时间</param>
        /// <param name="billType">账单的类型</param>
        /// <returns></returns>
        public static PayDescribeBillDetailRetrunType PayOrderDescribeBillDetailQuery(
            QCloudHelper q,
            Region r,
            string billId,
            string startDate,
            string endDate,
            int billType)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "billId", billId },
                { "startDate", startDate },
                { "endDate", endDate },
                { "billType", billType }
            };

            var returnJson = q.RequestAPi("DescribeBillDetail", baseParams, APIUrl.Bill, r);
            return JsonConvert.DeserializeObject<PayDescribeBillDetailRetrunType>(returnJson);
        }


        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="page">第多少页,从0开始，默认是0</param>
        /// <param name="pageSize">一页多少条数据，默认是20条</param>
        /// <param name="status"></param>
        /// <param name="dealId">订单ID</param>
        /// <returns></returns>
        public static PayOrderDescribeDealsByCondRetrunType PayOrderDescribeDealsByCond(
            QCloudHelper q,
            Region r,
            string startTime,
            string endTime,
            int page = 0,
            int pageSize = 20,
            PayOrderDescribeDealsByCondStatus status = PayOrderDescribeDealsByCondStatus.已发货,
            int? dealId = null)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "startTime", startTime },
                { "endTime", endTime },
                { "page", page },
                { "pageSize", pageSize },
                { "status",(int)status }
            };

            if (dealId != null)
            {
                baseParams.Add("dealId", dealId);
            }

            var returnJson = q.RequestAPi("DescribeDealsByCond", baseParams, APIUrl.Trade, r);
            return JsonConvert.DeserializeObject<PayOrderDescribeDealsByCondRetrunType>(returnJson);
        }
    }
}
