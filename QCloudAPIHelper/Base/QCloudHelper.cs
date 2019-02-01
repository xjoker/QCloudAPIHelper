using Newtonsoft.Json;
using QCloudAPIHelper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QCloudAPIHelper
{
    public class QCloudHelper
    {
        /// <summary>
        /// 固定结尾
        /// </summary>
        private static readonly string _ServerUri = "/v2/index.php";

        public string _SecretId { get; private set; }
        public string _SecretKey { get; private set; }

        private QCloudHelper()
        {
        }

        /// <summary>
        /// 初始化类
        /// </summary>
        /// <param name="secretId"></param>
        /// <param name="secretKey"></param>
        public QCloudHelper(string secretId, string secretKey)
        {
            _SecretId = secretId;
            _SecretKey = secretKey;
        }



        /// <summary>
        /// API请求主方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="requestMethod"></param>
        /// <returns>JSON</returns>
        private async Task<string> SendAsync(string url, SortedDictionary<string, object> data, RequestMethod requestMethod = RequestMethod.GET)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            Signature.GetSignature(url,_ServerUri,_SecretKey, data);

            using (var client = new HttpClient())
            {
                string tempUrl = "";
                if (requestMethod == RequestMethod.GET)
                {
                    if (data.Keys != null && data.Keys.Any())
                    {
                        string paramStr = "";
                        foreach (var key in data.Keys)
                        {
                            paramStr += $"{key}={Web​Utility.UrlEncode(data[key].ToString())}&";
                        }
                        tempUrl = paramStr.TrimEnd('&');
                    }
                }
                var message = await client.GetAsync($"https://{url}{_ServerUri}?{tempUrl}");
                return await message.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// 请求API的通用方法
        /// </summary>
        /// <param name="action">接口名</param>
        /// <param name="patameters">参数,无参数请传null</param>
        /// <param name="url">api地址</param>
        /// <param name="region">区域</param>
        /// <returns></returns>
        public async Task<string> RequestAPiAsync(string action, SortedDictionary<string, object> patameters, APIUrl url, Region region = Region.sh)
        {
            return await RequestAPiManuallyAsync(action, patameters, url.GetDisplayName(), region.ToString());
        }

        /// <summary>
        /// 请求API的通用方法
        /// 需要手动构建参数
        /// 返回为动态类型
        /// </summary>
        /// <param name="action">接口名</param>
        /// <param name="patameters">参数,无参数请传null</param>
        /// <param name="url">api地址</param>
        /// <param name="region">区域</param>
        /// <returns></returns>
        public async Task<dynamic> RequestAPiDynamicAsync(string action, SortedDictionary<string, object> patameters, string url, string region)
        {
            return JsonConvert.DeserializeObject(await RequestAPiManuallyAsync(action, patameters, url, region.ToString()));
        }

        /// <summary>
        /// 请求API的通用方法,需要手动构建参数
        /// </summary>
        /// <param name="action">接口名</param>
        /// <param name="patameters">参数,无参数请传null</param>
        /// <param name="url">api地址</param>
        /// <param name="region">区域</param>
        /// <returns></returns>
        public async Task<string> RequestAPiManuallyAsync(string action, SortedDictionary<string, object> patameters, string url, string region)
        {
            var basePatameters = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "Action", action },
                { "Nonce", RandomHelper.RNGRandom(100) },
                { "Region", region },
                { "SecretId", _SecretId },
                { "Timestamp", (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds }
            };
            basePatameters.AddRange(patameters);

            return await SendAsync(url, basePatameters);
        }
    }
}