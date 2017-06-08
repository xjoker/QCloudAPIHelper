using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QCloudAPIHelper.APIEnum;

namespace QCloudAPIHelper.ModulesHelper
{
    #region 获取高防 IP 列表 返回类型
    /// <summary>
    /// 获取高防 IP 列表 返回类型
    /// </summary>
    public class BGPIPGetListReturnType
    {
        public int code { get; set; }
        public string codeDesc { get; set; }
        public string message { get; set; }
        public BGPIPDataType data { get; set; }
    }


    public class BGPIPDataType
    {
        public List<BGPIPServicePacksType> servicePacks { get; set; }
        public int total { get; set; }
    }

    public class BGPIPServicePacksType
    {
        public string id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string boundIP { get; set; }
        public int bandwidth { get; set; }
        public int elasticLimit { get; set; }
        public int overloadCount { get; set; }
        public string status { get; set; }
        public DateTime expire { get; set; }
        public string locked { get; set; }
        public string transTarget { get; set; }
        public string transRules { get; set; }
    }

    #endregion

    #region 获取高防 IP 转发规则 返回类型
    /// <summary>
    /// 获取高防 IP 转发规则 返回类型
    /// </summary>
    public class BGPIPGetTransRulesReturnType
    {
        public int code { get; set; }
        public string codeDesc { get; set; }
        public string message { get; set; }
        public BGPIPtransRulesType data { get; set; }
    }

    public class BGPIPtransRulesType
    {
        public List<BGPIPTransRules> transRules { get; set; }
        public int total { get; set; }
    }

    public class BGPIPTransRules
    {
        public string id { get; set; }
        public string protocol { get; set; }
        public string virtualPort { get; set; }
        public string sourcePort { get; set; }
        public string ipList { get; set; }
    } 
    #endregion



    /// <summary>
    /// 大禹网络安全 API 
    /// </summary>
    public static class BGPIPHelper
    {
        /// <summary>
        /// 获取高防 IP 列表
        /// </summary>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="paging_index">页面索引，0表示第一页</param>
        /// <param name="paging_count">每页返回详情数</param>
        /// <param name="region">高防IP的地域，目前有三个地区 gz:广州 sh:上海 bj:北京</param>
        /// <param name="filtering_name">以高防IP的名称进行关键字查询，支持模糊搜索</param>
        /// <param name="filtering_ip">	以高防IP进行关键字查询，支持模糊搜索</param>
        /// <param name="sorting_field">取值范围： bandwidth/ overloadCount，bandwidth表示以带宽进行排序， overloadCount表示以超峰次数进行排序</param>
        /// <param name="sorting_order">取值范围：asc / desc，asc表示升序排列，desc表示降序排列</param>
        /// <returns></returns>
        public static BGPIPGetListReturnType BGPIPGetList(
            QCloudHelper q,
            Region r,
            int paging_index,
            int paging_count,
            string region,
            string filtering_name=null,
            string filtering_ip = null,
            string sorting_field = null,
            string sorting_order = null)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "paging.index", paging_index },
                { "paging.count", paging_count },
                { "region", region }
            };

            if (filtering_name != null)
            {
                baseParams.Add("filtering.name", filtering_name);
            }

            if (filtering_ip != null)
            {
                baseParams.Add("filtering.ip", filtering_ip);
            }

            if (sorting_field != null)
            {
                baseParams.Add("sorting.field", sorting_field);
            }

            if (sorting_order != null)
            {
                baseParams.Add("sorting.order", sorting_order);
            }

            var returnJson = q.RequestAPi("NS.BGPIP.GetServicePacks", baseParams, APIUrl.Sec, r);
            return JsonConvert.DeserializeObject<BGPIPGetListReturnType>(returnJson);
        }


        /// <summary>
        /// 获取高防 IP 转发规则
        /// </summary>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="paging_index">页面索引，0表示第一页</param>
        /// <param name="paging_count">每页返回详情数</param>
        /// <param name="bgpId">BGP高防IP的资源ID</param>
        /// <returns></returns>
        public static BGPIPGetTransRulesReturnType BGPIPGetTransRules(
            QCloudHelper q,
            Region r,
            int paging_index,
            int paging_count,
            string bgpId)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "paging.index", paging_index },
                { "paging.count", paging_count },
                { "bgpId", bgpId }
            };

            var returnJson = q.RequestAPi("NS.BGPIP.ServicePack.GetTransRules", baseParams, APIUrl.Sec, r);
            return JsonConvert.DeserializeObject<BGPIPGetTransRulesReturnType>(returnJson);
        }
    }
}
