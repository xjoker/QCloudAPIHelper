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
    /// 云服务器监控帮助类
    /// </summary>
    public static class MonitorHelper
    {

        /// <summary>
        /// 请求 qce/cvm 的CPU使用率
        /// cpu_usage
        /// </summary>
        public static MonitorType cpu_usage(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "cpu_usage", unInstanceId, c, startTime, endTime,p);
        }

        /// <summary>
        /// 请求 qce/cvm 的CPU平均负载
        /// cpu_usage
        /// </summary>
        public static MonitorType cpu_loadavg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "cpu_loadavg", unInstanceId, c, startTime, endTime,p);
        }

        /// <summary>
        /// 请求 qce/cvm 的内存使用量
        /// mem_used
        /// </summary>
        public static MonitorType mem_used(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "mem_used", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的内存利用率
        /// mem_usage
        /// </summary>
        public static MonitorType mem_usage(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "mem_usage", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的 磁盘读流量
        /// disk_read_traffic
        /// </summary>
        public static MonitorType disk_read_traffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "disk_read_traffic", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的磁盘写流量
        /// disk_write_traffic
        /// </summary>
        public static MonitorType disk_write_traffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "disk_write_traffic", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的 磁盘IO等待
        /// disk_io_await
        /// </summary>
        public static MonitorType disk_io_await(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return BaseMonitor(q, "qce/cvm", "disk_io_await", unInstanceId, c, startTime, endTime, p);
        }

        /// <summary>
        /// 请求 qce/cvm 的 	内网出带宽
        /// lan_outtraffic
        /// </summary>
        public static MonitorType lan_outtraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return TrafficConvert(BaseMonitor(q, "qce/cvm", "lan_outtraffic", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 内网入带宽
        /// lan_intraffic
        /// </summary>
        public static MonitorType lan_intraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return TrafficConvert(BaseMonitor(q, "qce/cvm", "lan_intraffic", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的内网出包量
        /// lan_outpkg
        /// </summary>
        public static MonitorType lan_outpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return TrafficConvert(BaseMonitor(q, "qce/cvm", "lan_outpkg", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的内网入包量
        /// lan_inpkg
        /// </summary>
        public static MonitorType lan_inpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return TrafficConvert(BaseMonitor(q, "qce/cvm", "lan_inpkg", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的外网出带宽
        /// wan_outtraffic
        /// </summary>
        public static MonitorType wan_outtraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return TrafficConvert(BaseMonitor(q, "qce/cvm", "wan_outtraffic", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的外网入带宽
        /// wan_intraffic
        /// </summary>
        public static MonitorType wan_intraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return TrafficConvert(BaseMonitor(q, "qce/cvm", "wan_intraffic", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 外网出流量
        /// acc_outtraffic
        /// </summary>
        public static MonitorType acc_outtraffic(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return TrafficConvert(BaseMonitor(q, "qce/cvm", "acc_outtraffic", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 外网出包量
        /// wan_outpkg
        /// </summary>
        public static MonitorType wan_outpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return TrafficConvert(BaseMonitor(q, "qce/cvm", "wan_outpkg", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 请求 qce/cvm 的 外网入包量
        /// wan_inpkg
        /// </summary>
        public static MonitorType wan_inpkg(QCloudHelper q, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            return TrafficConvert(BaseMonitor(q, "qce/cvm", "wan_inpkg", unInstanceId, c, startTime, endTime, p));
        }

        /// <summary>
        /// 转换带宽内的数据
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private static MonitorType TrafficConvert(MonitorType b)
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

        /// <summary>
        /// 监控请求基础类
        /// </summary>
        public static MonitorType BaseMonitor(QCloudHelper q, string qCloudNamespace, string metricName, string unInstanceId, Region c, DateTime startTime, DateTime endTime, Period p = Period.FiveMinute)
        {
            if (string.IsNullOrWhiteSpace(unInstanceId)) throw new ArgumentNullException(nameof(unInstanceId));

            var baseParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                ["namespace"] = qCloudNamespace,
                ["metricName"] = metricName,
                ["dimensions.0.name"] = "unInstanceId",
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
