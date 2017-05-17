using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using static QCloudAPIHelper.APIEnum;

namespace QCloudAPIHelper.ModulesHelper
{
    /// <summary>
    /// CVM 列表获取返回类型
    /// </summary>
    public class CvmListReturnType
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
        public string uuid { get; set; }
        public string unInstanceId { get; set; }
        public string lanIp { get; set; }
        public ArrayList wanIpSet { get; set; }
        public int cpu { get; set; }
        public int mem { get; set; }
        public int bandwidth { get; set; }
        public string deviceClass { get; set; }
        public int imageId { get; set; }
        public string imageType { get; set; }
        public string unImgId { get; set; }
        public int status { get; set; }
        public string Region { get; set; }
        public string createTime { get; set; }
        public string statusTime { get; set; }
        public string deadlineTime { get; set; }
        public int autoRenew { get; set; }
        public int projectId { get; set; }
        public string os { get; set; }
        public string cvmPayMode { get; set; }
        public string networkPayMode { get; set; }
        public int zoneId { get; set; }
        public string zoneName { get; set; }
        public string vpcId { get; set; } // 腾讯云在香港地区会出现返回String的情况
        public string subnetId { get; set; } // 腾讯云在香港地区会出现返回String的情况
        public int isVpcGateway { get; set; }
        public DiskInfoType diskInfo { get; set; }
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

    /// <summary>
    /// 用于CVM 启动/关闭/重启 的返回类型
    /// </summary>
    public class BaseCvmOperationReturnType
    {
        public int code { get; set; }
        public string message { get; set; }
        public dynamic detail { get; set; }
    }

    /// <summary>
    /// 用于CVM 重装系统的返回类型
    /// </summary>
    public class ReinstallCVMSystemReturnType
    {
        public int code { get; set; }
        public string message { get; set; }
        public int requestId { get; set; }
    }

    /// <summary>
    /// 用于CVM 重命名实例的返回类型
    /// </summary>
    public class BaseCVMReturnType
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    /// <summary>
    /// CVM 操纵主类
    /// </summary>
    public static class CvmHelper
    {
        #region CVM 列表获取
        /// <summary>
        /// 获取CVM列表
        /// </summary>
        /// <param name="q"></param>
        /// <param name="r">区域  默认为上海区域(兼容以前程序)</param>
        /// <param name="cvmList">（过滤条件）按照一个或者多个实例ID过滤</param>
        /// <param name="lanIpsList">（过滤条件）按照一个或者多个实例的内网IP或公网IP（包括实例创建时自动分配的IP和弹性IP）过滤（此接口支持同时传入多个IP。此参数的具体格式可参考API简介的id.n一节）。</param>
        /// <param name="searchWord">（过滤条件）按照实例名称过滤，支持模糊查询。</param>
        /// <param name="status">（过滤条件）实例的状态，状态的列举见上。</param>
        /// <param name="projectId">（过滤条件）项目ID。</param>
        /// <param name="zoneId">（过滤条件）可用区ID。</param>
        /// <param name="offset">偏移量，默认为0</param>
        /// <param name="limit">返回数量默认 20，最大值 100</param>
        /// <returns></returns>
        public static CvmListReturnType GetCVMList(
            QCloudHelper q,
            Region r,
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

            var returnJson = q.RequestAPi("DescribeInstances", baseParams, APIUrl.Cvm,r);
            return JsonConvert.DeserializeObject<CvmListReturnType>(returnJson);
        }


        /// <summary>
        /// 获取所有的CVM
        /// </summary>
        /// <param name="q"></param>
        /// <param name="r">区域  默认为上海区域(兼容以前程序)</param>
        /// <param name="cvmList">（过滤条件）按照一个或者多个实例ID过滤</param>
        /// <param name="lanIpsList">（过滤条件）按照一个或者多个实例的内网IP或公网IP（包括实例创建时自动分配的IP和弹性IP）过滤（此接口支持同时传入多个IP。此参数的具体格式可参考API简介的id.n一节）。</param>
        /// <param name="searchWord">（过滤条件）按照实例名称过滤，支持模糊查询。</param>
        /// <param name="status">（过滤条件）实例的状态，状态的列举见上。</param>
        /// <param name="projectId">（过滤条件）项目ID。</param>
        /// <param name="zoneId">（过滤条件）可用区ID。</param>
        /// <returns></returns>
        public static CvmListReturnType GetCVMAllList(
            QCloudHelper q,
            Region r,
            List<string> cvmList = null,
            List<string> lanIpsList = null,
            string searchWord = null,
            int? status = null,
            int? projectId = null,
            int? zoneId = null)
        {
            var temp = GetCVMList(q, r, cvmList, lanIpsList, searchWord, status, projectId, zoneId,limit:20);
            int count = temp.totalCount;
            CvmListReturnType c = new CvmListReturnType()
            {
                totalCount = temp.totalCount,
                message = temp.message,
                code = temp.code,
                instanceSet = new List<CvmInstanceSetType>()

            };
            // 整除得出循环次数,多循环一次获得剩余不满100条的db信息
            for (int i = 0; i <= count / 100; i++)
            {
                var t = GetCVMList(q, r, cvmList, lanIpsList, searchWord, status, projectId, zoneId, i * 100, 100);
                if (t.instanceSet != null)
                {
                    c.instanceSet.AddRange(t.instanceSet);
                }

            }
            return c;
        }

        #endregion

        #region CVM  启动/关闭/重启
        /// <summary>
        /// 启动CVM
        /// </summary>
        /// <param name="q"></param>
        /// <param name="cvmList"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public static BaseCvmOperationReturnType StartCvm(QCloudHelper q, List<string> cvmList, Region region)
        {
            return BaseCvmOperation(q, "StartInstances", cvmList, region);
        }

        /// <summary>
        /// 关闭CVM
        /// </summary>
        /// <param name="q"></param>
        /// <param name="cvmList"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public static BaseCvmOperationReturnType StopCvm(QCloudHelper q, List<string> cvmList, Region region)
        {
            return BaseCvmOperation(q, "StopInstances", cvmList, region);
        }

        /// <summary>
        /// 重启CVM
        /// </summary>
        /// <param name="q"></param>
        /// <param name="cvmList"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public static BaseCvmOperationReturnType RestartCvm(QCloudHelper q, List<string> cvmList, Region region)
        {
            return BaseCvmOperation(q, "RestartInstances", cvmList, region);
        }

        /// <summary>
        /// CVM 启动/关闭/重启 基础调用方法
        /// </summary>
        /// <param name="q"></param>
        /// <param name="actionList"></param>
        /// <param name="cvmList"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public static BaseCvmOperationReturnType BaseCvmOperation(QCloudHelper q, string actionList, List<string> cvmList, Region region)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal);

            if (cvmList != null)
            {
                for (int i = 0; i < cvmList.Count; i++)
                {
                    baseParams.Add($"instanceIds.{i}", cvmList[i]);
                }
            }
            var returnJson = q.RequestAPi(actionList, baseParams, APIUrl.Cvm, region);
            return JsonConvert.DeserializeObject<BaseCvmOperationReturnType>(returnJson);
        }
        #endregion

        #region CVM 重装
        /// <summary>
        /// 重装CVM
        /// </summary>
        /// <param name="q"></param>
        /// <param name="instanceId"></param>
        /// <param name="region">区域</param>
        /// <param name="imageType">镜像类型。1：私有镜像2：公有镜像3：镜像市场4：共享镜像。默认为2。需与imageId同时指定。</param>
        /// <param name="imageId">镜像ID。</param>
        /// <param name="password">实例密码</param>
        /// <param name="needSecurityAgent">安装安全Agent，0：不安装，1：安装，默认安装</param>
        /// <param name="needMonitorAgent">安装监控Agent，0：不安装，1：安装，默认安装</param>
        /// <param name="rootSize">系统盘大小(GB)。rootSize默认保持不变</param>
        /// <returns></returns>
        public static ReinstallCVMSystemReturnType ReInstallCVM(
            QCloudHelper q,
            string instanceId,
            Region region,
            int imageType = 2,
            string imageId = null,
            string password = null,
            int needSecurityAgent = 1,
            int needMonitorAgent = 1,
            int? rootSize = null)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "instanceId" ,instanceId}
            };

            if (imageType != 2)
            {
                baseParams.Add("imageType", imageType);
            }

            if (!string.IsNullOrWhiteSpace(imageId))
            {
                baseParams.Add("imageId", imageId);
            }

            if (!string.IsNullOrWhiteSpace(password))
            {
                baseParams.Add("password", password);
            }

            if (needSecurityAgent != 1)
            {
                baseParams.Add("needSecurityAgent", needSecurityAgent);
            }

            if (needMonitorAgent != 1)
            {
                baseParams.Add("needMonitorAgent", needMonitorAgent);
            }

            if (rootSize != null)
            {
                baseParams.Add("rootSize", (int)rootSize);
            }

            var returnJson = q.RequestAPi("ResetInstances", baseParams, APIUrl.Cvm, region);
            return JsonConvert.DeserializeObject<ReinstallCVMSystemReturnType>(returnJson);

        }
        #endregion

        #region CVM 实例重命名
        /// <summary>
        /// 重命名 CVM 实例
        /// </summary>
        /// <param name="q"></param>
        /// <param name="region"></param>
        /// <param name="instanceId"></param>
        /// <param name="instanceName"></param>
        /// <returns></returns>
        public static BaseCVMReturnType RenameCVM(QCloudHelper q, Region region, string instanceId, string instanceName)
        {
            if (string.IsNullOrWhiteSpace(instanceId) || string.IsNullOrWhiteSpace(instanceName))
            {
                throw new ArgumentNullException("instanceId and instanceName is null or empty");
            }

            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "instanceId" ,instanceId},
                { "instanceName" ,instanceName}
            };

            var returnJson = q.RequestAPi("ModifyInstanceAttributes", baseParams, APIUrl.Cvm, region);
            return JsonConvert.DeserializeObject<BaseCVMReturnType>(returnJson);

        }
        #endregion


        #region CVM 实例密码重置
        /// <summary>
        /// 重置 CVM 实例密码
        /// </summary>
        /// <param name="q"></param>
        /// <param name="region"></param>
        /// <param name="instanceIds"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static BaseCVMReturnType ResetCVMPassword(QCloudHelper q, Region region, List<string> instanceIds, string password)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal);
            baseParams.Add("password", password);
            if (instanceIds != null)
            {
                for (int i = 0; i < instanceIds.Count; i++)
                {
                    baseParams.Add($"instanceIds.{i}", instanceIds[i]);
                }
            }
            var returnJson = q.RequestAPi("ResetInstancePassword", baseParams, APIUrl.Cvm, region);
            return JsonConvert.DeserializeObject<BaseCVMReturnType>(returnJson);
        } 
        #endregion
    }
}
