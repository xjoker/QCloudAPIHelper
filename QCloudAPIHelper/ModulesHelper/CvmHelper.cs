using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static QCloudAPIHelper.APIEnum;

namespace QCloudAPIHelper.ModulesHelper
{
    #region CVM 数据类型
    /// <summary>
    /// CVM 列表返回类型
    /// </summary>
    public class CvmListReturnType
    {
        public CVMListResponseType Response { get; set; }
    }

    /// <summary>
    /// CVM 列表获取返回类型
    /// </summary>
    public class CVMListResponseType
    {
        public string RequestId { get; set; }
        public int TotalCount { get; set; }
        public List<CVMInstanceSetInstanceType> InstanceSet { get; set; }
    }

    /// <summary>
    /// CVM 返回值 Placement
    /// </summary>
    public class CVMInstanceSetPlacementType
    {
        public string Zone { get; set; }
        public int ProjectId { get; set; }
        public List<String> HostId { get; set; }
    }

    /// <summary>
    /// CVM 返回值 SystemDisk DataDisk
    /// </summary>
    public class CVMDiskType
    {
        public string DiskType { get; set; }
        public string DiskId { get; set; }
        public int DiskSize { get; set; }
    }

    /// <summary>
    /// CVM 返回值 VirtualPrivateCloud
    /// </summary>
    public class CVMInstanceSetVirtualPrivateCloudType
    {
        public string VpcId { get; set; }
        public string SubnetId { get; set; }
        public bool AsVpcGateway { get; set; }
        public List<string> PrivateIpAddresses { get; set; }
    }

    /// <summary>
    /// CVM 返回值 InternetAccessible
    /// </summary>
    public class CVMInstanceSetInternetAccessibleType
    {
        public string InternetChargeType { get; set; }
        public int InternetMaxBandwidthOut { get; set; }
        public bool PublicIpAssigned { get; set; }
    }

    /// <summary>
    /// CVM 返回值 InstanceChargePrepaid
    /// </summary>
    public class CVMInstanceChargePrepaidType
    {
        public int Period { get; set; }
        public string RenewFlag { get; set; }
    }

    /// <summary>
    /// CVM 返回值 LoginSettings
    /// </summary>
    public class CVMLoginSettingsType
    {
        public string Password { get; set; }
        public List<string> KeyIds { get; set; }
        public string KeepImageLogin { get; set; }
    }

    /// <summary>
    /// CVM 返回值 RunSecurityServiceEnabled
    /// </summary>
    public class CVMInstanceSetRunSecurityServiceEnabledType
    {
        public bool Enabled { get; set; }
    }

    /// <summary>
    /// CVM 返回值 RunMonitorServiceEnabled
    /// </summary>
    public class CVMInstanceSetRunMonitorServiceEnabledType
    {
        public bool Enabled { get; set; }
    }

    /// <summary>
    /// CVM 返回值 EnhancedService
    /// </summary>
    public class CVMEnhancedServiceType
    {
        public CVMInstanceSetRunSecurityServiceEnabledType SecurityService { get; set; }
        public CVMInstanceSetRunMonitorServiceEnabledType MonitorService { get; set; }
    }

    /// <summary>
    /// CVM 返回值 Price
    /// </summary>
    public class CVMInstanceSetPriceType
    {
        public dynamic InstancePrice { get; set; }
        public dynamic BandwidthPrice { get; set; }
    }

    /// <summary>
    /// CVM 返回值 InstanceStatus
    /// </summary>
    public class CVMInstanceStatusType
    {
        public string InstanceId { get; set; }
        public string InstanceState { get; set; }
    }

    /// <summary>
    /// CVM 返回值 Instance 
    /// </summary>
    public class CVMInstanceSetInstanceType
    {
        public CVMInstanceSetPlacementType Placement { get; set; }
        public string InstanceId { get; set; }
        public string InstanceType { get; set; }
        public int CPU { get; set; }
        public int Memory { get; set; }
        public string InstanceName { get; set; }
        public string InstanceChargeType { get; set; }
        public CVMDiskType SystemDisk { get; set; }
        public List<CVMDiskType> DataDisks { get; set; }
        public List<string> PrivateIpAddresses { get; set; }
        public List<string> PublicIpAddresses { get; set; }
        public CVMInstanceSetInternetAccessibleType InternetAccessible { get; set; }
        public CVMInstanceSetVirtualPrivateCloudType VirtualPrivateCloud { get; set; }
        public string ImageId { get; set; }
        public string AutoRenew { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ExpiredTime { get; set; }
    }


    /// <summary>
    /// 用于CVM 启动/关闭/重启 的返回类型
    /// </summary>
    public class BaseCvmOperationReturnType
    {
        public BaseCvmOperationResponseType Response { get; set; }
    }

    public class BaseCvmOperationResponseType
    {
        public string RequestId { get; set; }
    }

    /// <summary>
    /// CVM实例状态列表返回类型
    /// </summary>
    public class CVMStatusReturnType
    {
        public string RequestId { get; set; }
        public int TotalCount { get; set; }
        public CVMInstanceStatusType InstanceStatusSet { get; set; }
    }

    #endregion

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
            List<string> zone = null,
            List<string> project_id = null,
            List<string> host_id = null,
            List<string> instance_id = null,
            List<string> instance_name = null,
            string instance_charge_type = null,
            List<string> private_ip_address = null,
            List<string> public_ip_address = null,
            int offset = 0,
            int limit = 20)
        {
            int filterCount = 1;


            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal) { ["Version"] = "2017-03-12" };

            // 按照可用区过滤。
            if (zone != null && zone.Count > 0)
            {
                baseParams.Add($"Filters.{filterCount}.Name", "zone");
                for (int i = 0; i < zone.Count; i++)
                {
                    baseParams.Add($"Filters.{filterCount}.Values.{i}", zone[i]);
                }
                filterCount++;
            }

            // 按照项目ID过滤。
            if (project_id != null && project_id.Count > 0)
            {
                baseParams.Add($"Filters.{filterCount}.Name", "project-id");
                for (int i = 0; i < project_id.Count; i++)
                {
                    baseParams.Add($"Filters.{filterCount}.Values.{i}", project_id[i]);
                }
                filterCount++;
            }

            // 按照CDH ID过滤。CDH ID形如：host-11112222。
            if (host_id != null && host_id.Count > 0)
            {
                baseParams.Add($"Filters.{filterCount}.Name", "host-id");
                for (int i = 0; i < host_id.Count; i++)
                {
                    baseParams.Add($"Filters.{filterCount}.Values.{i}", host_id[i]);
                }
                filterCount++;
            }

            // 按照实例ID过滤。实例ID形如：ins-11112222。
            if (instance_id != null && instance_id.Count > 0)
            {
                baseParams.Add($"Filters.{filterCount}.Name", "instance-id");
                for (int i = 0; i < instance_id.Count; i++)
                {
                    baseParams.Add($"Filters.{filterCount}.Values.{i}", instance_id[i]);
                }
                filterCount++;
            }

            // 按照实例名称过滤。
            if (instance_name != null && instance_name.Count > 0)
            {
                baseParams.Add($"Filters.{filterCount}.Name", "instance-name");
                for (int i = 0; i < instance_name.Count; i++)
                {
                    baseParams.Add($"Filters.{filterCount}.Values.{i}", instance_name[i]);
                }
                filterCount++;
            }

            // 按照实例计费模式过滤。
            if (!string.IsNullOrWhiteSpace(instance_charge_type))
            {
                baseParams.Add($"Filters.{filterCount}.Name", "instance-charge-type");
                baseParams.Add($"Filters.{filterCount}.Values.1", instance_charge_type);
                filterCount++;
            }

            // 按照实例主网卡的内网IP过滤。
            if (private_ip_address != null && private_ip_address.Count > 0)
            {
                baseParams.Add($"Filters.{filterCount}.Name", "private-ip-address");
                for (int i = 0; i < private_ip_address.Count; i++)
                {
                    baseParams.Add($"Filters.{filterCount}.Values.{i}", private_ip_address[i]);
                }
                filterCount++;
            }

            // 按照实例主网卡的公网IP过滤，包含实例创建时自动分配的IP和实例创建后手动绑定的弹性IP。
            if (public_ip_address != null && public_ip_address.Count > 0)
            {
                baseParams.Add($"Filters.{filterCount}.Name", "public-ip-address");
                for (int i = 0; i < public_ip_address.Count; i++)
                {
                    baseParams.Add($"Filters.{filterCount}.Values.{i}", public_ip_address[i]);
                }
                filterCount++;
            }

            var returnJson = q.RequestAPi("DescribeInstances", baseParams, APIUrl.Cvm, r);
            var d = JsonConvert.DeserializeObject<CvmListReturnType>(returnJson);
            return d;
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
            List<string> zone = null,
            List<string> project_id = null,
            List<string> host_id = null,
            List<string> instance_id = null,
            List<string> instance_name = null,
            string instance_charge_type = null,
            List<string> private_ip_address = null,
            List<string> public_ip_address = null)
        {
            var temp = GetCVMList(q, r, zone, project_id, host_id, instance_id, instance_name, instance_charge_type, private_ip_address, public_ip_address, limit: 20);
            int count = temp.Response.TotalCount;
            CVMListResponseType c = new CVMListResponseType()
            {
                TotalCount = temp.Response.TotalCount,
                RequestId = temp.Response.RequestId,
                InstanceSet = new List<CVMInstanceSetInstanceType>()
            };
            if (count > 0)
            {
                // 整除得出循环次数,多循环一次获得剩余不满100条的db信息
                for (int i = 0; i <= count / 100; i++)
                {
                    var t = GetCVMList(q, r, zone, project_id, host_id, instance_id, instance_name, instance_charge_type, private_ip_address, public_ip_address, i * 100, 100);
                    if (t.Response.InstanceSet != null)
                    {
                        c.InstanceSet.AddRange(t.Response.InstanceSet);
                    }

                }
            }

            CvmListReturnType resp = new CvmListReturnType() { Response = c };

            return resp;
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
        public static BaseCvmOperationReturnType StopCvm(QCloudHelper q, List<string> cvmList, Region region, bool ForceStop = false)
        {
            var force = new SortedDictionary<string, object>();
            if (ForceStop)
            {
                force.Add("ForceStop", true);
            }
            return BaseCvmOperation(q, "StopInstances", cvmList, region, force);
        }

        /// <summary>
        /// 重启CVM
        /// </summary>
        /// <param name="q"></param>
        /// <param name="cvmList"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public static BaseCvmOperationReturnType RestartCvm(QCloudHelper q, List<string> cvmList, Region region, bool ForceReboot = false)
        {
            var force = new SortedDictionary<string, object>();
            if (ForceReboot)
            {
                force.Add("ForceReboot", true);
            }
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
        public static BaseCvmOperationReturnType BaseCvmOperation(QCloudHelper q, string actionList, List<string> cvmList, Region region, SortedDictionary<string, object> orderParams = null)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal) { { "Version", "2017-03-12" } };

            if (cvmList != null)
            {
                for (int i = 0; i < cvmList.Count; i++)
                {
                    baseParams.Add($"InstanceIds.{i}", cvmList[i]);
                }
            }

            // 添加其他参数,用于传递强制重启或强制关机
            if (orderParams != null && orderParams.Count > 0)
            {
                foreach (var item in orderParams)
                {
                    if (baseParams.ContainsKey(item.Key))
                    {
                        baseParams[item.Key] = item.Value;
                    }
                    else
                    {
                        baseParams.Add(item.Key, item.Value);
                    }
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
        public static BaseCvmOperationResponseType ReInstallCVM(
            QCloudHelper q,
            string instanceId,
            Region region,
            int imageType = 2,
            string imageId = null,
            CVMDiskType SystemDisk = null,
            CVMLoginSettingsType LoginSettings = null,
            CVMEnhancedServiceType EnhancedService = null)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                {"Version","2017-03-12" },
                { "InstanceId" ,instanceId}
            };

            if (imageType != 2)
            {
                baseParams.Add("imageType", imageType);
            }

            if (!string.IsNullOrWhiteSpace(imageId))
            {
                baseParams.Add("imageId", imageId);
            }

            // 实例系统盘配置
            if (SystemDisk != null)
            {
                baseParams.Add("SystemDisk", SystemDisk);
            }

            // 实例登录设置
            if (LoginSettings != null)
            {
                baseParams.Add("LoginSettings", LoginSettings);
            }

            // 增强服务
            if (EnhancedService != null)
            {
                baseParams.Add("EnhancedService", EnhancedService);
            }

            var returnJson = q.RequestAPi("ResetInstances", baseParams, APIUrl.Cvm, region);
            return JsonConvert.DeserializeObject<BaseCvmOperationResponseType>(returnJson);

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
        public static BaseCvmOperationResponseType RenameCVM(QCloudHelper q, Region region, List<string> instanceId, string instanceName)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                {"Version","2017-03-12" },
                { "instanceName" ,instanceName}
            };

            if (instanceId != null)
            {
                for (int i = 0; i < instanceId.Count; i++)
                {
                    baseParams.Add($"InstanceIds.{i}", instanceId[i]);
                }
            }

            var returnJson = q.RequestAPi("ModifyInstanceAttributes", baseParams, APIUrl.Cvm, region);
            return JsonConvert.DeserializeObject<BaseCvmOperationResponseType>(returnJson);

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
        public static BaseCvmOperationResponseType ResetCVMPassword(QCloudHelper q, Region region, List<string> instanceIds, string password, string username = null, bool forceStop = false)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal) {
                { "Version", "2017-03-12" },
                {"password", password },
                { "ForceStop",forceStop}
            };

            if (!string.IsNullOrWhiteSpace(username))
            {
                baseParams.Add("UserName", username);
            }

            if (instanceIds != null)
            {
                for (int i = 0; i < instanceIds.Count; i++)
                {
                    baseParams.Add($"instanceIds.{i}", instanceIds[i]);
                }
            }
            var returnJson = q.RequestAPi("ResetInstancePassword", baseParams, APIUrl.Cvm, region);
            return JsonConvert.DeserializeObject<BaseCvmOperationResponseType>(returnJson);
        }
        #endregion


        #region 退还CVM实例
        /// <summary>
        /// 退还实例
        /// </summary>
        /// <param name="q"></param>
        /// <param name="region"></param>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public static BaseCvmOperationResponseType TerminateCVM(QCloudHelper q, Region region, List<string> instanceId)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal) { { "Version", "2017-03-12" } };

            if (instanceId != null)
            {
                for (int i = 0; i < instanceId.Count; i++)
                {
                    baseParams.Add($"InstanceIds.{i}", instanceId[i]);
                }
            }

            var returnJson = q.RequestAPi("TerminateInstances", baseParams, APIUrl.Cvm, region);
            return JsonConvert.DeserializeObject<BaseCvmOperationResponseType>(returnJson);

        }
        #endregion

        #region 续费CVM实例
        /// <summary>
        /// 续费CVM实例
        /// </summary>
        /// <param name="q"></param>
        /// <param name="region"></param>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public static BaseCvmOperationResponseType RenewCVM(QCloudHelper q, Region region, List<string> instanceId, CVMInstanceChargePrepaidType InstanceChargePrepaid)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal) {
                { "Version", "2017-03-12" },
                { "InstanceChargePrepaid",InstanceChargePrepaid}
            };

            if (instanceId != null)
            {
                for (int i = 0; i < instanceId.Count; i++)
                {
                    baseParams.Add($"InstanceIds.{i}", instanceId[i]);
                }
            }

            var returnJson = q.RequestAPi("RenewInstances", baseParams, APIUrl.Cvm, region);
            return JsonConvert.DeserializeObject<BaseCvmOperationResponseType>(returnJson);

        }
        #endregion

        #region 查看CVM实例状态列表
        /// <summary>
        /// 查看CVM实例状态列表
        /// </summary>
        /// <param name="q"></param>
        /// <param name="region"></param>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public static CVMStatusReturnType StatusOfCVM(QCloudHelper q, Region region, List<string> instanceId, int Offset = 0, int Limit = 20)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal) {
                { "Version", "2017-03-12" },
                {"Offset",Offset },
                {"Limit",Limit }
            };

            if (instanceId != null)
            {
                for (int i = 0; i < instanceId.Count; i++)
                {
                    baseParams.Add($"InstanceIds.{i}", instanceId[i]);
                }
            }

            var returnJson = q.RequestAPi("DescribeInstancesStatus", baseParams, APIUrl.Cvm, region);
            return JsonConvert.DeserializeObject<CVMStatusReturnType>(returnJson);

        }
        #endregion
    }
}
