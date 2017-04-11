using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using static QCloudAPIHelper.APIEnum;

namespace QCloudAPIHelper.ModulesHelper
{
    /// <summary>
    /// CVM 通用类
    /// </summary>
    public class CvmType
    {
        public int code { get; set; }
        public string message { get; set; }
        public int totalCount { get; set; }
        public List<CvmInstanceSetType> instanceSet { get; set; }
    }

    /// <summary>
    /// CVM 实例信息
    /// </summary>
    public class CvmInstanceSetType
    {
        public string instanceName { get; set; }
        public string unInstanceId { get; set; }
        public string lanIp { get; set; }
        public ArrayList wanIpSet { get; set; }
        public int cpu { get; set; }
        public int mem { get; set; }
        public int bandwidth { get; set; }
        public string unImgId { get; set; }
        public int status { get; set; }
        public string Region { get; set; }
        public string createTime { get; set; }
        public string deadlineTime { get; set; }
        public int autoRenew { get; set; }
        public int projectId { get; set; }
        public string os { get; set; }
        public string cvmPayMode { get; set; }
        public string networkPayMode { get; set; }
        public int zoneId { get; set; }
        public string zoneName { get; set; }
        public int vpcId { get; set; }
        public int subnetId { get; set; }
        public int isVpcGateway { get; set; }
        public List<DiskInfoType> diskInfo { get; set; }
    }

    /// <summary>
    /// CVM 硬盘信息
    /// </summary>
    public class DiskInfoType
    {
        public string storageId { get; set; }
        public int storageType { get; set; }
        public int storageSize { get; set; }
        public string rootId { get; set; }
        public int rootSize { get; set; }
        public int rootType { get; set; }
    }


    public static class CvmHelper
    {
        /// <summary>
        /// 获取CVM列表
        /// </summary>
        /// <param name="q"></param>
        /// <param name="cvmList">（过滤条件）按照一个或者多个实例ID过滤</param>
        /// <param name="lanIpsList">（过滤条件）按照一个或者多个实例的内网IP或公网IP（包括实例创建时自动分配的IP和弹性IP）过滤（此接口支持同时传入多个IP。此参数的具体格式可参考API简介的id.n一节）。</param>
        /// <param name="searchWord">（过滤条件）按照实例名称过滤，支持模糊查询。</param>
        /// <param name="status">（过滤条件）实例的状态，状态的列举见上。</param>
        /// <param name="projectId">（过滤条件）项目ID。</param>
        /// <param name="zoneId">（过滤条件）可用区ID。</param>
        /// <param name="offset">偏移量，默认为0</param>
        /// <param name="limit">返回数量默认 20，最大值 100</param>
        /// <returns></returns>
        public static CvmType GetCVMList(
            QCloudHelper q,
            List<string> cvmList = null,
            List<string> lanIpsList = null,
            string searchWord = null,
            int? status = null,
            int? projectId = null,
            int? zoneId = null,
            int offset = 0,
            int limit = 20)
        {

            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal);

            if (cvmList != null)
            {
                for (int i = 0; i < cvmList.Count; i++)
                {
                    baseParams.Add($"instanceIds.{i}", cvmList[i]);
                }
            }

            if (lanIpsList != null)
            {
                for (int i = 0; i < lanIpsList.Count; i++)
                {
                    baseParams.Add($"lanIps.{i}", lanIpsList[i]);
                }
            }

            if (searchWord != null && !string.IsNullOrWhiteSpace(searchWord))
            {
                baseParams.Add("searchWord", searchWord);
            }

            if (status != null)
            {
                baseParams.Add("status", status);
            }

            if (projectId != null)
            {
                baseParams.Add("projectId", projectId);
            }

            if (zoneId != null)
            {
                baseParams.Add("zoneId", zoneId);
            }

            if (offset != 0)
            {
                baseParams.Add("offset", offset);
            }

            if (limit != 20)
            {
                baseParams.Add("limit", limit);
            }

            var returnJson = q.RequestAPi("DescribeInstances", baseParams, APIUrl.Cvm);
            return JsonConvert.DeserializeObject<CvmType>(returnJson);
        }
    }
}
