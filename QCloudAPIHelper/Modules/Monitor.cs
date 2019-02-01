using Newtonsoft.Json;
using QCloudAPIHelper.Base;
using System;
using System.Collections;
using System.Collections.Generic;

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
    /// 多对象监控返回类
    /// </summary>
    public class MultiMonitorType
    {
        public int code { get; set; }
        public string message { get; set; }
        public string codeDesc { get; set; }
        public string metricName { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int period { get; set; }
        public Dictionary<string, ArrayList> dataPoints { get; set; }
    }

    /// <summary>
    /// 云监控帮助类
    /// </summary>
    public static class Monitor
    {
        #region CVM 监控类

        /// <summary>
        /// 请求 qce/cvm 的CPU使用率
        /// cpu_usage
        /// </summary>
        public static MonitorType CVM_cpu_usage(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cvm", "cpu_usage", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的CPU平均负载
        /// cpu_usage
        /// </summary>
        public static MonitorType CVM_cpu_loadavg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cvm", "cpu_loadavg", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的内存使用量
        /// mem_used
        /// </summary>
        public static MonitorType CVM_mem_used(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cvm", "mem_used", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的内存利用率
        /// mem_usage
        /// </summary>
        public static MonitorType CVM_mem_usage(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cvm", "mem_usage", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的 磁盘读流量
        /// disk_read_traffic
        /// </summary>
        public static MonitorType CVM_disk_read_traffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cvm", "disk_read_traffic", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的磁盘写流量
        /// disk_write_traffic
        /// </summary>
        public static MonitorType CVM_disk_write_traffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cvm", "disk_write_traffic", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的 磁盘IO等待
        /// disk_io_await
        /// </summary>
        public static MonitorType CVM_disk_io_await(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cvm", "disk_io_await", "unInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的 	内网出带宽
        /// lan_outtraffic
        /// </summary>
        public static MonitorType CVM_lan_outtraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(SimpleBaseMonitor(q, "qce/cvm", "lan_outtraffic", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 内网入带宽
        /// lan_intraffic
        /// </summary>
        public static MonitorType CVM_lan_intraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(SimpleBaseMonitor(q, "qce/cvm", "lan_intraffic", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的内网出包量
        /// lan_outpkg
        /// </summary>
        public static MonitorType CVM_lan_outpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(SimpleBaseMonitor(q, "qce/cvm", "lan_outpkg", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的内网入包量
        /// lan_inpkg
        /// </summary>
        public static MonitorType CVM_lan_inpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(SimpleBaseMonitor(q, "qce/cvm", "lan_inpkg", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的外网出带宽
        /// wan_outtraffic
        /// </summary>
        public static MonitorType CVM_wan_outtraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(SimpleBaseMonitor(q, "qce/cvm", "wan_outtraffic", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的外网入带宽
        /// wan_intraffic
        /// </summary>
        public static MonitorType CVM_wan_intraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(SimpleBaseMonitor(q, "qce/cvm", "wan_intraffic", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 外网出流量
        /// acc_outtraffic
        /// </summary>
        public static MonitorType CVM_acc_outtraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(SimpleBaseMonitor(q, "qce/cvm", "acc_outtraffic", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 外网出包量
        /// wan_outpkg
        /// </summary>
        public static MonitorType CVM_wan_outpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(SimpleBaseMonitor(q, "qce/cvm", "wan_outpkg", "unInstanceId", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 外网入包量
        /// wan_inpkg
        /// </summary>
        public static MonitorType CVM_wan_inpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return CVM_TrafficConvert(SimpleBaseMonitor(q, "qce/cvm", "wan_inpkg", "unInstanceId", unInstanceId, c, startTime, endTime, p));
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

        #endregion CVM 监控类

        #region 云数据库MySQL 监控类

        /// <summary>
        /// 慢查询数
        /// </summary>
        public static MonitorType CDB_slow_queries(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "slow_queries", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 最大连接数
        /// </summary>
        public static MonitorType CDB_max_connections(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "max_connections", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 全表扫描数
        /// </summary>
        public static MonitorType CDB_select_scan(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "select_scan", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 查询数
        /// </summary>
        public static MonitorType CDB_select_count(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "select_count", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 更新数
        /// </summary>
        public static MonitorType CDB_com_update(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "com_update", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 删除数
        /// </summary>
        public static MonitorType CDB_com_delete(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "com_delete", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 插入数
        /// </summary>
        public static MonitorType CDB_com_insert(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "com_insert", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 覆盖数
        /// </summary>
        public static MonitorType CDB_com_replace(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "com_replace", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 总请求数
        /// </summary>
        public static MonitorType CDB_queries(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "queries", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 当前打开连接数
        /// </summary>
        public static MonitorType CDB_threads_connected(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "threads_connected", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 磁盘使用空间
        /// </summary>
        public static MonitorType CDB_real_capacity(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "real_capacity", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 磁盘占用空间
        /// </summary>
        public static MonitorType CDB_capacity(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "capacity", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 内网出流量
        /// </summary>
        public static MonitorType CDB_bytes_sent(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "bytes_sent", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 内网入流量
        /// </summary>
        public static MonitorType CDB_bytes_received(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "bytes_received", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 缓存使用率
        /// </summary>
        public static MonitorType CDB_qcache_use_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "qcache_use_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 缓存命中率
        /// </summary>
        public static MonitorType CDB_qcache_hit_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "qcache_hit_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 等待表锁次数
        /// </summary>
        public static MonitorType CDB_table_locks_waited(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "table_locks_waited", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 临时表数量
        /// </summary>
        public static MonitorType CDB_created_tmp_tables(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "created_tmp_tables", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// innodb缓存使用率
        /// </summary>
        public static MonitorType CDB_innodb_cache_use_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "innodb_cache_use_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// innodb缓存命中率
        /// </summary>
        public static MonitorType CDB_innodb_cache_hit_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "innodb_cache_hit_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// innodb读磁盘数量
        /// </summary>
        public static MonitorType CDB_innodb_os_file_reads(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "innodb_os_file_reads", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// innodb写磁盘数量
        /// </summary>
        public static MonitorType CDB_innodb_os_file_writes(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "innodb_os_file_writes", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// innodb fsync数量
        /// </summary>
        public static MonitorType CDB_innodb_os_fsyncs(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "innodb_os_fsyncs", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// myisam缓存使用率
        /// </summary>
        public static MonitorType CDB_key_cache_use_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "key_cache_use_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 	myisam缓存命中率
        /// </summary>
        public static MonitorType CDB_key_cache_hit_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "key_cache_hit_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 容量使用率
        /// </summary>
        public static MonitorType CDB_volume_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "volume_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 查询使用率
        /// </summary>
        public static MonitorType CDB_query_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "query_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 每秒执行操作数
        /// </summary>
        public static MonitorType CDB_qps(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "qps", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 每秒执行事务数
        /// </summary>
        public static MonitorType CDB_tps(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "tps", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// CPU占比
        /// </summary>
        public static MonitorType CDB_cpu_use_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "cpu_use_rate", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 内存占用
        /// </summary>
        public static MonitorType CDB_memory_use(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/cdb", "memory_use", "uInstanceId", unInstanceId, c, startTime, endTime, p);
        }

        #endregion 云数据库MySQL 监控类

        #region 云数据库 TDSQL(MariaDB) 监控类

        /// <summary>
        /// 数据磁盘可用大小
        /// </summary>
        public static MonitorType TDSQL_data_disk_available(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "data_disk_available", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// BINLOG磁盘可用大小
        /// </summary>
        public static MonitorType TDSQL_binlog_disk_available(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "binlog_disk_available", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// SELECT请求总数
        /// </summary>
        public static MonitorType TDSQL_select_total(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "select_total", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// SELECT慢查询数
        /// </summary>
        public static MonitorType TDSQL_long_query(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "long_query", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// UPDATE请求总数
        /// </summary>
        public static MonitorType TDSQL_update_total(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "update_total", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// INSERT请求总数
        /// </summary>
        public static MonitorType TDSQL_insert_total(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "insert_total", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// DELETE请求总数
        /// </summary>
        public static MonitorType TDSQL_delete_total(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "delete_total", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 内存可用大小
        /// </summary>
        public static MonitorType TDSQL_mem_available(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "mem_available", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 磁盘IOPS
        /// </summary>
        public static MonitorType TDSQL_disk_iops(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "disk_iops", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 活跃连接数
        /// </summary>
        public static MonitorType TDSQL_conn_active(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "conn_active", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 连接数
        /// </summary>
        public static MonitorType TDSQL_conn_running(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "conn_running", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 监控是否主备切换
        /// </summary>
        public static MonitorType TDSQL_is_mater_switched(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "is_mater_switched", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// CPU使用率
        /// </summary>
        public static MonitorType TDSQL_cpu_usage_rate(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/tdsql", "cpu_usage_rate", "uuid", unInstanceId, c, startTime, endTime, p);
        }

        #endregion 云数据库 TDSQL(MariaDB) 监控类

        #region 云存储Redis 监控类

        /// <summary>
        /// cache命中率
        /// </summary>
        public static MonitorType REDIS_cache_hit_ratio(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cache_hit_ratio", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// get命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_get(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_get", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// getbit命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_getbit(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_getbit", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// getrange命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_getrange(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_getrange", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// cache命中率
        /// </summary>
        public static MonitorType REDIS_hget命令数(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_hget", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// hgetall命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_hgetall(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_hgetall", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// hmget命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_hmget(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_hmget", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// hmset命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_hmset(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_hmset", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// hset命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_hset(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_hset", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// hsetnx命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_hsetnx(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_hsetnx", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// lset命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_lset(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_lset", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// mget命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_mget(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_mget", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// mset命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_mset(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_mset", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// msetnx命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_msetnx(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_msetnx", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// set命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_set(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_set", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// setbit命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_setbit(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_setbit", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// setex命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_setex(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_setex", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// setnx命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_setnx(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_setnx", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// setrange命令数
        /// </summary>
        public static MonitorType REDIS_cmdstat_setrange(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cmdstat_setrange", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 外部链接数
        /// </summary>
        public static MonitorType REDIS_connections(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "connections", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 处理请求数
        /// </summary>
        public static MonitorType REDIS_cpu_us(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "cpu_us", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 外部请求包长度
        /// </summary>
        public static MonitorType REDIS_in_flow(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "in_flow", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 主key量
        /// </summary>
        public static MonitorType REDIS_keys(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "keys", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 外部返回包长度
        /// </summary>
        public static MonitorType REDIS_out_flow(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "out_flow", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 所有get命令数
        /// </summary>
        public static MonitorType REDIS_stat_get(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "stat_get", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 所有set命令数
        /// </summary>
        public static MonitorType REDIS_stat_set(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "stat_set", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 占用空间
        /// </summary>
        public static MonitorType REDIS_storage(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "storage", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 占用空间占比
        /// </summary>
        public static MonitorType REDIS_storage_us(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "storage_us", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        ///
        /// </summary>
        public static MonitorType REDIS_(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return SimpleBaseMonitor(q, "qce/redis", "", "redis_uuid", unInstanceId, c, startTime, endTime, p);
        }

        #endregion 云存储Redis 监控类

        #region 监控基础类注释

        //GetMonitorData接口使用方法：

        //1. 拉取单对象
        //https://monitor.api.qcloud.com/v2/index.php?
        //&<公共请求参数>
        //&namespace=qce/lb
        //&metricName=pvv_outtraffic
        //&dimensions.0.name=protocol
        //&dimensions.0.value=tcp
        //&dimensions.1.name=vip
        //&dimensions.1.value=123.206.201.134
        //&dimensions.2.name=vport
        //&dimensions.2.value=80
        //&startTime=2016-06-28 14:10:00
        //&endTime=2016-06-28 14:20:00

        //2. 批量拉取多对象
        //https://monitor.api.qcloud.com/v2/index.php?
        //&<公共请求参数>
        //&namespace=qce/lb
        //&metricName=pvv_outtraffic
        //&batch.0.dimensions.0.name=protocol
        //&batch.0.dimensions.0.value=tcp
        //&batch.0.dimensions.1.name=vip
        //&batch.0.dimensions.1.value=123.206.201.134
        //&batch.0.dimensions.2.name=vport
        //&batch.0.dimensions.2.value=80
        //&batch.1.dimensions.0.name=protocol
        //&batch.1.dimensions.0.value=tcp
        //&batch.1.dimensions.1.name=vip
        //&batch.1.dimensions.1.value=123.206.201.134
        //&batch.1.dimensions.2.name=vport
        //&batch.1.dimensions.2.value=80
        //&startTime=2016-06-28 14:10:00
        //&endTime=2016-06-28 14:20:00

        //增加batch，将多个dimensions列表包含在里面，限制单次最多可请求50个对象

        #endregion 监控基础类注释

        #region 监控基础类

        /// <summary>
        /// 兼容旧接口的的简单监控基础类
        /// </summary>
        /// <param name="q"></param>
        /// <param name="qCloudNamespace"></param>
        /// <param name="metricName"></param>
        /// <param name="dimensionsName"></param>
        /// <param name="dimensionsValue"></param>
        /// <param name="c"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static MonitorType SimpleBaseMonitor(QCloudHelper q, string qCloudNamespace, string metricName, string dimensionsName, string dimensionsValue, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, qCloudNamespace, metricName, new Dictionary<string, string>() { { dimensionsName, dimensionsValue } }, c, startTime, endTime, p);
        }

        /// <summary>
        /// 批量拉取多对象
        /// </summary>
        /// <param name="q"></param>
        /// <param name="qCloudNamespace"></param>
        /// <param name="metricName"></param>
        /// <param name="dimensionsMulti"></param>
        /// <param name="c"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static MultiMonitorType MultiBaseMonitor(QCloudHelper q, string qCloudNamespace, string metricName, List<Dictionary<string, string>> dimensionsMulti, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, qCloudNamespace, metricName, null, c, startTime, endTime, p, true, dimensionsMulti) as MultiMonitorType;
        }

        /// <summary>
        /// 监控请求基础类
        /// </summary>
        /// <param name="q"></param>
        /// <param name="qCloudNamespace"></param>
        /// <param name="metricName"></param>
        /// <param name="dimensions"></param>
        /// <param name="c"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="p"></param>
        /// <param name="multiObjectPull"></param>
        /// <param name="dimensionsMulti"></param>
        /// <returns></returns>
        public static dynamic BaseMonitor(QCloudHelper q, string qCloudNamespace, string metricName, Dictionary<string, string> dimensions, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute, bool multiObjectPull = false, List<Dictionary<string, string>> dimensionsMulti = null)
        {
            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                ["namespace"] = qCloudNamespace,
                ["metricName"] = metricName,
                ["period"] = (int)p,
                ["startTime"] = startTime.DateTimeConvertQCloudFormat(),
                ["endTime"] = endTime.DateTimeConvertQCloudFormat()
            };

            // 拉取单个对象
            if (multiObjectPull == false && dimensions != null && dimensions.Count > 0)
            {
                int count = 0;

                foreach (var dimensionsKey in dimensions.Keys)
                {
                    baseParams.Add($"dimensions.{count}.name", dimensionsKey);
                    baseParams.Add($"dimensions.{count}.value", dimensions[dimensionsKey]);
                    count++;
                }
            }
            // 批量拉取多个对象
            else if (multiObjectPull && dimensionsMulti != null && dimensionsMulti.Count > 0)
            {
                int batchCount = 0;

                foreach (var dimensionsDict in dimensionsMulti)
                {
                    int count = 0;
                    foreach (var dimensionsKey in dimensionsDict.Keys)
                    {
                        baseParams.Add($"batch.{batchCount}.dimensions.{count}.name", dimensionsKey);
                        baseParams.Add($"batch.{batchCount}.dimensions.{count}.value", dimensionsDict[dimensionsKey]);
                        count++;
                    }
                    batchCount++;
                }
            }
            var returnJson = q.RequestAPiAsync("GetMonitorData", baseParams, APIUrl.Monitor, c);
            if (multiObjectPull)
            {
                return JsonConvert.DeserializeObject<MultiMonitorType>(returnJson.Result);
            }
            else
            {
                return JsonConvert.DeserializeObject<MonitorType>(returnJson.Result);
            }
        }

        #endregion 监控基础类
    }
}