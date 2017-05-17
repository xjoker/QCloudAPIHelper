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
    /// 查询实例列表输出参数
    /// </summary>
    public class RedisListRetrunType
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
        /// 业务侧错误码英文描述。成功时返回Success，错误时返回具体业务错误原因
        /// </summary>
        public string codeDesc { get; set; }
        /// <summary>
        /// 实例数
        /// </summary>
        public int totalCount { get; set; }

        public RedisDataType data { get; set; }
    }
    public class RedisDataType
    {
        public List<RedisDataRedisSetType> redisSet { get; set; }
    }
    public class RedisDataRedisSetType
    {
        /// <summary>
        /// 实例名称
        /// </summary>
        public string redisName { get; set; }
        /// <summary>
        /// 实例唯一串号
        /// </summary>
        public string redisId { get; set; }
        /// <summary>
        /// appid
        /// </summary>
        public int appid { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        public int projectId { get; set; }
        /// <summary>
        /// 地域id 1--广州 4--上海 5-- 香港 6--多伦多 7--上海金融 8--北京 9-- 新加坡 11--深圳金融 15--美西（硅谷）
        /// </summary>
        public int regionId { get; set; }
        /// <summary>
        /// 区域id
        /// </summary>
        public int zoneId { get; set; }
        /// <summary>
        /// vpc网络id，不推荐使用
        /// </summary>
        public int vpcId { get; set; }
        /// <summary>
        /// vpc网络id，推荐使用
        /// </summary>
        public string unVpcId { get; set; }
        /// <summary>
        /// vpc网络下子网id，不推荐使用
        /// </summary>
        public int subnetId { get; set; }
        /// <summary>
        /// vpc网络下子网id，推荐使用
        /// </summary>
        public string unSubnetId { get; set; }
        /// <summary>
        /// 实例当前状态，0：待初始化；1：实例在流程中；2：实例运行中；-2：实例已隔离
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 实例状态描述
        /// </summary>
        public string statusDesc { get; set; }
        /// <summary>
        /// 实例vip
        /// </summary>
        public string wanIp { get; set; }
        /// <summary>
        /// 实例端口号
        /// </summary>
        public int port { get; set; }
        /// <summary>
        /// 实例创建时间
        /// </summary>
        public string createtime { get; set; }
        /// <summary>
        /// 实例容量大小，单位：MB
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 实例当前已使用容量，单位：MB
        /// 腾讯云API中定义为int 实际返回为String类型
        /// </summary>
        public string sizeUsed { get; set; }
        /// <summary>
        /// 实例类型，1：集群版；2：单机版
        /// </summary>
        public int typeId { get; set; }
        /// <summary>
        /// 实例类型描述
        /// </summary>
        public String typeIddesc { get; set; }
        /// <summary>
        /// 实例是否设置自动续费标识，1：设置自动续费；0：未设置自动续费
        /// </summary>
        public int autoRenewFlag { get; set; }
        /// <summary>
        /// 实例到期时间
        /// </summary>
        public string deadlineTime { get; set; }
    }

    public static class RedisHelper
    {
        /// <summary>
        /// Redis 实例获取
        /// </summary>
        /// <param name="q"></param>
        /// <param name="limit">分页大小</param>
        /// <param name="offset">当前页码</param>
        /// <param name="redisId">实例Id</param>
        /// <param name="redisName">实例名称</param>
        /// <param name="orderBy">枚举范围redisId,projectId,createtime</param>
        /// <param name="orderType">1倒序，0顺序，默认倒序</param>
        /// <param name="vpcIds">历史原因，仍保留该参数，推荐使用下面参数unVpcIds。 私有网络ID数组，数组下标从0开始，如果不传则默认选择基础网络。</param>
        /// <param name="unVpcIds">私有网络ID数组，数组下标从0开始，如果不传则默认选择基础网络。请使用私有网络列表 查询返回的unVpcId为准，如：vpc-kd7d06of</param>
        /// <param name="subnetIds">历史原因，仍保留该参数，推荐使用下面参数unSubnetIds。私有网络下的子网ID数组，数组下标从0开始</param>
        /// <param name="unSubnetIds">子网ID数组，数组下标从0开始。 vpc子网下，取值以查询查询子网列表 返回的unSubnetId为准，如：subnet-3lzrkspo</param>
        /// <param name="projectIds">项目ID 组成的数组，数组下标从0开始</param>
        /// <returns></returns>
        public static RedisListRetrunType RedisInstanceList(
            QCloudHelper q,
            int limit,
            int offset,
            string redisId = null,
            string redisName = null,
            string orderBy = null,
            int? orderType = null,
            List<int?> vpcIds = null,
            List<int?> unVpcIds = null,
            List<int?> subnetIds = null,
            List<int?> unSubnetIds = null,
            List<int?> projectIds = null)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "offset", offset },
                { "limit", limit }
            };

            if (redisId != null)
            {
                baseParams.Add("redisId", redisId);
            }

            if (redisName != null)
            {
                baseParams.Add("redisName", redisName);
            }

            if (orderBy != null)
            {
                baseParams.Add("orderBy", orderBy);
            }

            if (orderType != null)
            {
                baseParams.Add("orderType", orderType);
            }

            if (vpcIds != null)
            {
                for (int i = 0; i < vpcIds.Count; i++)
                {
                    baseParams.Add($"vpcIds.{i}", vpcIds[i]);
                }
            }

            if (unVpcIds != null)
            {
                for (int i = 0; i < unVpcIds.Count; i++)
                {
                    baseParams.Add($"unVpcIds.{i}", unVpcIds[i]);
                }
            }

            if (subnetIds != null)
            {
                for (int i = 0; i < subnetIds.Count; i++)
                {
                    baseParams.Add($"subnetIds.{i}", subnetIds[i]);
                }
            }

            if (unSubnetIds != null)
            {
                for (int i = 0; i < unSubnetIds.Count; i++)
                {
                    baseParams.Add($"unSubnetIds.{i}", unSubnetIds[i]);
                }
            }

            if (projectIds != null)
            {
                for (int i = 0; i < projectIds.Count; i++)
                {
                    baseParams.Add($"projectIds.{i}", projectIds[i]);
                }
            }

            var returnJson = q.RequestAPi("DescribeRedis", baseParams, APIUrl.Redis);
            return JsonConvert.DeserializeObject<RedisListRetrunType>(returnJson);
        }

        /// <summary>
        /// Redis 获取所有实例
        /// </summary>
        /// <param name="q"></param>
        /// <param name="redisId">实例Id</param>
        /// <param name="redisName">实例名称</param>
        /// <param name="orderBy">枚举范围redisId,projectId,createtime</param>
        /// <param name="orderType">1倒序，0顺序，默认倒序</param>
        /// <param name="vpcIds">历史原因，仍保留该参数，推荐使用下面参数unVpcIds。 私有网络ID数组，数组下标从0开始，如果不传则默认选择基础网络。</param>
        /// <param name="unVpcIds">私有网络ID数组，数组下标从0开始，如果不传则默认选择基础网络。请使用私有网络列表 查询返回的unVpcId为准，如：vpc-kd7d06of</param>
        /// <param name="subnetIds">历史原因，仍保留该参数，推荐使用下面参数unSubnetIds。私有网络下的子网ID数组，数组下标从0开始</param>
        /// <param name="unSubnetIds">子网ID数组，数组下标从0开始。 vpc子网下，取值以查询查询子网列表 返回的unSubnetId为准，如：subnet-3lzrkspo</param>
        /// <param name="projectIds">项目ID 组成的数组，数组下标从0开始</param>
        /// <returns></returns>
        public static RedisListRetrunType RedisInstanceAllList(
            QCloudHelper q,
            string redisId = null,
            string redisName = null,
            string orderBy = null,
            int? orderType = null,
            List<int?> vpcIds = null,
            List<int?> unVpcIds = null,
            List<int?> subnetIds = null,
            List<int?> unSubnetIds = null,
            List<int?> projectIds = null
            )
        {
            var temp = RedisInstanceList(q, 1, 0, redisId, redisName, orderBy, orderType, vpcIds, unVpcIds, subnetIds, unSubnetIds, projectIds);
            int count = temp.totalCount;
            RedisListRetrunType r = new RedisListRetrunType()
            {
                totalCount = temp.totalCount,
                code = temp.code,
                codeDesc = temp.codeDesc,
                message = temp.message,
                data = new RedisDataType() { redisSet = new List<RedisDataRedisSetType>() }
            };
            if (count > 0)
            {
                // 整除得出循环次数,多循环一次获得剩余不满10条的redis信息
                for (int i = 0; i <= count / 10; i++)
                {
                    var t = RedisInstanceList(q, 10, i * 10, redisId, redisName, orderBy, orderType, vpcIds, unVpcIds, subnetIds, unSubnetIds, projectIds);
                    if (t.data.redisSet != null)
                    {
                        r.data.redisSet.AddRange(t.data.redisSet);
                    }

                }
            }
            return r;

        }
    }
}
