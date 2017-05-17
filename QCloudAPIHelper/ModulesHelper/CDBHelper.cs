using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static QCloudAPIHelper.APIEnum;

namespace QCloudAPIHelper.ModulesHelper
{
    /// <summary>
    /// 查询实例列表输出参数
    /// </summary>
    public class CDBListRetrunType
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
        /// <summary>
        /// 符合查询条件的实例总数
        /// </summary>
        public int totalCount { get; set; }
        /// <summary>
        /// 返回的实例信息
        /// </summary>
        public List<CDBInstanceSetType> cdbInstanceSet { get; set; }
    }

    /// <summary>
    /// cdbInstanceSet 参数
    /// </summary>
    public class CDBInstanceSetType
    {
        /// <summary>
        /// 实例ID，格式如：cdb-c1nl9rpv。与云数据库控制台页面显示的实例ID相同，可用于查询或操作实例。推荐使用
        /// </summary>
        public string uInstanceId { get; set; }
        /// <summary>
        /// 实例 UUID （已废弃），推荐使用 uInstanceId 替代。实例创建成功后才生成实例 UUID ，创建中的实例只包含 uInstanceId。
        /// </summary>
        public string cdbInstanceId { get; set; }
        /// <summary>
        /// 实例初始化标记，可能返回值：0-未初始化；1-已初始化
        /// </summary>
        public int initFlag { get; set; }
        /// <summary>
        /// 实例类型，可能返回值：1-主实例；2-灾备实例
        /// </summary>
        public int cdbInstanceType { get; set; }
        /// <summary>
        /// 实例存储容量，同 volume 字段值相同，推荐使用 volume 字段，单位：G
        /// </summary>
        public int storageSize { get; set; }
        /// <summary>
        /// 实例最大查询次数，单位：次/秒
        /// </summary>
        public int maxQueryCount { get; set; }
        /// <summary>
        /// 实例名称
        /// </summary>
        public string cdbInstanceName { get; set; }
        /// <summary>
        /// 实例访问IP
        /// </summary>
        public string cdbInstanceVip { get; set; }
        /// <summary>
        /// 实例访问端口
        /// </summary>
        public int cdbInstanceVport { get; set; }
        /// <summary>
        /// 外网访问状态，可能返回值：0-未开通 1-已开通 2-已关闭 3-处理中
        /// </summary>
        public int cdbWanStatus { get; set; }
        /// <summary>
        /// 外网访问域名
        /// </summary>
        public string cdbWanDomain { get; set; }
        /// <summary>
        /// 外网访问端口
        /// </summary>
        public int cdbWanPort { get; set; }
        /// <summary>
        /// 实例状态，可能返回值： 0-创建中 1-运行中 4-删除中 5-隔离中 101-锁定中
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 实例任务状态，可能返回值：
        ///0-没有任务
        ///1-升级中
        ///2-数据导入中
        ///3-开放Slave中
        ///4-外网访问开通中
        ///5-批量操作执行中
        ///6-回档中
        ///7-外网访问关闭中
        ///8-密码修改中
        ///9-实例名修改中
        ///10-重启中
        ///12-自建迁移中
        ///13-删除库表中
        ///14-灾备实例创建同步中
        /// </summary>
        public int taskStatus { get; set; }
        /// <summary>
        /// 实例数据库引擎版本，可能返回值：5.1、5.5和5.6
        /// </summary>
        public string engineVersion { get; set; }
        /// <summary>
        /// 实例创建时间，时间格式：yyyy-mm-dd hh:mm:ss
        /// </summary>
        public string cdbInstanceCreateTime { get; set; }
        /// <summary>
        /// 实例到期时间，如实例为按量计费模式，则此字段值为0000-00-00 00:00:00。时间格式：yyyy-mm-dd hh:mm:ss
        /// </summary>
        public string cdbInstanceDeadlineTime { get; set; }
        /// <summary>
        /// 实例类型的序号，可用此参数购买同类型实例或者查询同类型实例的续费价格
        /// </summary>
        public string cdbTypeSet { get; set; }
        /// <summary>
        /// 实例规格描述，如：CUSTOM ，请使用查询可创建规格接口查询cdbType详情
        /// </summary>
        public string cdbType { get; set; }
        /// <summary>
        /// 实例内存大小，单位：MB
        /// </summary>
        public int memory { get; set; }
        /// <summary>
        /// 实例硬盘大小，单位：GB
        /// </summary>
        public int volume { get; set; }
        /// <summary>
        /// 自动续费标记，可能返回值：0-不自动续费；1-自动续费
        /// </summary>
        public int autoRenew { get; set; }
        /// <summary>
        /// 实例所在可用区ID
        /// </summary>
        public int zoneId { get; set; }
        /// <summary>
        /// 实例所在私有网络ID，请使用查询私有网络列表
        /// </summary>
        public int vpcId { get; set; }
        /// <summary>
        /// 实例所在私有网络子网ID，请使用查询私有网络列表
        /// </summary>
        public int subnetId { get; set; }
        /// <summary>
        /// 实例所在项目ID，请使用查询项目列表接口获取项目ID
        /// </summary>
        public int projectId { get; set; }
        /// <summary>
        /// 实例计费类型，可能返回值：0-包年包月；1-按量计费；2-后付费月结
        /// </summary>
        public int payType { get; set; }
        /// <summary>
        /// 主实例信息，如实例是灾备实例或只读实例，则该字段返回其主实例信息，否则返回null
        /// </summary>
        public List<MasterInfoType> masterInfo { get; set; }
        /// <summary>
        /// 只读实例信息
        /// </summary>
        public List<RoInfoType> roInfo { get; set; }
        /// <summary>
        /// 灾备实例信息
        /// </summary>
        public List<DrInfoType> drInfo { get; set; }
        /// <summary>
        /// 数据保护方式
        /// </summary>
        public int protectMode { get; set; }
        /// <summary>
        /// 备库1可用区Id
        /// </summary>
        public int slaveZoneFirst { get; set; }
        /// <summary>
        /// 备库2可用区Id,若无则为0
        /// </summary>
        public int slaveZoneSecond { get; set; }
        /// <summary>
        /// 备库2的IP，若无则为空
        /// </summary>
        public string slaveSecondVip { get; set; }
        /// <summary>
        /// 备库2的端口，若无则为0
        /// </summary>
        public int slaveSecondVport { get; set; }
        /// <summary>
        /// 部署方式，0为单可用部署，1为多可用区部署
        /// </summary>
        public int deployMode { get; set; }
        /// <summary>
        /// binglog大小，单位：GB
        /// </summary>
        public int binlogSize { get; set; }
    }

    /// <summary>
    /// masterInfo 参数
    /// </summary>
    public class MasterInfoType
    {
        /// <summary>
        /// 区域ID，详见公共请求参数
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 实例所在可用区ID
        /// </summary>
        public int zoneId { get; set; }
        /// <summary>
        /// 实例ID，实例唯一标识。功能同cdbInstanceId字段。推荐使用
        /// </summary>
        public string uInstanceId { get; set; }
        /// <summary>
        /// 实例状态，可能返回值：
        ///0-创建中
        ///1-运行中
        ///4-删除中
        ///5-隔离中
        /// </summary>
        public int status { get; set; }
    }

    /// <summary>
    ///  roInfo 参数
    /// </summary>
    public class RoInfoType
    {
        /// <summary>
        /// 区域ID，详见公共请求参数
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 实例所在可用区ID
        /// </summary>
        public int zoneId { get; set; }
        /// <summary>
        /// 实例ID，实例唯一标识。功能同cdbInstanceId字段。推荐使用
        /// </summary>
        public string uInstanceId { get; set; }
        /// <summary>
        /// 只读实例状态，可能返回值：
        ///0-创建中
        ///1-运行中
        ///4-删除中
        ///5-隔离中
        /// </summary>
        public int status { get; set; }
    }

    /// <summary>
    ///  drInfo 参数
    /// </summary>
    public class DrInfoType
    {
        /// <summary>
        /// 区域ID，详见公共请求参数
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 实例所在可用区ID
        /// </summary>
        public int zoneId { get; set; }
        /// <summary>
        /// 实例ID，实例唯一标识。功能同cdbInstanceId字段。推荐使用
        /// </summary>
        public string uInstanceId { get; set; }
        /// <summary>
        ///实例状态，可能返回值：
        ///0-创建中
        ///1-运行中
        ///4-删除中
        ///5-隔离中
        /// </summary>
        public int status { get; set; }
        /// <summary>
        ///同步状态，可能返回值：
        ///0-未同步
        ///1-创建同步中
        ///2-创建同步完成
        ///3-同步失败
        ///4-同步修复中
        /// </summary>
        public int syncStatus { get; set; }
    }

    public static class CDBHelper
    {
        /// <summary>
        /// 查询实例列表 输入参数
        /// </summary>
        /// <param name="q"></param>
        /// <param name="projectId">项目ID，请使用查询项目列表接口查询项目ID</param>
        /// <param name="status">实例状态，默认值为1，一个或者多个状态值，n表示从0开始的数组下标，值包括： 0-创建中 1-运行中 4-删除中 5-隔离中</param>
        /// <param name="cdbInstanceIds">一个或者多个实例ID，格式如：cdb-c1nl9rpv。与云数据库控制台页面中显示的实例ID相同，可使用查询实例列表 接口获取，其值为输出参数中字段 uInstanceId 的值。</param>
        /// <param name="cdbInstanceVips">一个或者多个实例访问地址，n表示从0开始的数组下标。请使用查询实例列表接口查询云数据库实例访问地址</param>
        /// <param name="offset">记录偏移量，默认值为0</param>
        /// <param name="limit">单次请求返回的数量，默认值为20，最大值为100</param>
        /// <returns></returns>
        public static CDBListRetrunType CDBInstanceList(
            QCloudHelper q,
            Region r,
            int? projectId = null,
            List<int> status = null,
            List<string> cdbInstanceIds = null,
            List<string> cdbInstanceVips = null,
            int offset = 0,
            int limit = 20
            )
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "offset", offset },
                { "limit", limit }
            };

            if (projectId != null)
            {
                baseParams.Add("projectId", projectId);
            }

            if (cdbInstanceIds != null)
            {
                for (int i = 0; i < cdbInstanceIds.Count; i++)
                {
                    baseParams.Add($"cdbInstanceIds.{i}", cdbInstanceIds[i]);
                }
            }

            if (cdbInstanceVips != null)
            {
                for (int i = 0; i < cdbInstanceVips.Count; i++)
                {
                    baseParams.Add($"cdbInstanceVips.{i}", cdbInstanceVips[i]);
                }
            }

            if (status != null)
            {
                for (int i = 0; i < status.Count; i++)
                {
                    baseParams.Add($"status.{i}", status[i]);
                }
            }

            var returnJson = q.RequestAPi("DescribeCdbInstances", baseParams, APIUrl.Cdb, r);
            return JsonConvert.DeserializeObject<CDBListRetrunType>(returnJson);
        }

        /// <summary>
        /// 查询所有实例列表 输入参数
        /// </summary>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="projectId">项目ID，请使用查询项目列表接口查询项目ID</param>
        /// <param name="status">实例状态，默认值为1，一个或者多个状态值，n表示从0开始的数组下标，值包括： 0-创建中 1-运行中 4-删除中 5-隔离中</param>
        /// <param name="cdbInstanceIds">一个或者多个实例ID，格式如：cdb-c1nl9rpv。与云数据库控制台页面中显示的实例ID相同，可使用查询实例列表 接口获取，其值为输出参数中字段 uInstanceId 的值。</param>
        /// <param name="cdbInstanceVips">一个或者多个实例访问地址，n表示从0开始的数组下标。请使用查询实例列表接口查询云数据库实例访问地址</param>
        /// <returns></returns>
        public static CDBListRetrunType CDBInstanceAllList(
            QCloudHelper q,
            Region r,
            int? projectId = null,
            List<int> status = null,
            List<string> cdbInstanceIds = null,
            List<string> cdbInstanceVips = null
            )
        {

            var temp = CDBInstanceList(q, r, projectId, status, cdbInstanceIds, cdbInstanceVips, limit: 20);
            int count = temp.totalCount;
            CDBListRetrunType c = new CDBListRetrunType()
            {
                totalCount = temp.totalCount,
                message = temp.message,
                codeDesc = temp.codeDesc,
                code = temp.code,
                cdbInstanceSet = new List<CDBInstanceSetType>()

            };
            if (count > 0)
            {
                // 整除得出循环次数,多循环一次获得剩余不满100条的db信息
                for (int i = 0; i <= count / 100; i++)
                {
                    var t = CDBInstanceList(q, r, projectId, status, cdbInstanceIds, cdbInstanceVips, i * 100, 100);
                    if (t.cdbInstanceSet != null)
                    {
                        c.cdbInstanceSet.AddRange(t.cdbInstanceSet);
                    }

                }
            }

            return c;
        }
    }
}
