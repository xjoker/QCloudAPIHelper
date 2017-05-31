using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using static QCloudAPIHelper.APIEnum;

namespace QCloudAPIHelper.ModulesHelper
{
    /// <summary>
    /// 监控返回类
    /// </summary>
    public class MonitorType
    {
        public int code { get; set; }
        public string message { get; set; }
        public string codeDesc { get; set; }
        public string metricName { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int period { get; set; }
        public ArrayList dataPoints { get; set; }
    }

    /// <summary>
    /// 云监控帮助类
    /// </summary>
    public static class MonitorHelper
    {

        #region CVM 监控类
        /// <summary>
        /// 请求 qce/cvm 的CPU使用率
        /// cpu_usage
        /// </summary>
        public static MonitorType CVM_cpu_usage(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "cpu_usage", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的CPU平均负载
        /// cpu_usage
        /// </summary>
        public static MonitorType CVM_cpu_loadavg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "cpu_loadavg", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的内存使用量
        /// mem_used
        /// </summary>
        public static MonitorType CVM_mem_used(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "mem_used", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的内存利用率
        /// mem_usage
        /// </summary>
        public static MonitorType CVM_mem_usage(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "mem_usage", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的 磁盘读流量
        /// disk_read_traffic
        /// </summary>
        public static MonitorType CVM_disk_read_traffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "disk_read_traffic", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的磁盘写流量
        /// disk_write_traffic
        /// </summary>
        public static MonitorType CVM_disk_write_traffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "disk_write_traffic", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的 磁盘IO等待
        /// disk_io_await
        /// </summary>
        public static MonitorType CVM_disk_io_await(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "disk_io_await", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的 	内网出带宽
        /// lan_outtraffic
        /// </summary>
        public static MonitorType CVM_lan_outtraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(BaseMonitor(q, "qce/cvm", "lan_outtraffic", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 内网入带宽
        /// lan_intraffic
        /// </summary>
        public static MonitorType CVM_lan_intraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(BaseMonitor(q, "qce/cvm", "lan_intraffic", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的内网出包量
        /// lan_outpkg
        /// </summary>
        public static MonitorType CVM_lan_outpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(BaseMonitor(q, "qce/cvm", "lan_outpkg", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的内网入包量
        /// lan_inpkg
        /// </summary>
        public static MonitorType CVM_lan_inpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(BaseMonitor(q, "qce/cvm", "lan_inpkg", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的外网出带宽
        /// wan_outtraffic
        /// </summary>
        public static MonitorType CVM_wan_outtraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(BaseMonitor(q, "qce/cvm", "wan_outtraffic", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的外网入带宽
        /// wan_intraffic
        /// </summary>
        public static MonitorType CVM_wan_intraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(BaseMonitor(q, "qce/cvm", "wan_intraffic", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 外网出流量
        /// acc_outtraffic
        /// </summary>
        public static MonitorType CVM_acc_outtraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(BaseMonitor(q, "qce/cvm", "acc_outtraffic", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 外网出包量
        /// wan_outpkg
        /// </summary>
        public static MonitorType CVM_wan_outpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(BaseMonitor(q, "qce/cvm", "wan_outpkg", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 外网入包量
        /// wan_inpkg
        /// </summary>
        public static MonitorType CVM_wan_inpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(BaseMonitor(q, "qce/cvm", "wan_inpkg", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 转换带宽内的数据
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private static MonitorType CVM_TrafficConvert(MonitorType b)
        {
            MonitorType c = b;
            if (b.code == 0)
            {
                ArrayList a = new ArrayList();
                foreach (var item in b.dataPoints)
                {
                    if (item != null)
                    {
                        a.Add(double.Parse(item.ToString()));
                    }
                    else
                    {
                        a.Add(null);
                    }
                }
                c.dataPoints = a;
            }
            return c;
        }
        #endregion

        #region 云数据库MySQL 监控类

        /// <summary>
        /// 慢查询数
        /// </summary>
        public static MonitorType CDB_slow_queries(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "slow_queries", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 最大连接数
        /// </summary>
        public static MonitorType CDB_max_connections(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "max_connections", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 全表扫描数
        /// </summary>
        public static MonitorType CDB_select_scan(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "select_scan", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 查询数
        /// </summary>
        public static MonitorType CDB_select_count(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "select_count", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 更新数
        /// </summary>
        public static MonitorType CDB_com_update(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "com_update", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 删除数
        /// </summary>
        public static MonitorType CDB_com_delete(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "com_delete", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 插入数
        /// </summary>
        public static MonitorType CDB_com_insert(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "com_insert", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 覆盖数
        /// </summary>
        public static MonitorType CDB_com_replace(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "com_replace", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 总请求数
        /// </summary>
        public static MonitorType CDB_queries(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "queries", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 当前打开连接数
        /// </summary>
        public static MonitorType CDB_threads_connected(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "threads_connected", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 磁盘使用空间
        /// </summary>
        public static MonitorType CDB_real_capacity(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "real_capacity", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 磁盘占用空间
        /// </summary>
        public static MonitorType CDB_capacity(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "capacity", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 内网出流量
        /// </summary>
        public static MonitorType CDB_bytes_sent(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "bytes_sent", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 内网入流量
        /// </summary>
        public static MonitorType CDB_bytes_received(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "bytes_received", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 缓存使用率
        /// </summary>
        public static MonitorType CDB_qcache_use_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "qcache_use_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 缓存命中率
        /// </summary>
        public static MonitorType CDB_qcache_hit_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "qcache_hit_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 等待表锁次数
        /// </summary>
        public static MonitorType CDB_table_locks_waited(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "table_locks_waited", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 临时表数量
        /// </summary>
        public static MonitorType CDB_created_tmp_tables(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "created_tmp_tables", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// innodb缓存使用率
        /// </summary>
        public static MonitorType CDB_innodb_cache_use_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "innodb_cache_use_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// innodb缓存命中率
        /// </summary>
        public static MonitorType CDB_innodb_cache_hit_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "innodb_cache_hit_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// innodb读磁盘数量
        /// </summary>
        public static MonitorType CDB_innodb_os_file_reads(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "innodb_os_file_reads", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// innodb写磁盘数量
        /// </summary>
        public static MonitorType CDB_innodb_os_file_writes(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "innodb_os_file_writes", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// innodb fsync数量
        /// </summary>
        public static MonitorType CDB_innodb_os_fsyncs(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "innodb_os_fsyncs", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// myisam缓存使用率
        /// </summary>
        public static MonitorType CDB_key_cache_use_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "key_cache_use_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 	myisam缓存命中率
        /// </summary>
        public static MonitorType CDB_key_cache_hit_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "key_cache_hit_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 容量使用率
        /// </summary>
        public static MonitorType CDB_volume_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "volume_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 查询使用率
        /// </summary>
        public static MonitorType CDB_query_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "query_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 每秒执行操作数
        /// </summary>
        public static MonitorType CDB_qps(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "qps", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 每秒执行事务数
        /// </summary>
        public static MonitorType CDB_tps(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "tps", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// CPU占比
        /// </summary>
        public static MonitorType CDB_cpu_use_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "cpu_use_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 内存占用
        /// </summary>
        public static MonitorType CDB_memory_use(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cdb", "memory_use", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        #endregion

        #region 云数据库 TDSQL(MariaDB) 监控类
        /// <summary>
        /// 数据磁盘可用大小
        /// </summary>
        public static MonitorType TDSQL_data_disk_available(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "data_disk_available", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// BINLOG磁盘可用大小
        /// </summary>
        public static MonitorType TDSQL_binlog_disk_available(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "binlog_disk_available", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// SELECT请求总数
        /// </summary>
        public static MonitorType TDSQL_select_total(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "select_total", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// SELECT慢查询数
        /// </summary>
        public static MonitorType TDSQL_long_query(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "long_query", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// UPDATE请求总数
        /// </summary>
        public static MonitorType TDSQL_update_total(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "update_total", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// INSERT请求总数
        /// </summary>
        public static MonitorType TDSQL_insert_total(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "insert_total", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// DELETE请求总数
        /// </summary>
        public static MonitorType TDSQL_delete_total(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "delete_total", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 内存可用大小
        /// </summary>
        public static MonitorType TDSQL_mem_available(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "mem_available", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 磁盘IOPS
        /// </summary>
        public static MonitorType TDSQL_disk_iops(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "disk_iops", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 活跃连接数
        /// </summary>
        public static MonitorType TDSQL_conn_active(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "conn_active", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 连接数
        /// </summary>
        public static MonitorType TDSQL_conn_running(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "conn_running", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 监控是否主备切换
        /// </summary>
        public static MonitorType TDSQL_is_mater_switched(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "is_mater_switched", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// CPU使用率
        /// </summary>
        public static MonitorType TDSQL_cpu_usage_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/tdsql", "cpu_usage_rate", "uuid", unInstanceId, c, startTime, endTime, p);
        }
        #endregion

        /// <summary>
        /// 监控请求基础类
        /// </summary>
        public static MonitorType BaseMonitor(QCloudHelper q, string qCloudNamespace, string metricName,string dimensionsName, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            if (string.IsNullOrWhiteSpace(unInstanceId)) throw new ArgumentNullException(nameof(unInstanceId));

            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                ["namespace"] = qCloudNamespace,
                ["metricName"] = metricName,
                ["dimensions.0.name"]=dimensionsName,
                ["dimensions.0.value"] = unInstanceId,
                ["period"] = (int)p,
                ["startTime"] = startTime.DateTimeConvertQCloudFormat(),
                ["endTime"] = endTime.DateTimeConvertQCloudFormat()
            };


            var returnJson = q.RequestAPi("GetMonitorData", baseParams, APIUrl.Monitor, c);
            return JsonConvert.DeserializeObject<MonitorType>(returnJson);
        }
    }
}
