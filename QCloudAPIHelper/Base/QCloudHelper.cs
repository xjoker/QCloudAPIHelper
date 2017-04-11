using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using static QCloudAPIHelper.APIEnum;

namespace QCloudAPIHelper
{
    public class QCloudHelper
    {
        public string _ServerUri = "/v2/index.php";
        public string _SecretId { get; set; }
        public string _SecretKey { get; set; }


        private SortedDictionary<string, object> _patameters; //参数合集

        /// <summary>
        /// 添加请求参数
        /// </summary>
        /// <param name="parameter"></param>
        public void AddParameter(SortedDictionary<string, object> parameter)
        {
            if (parameter == null)
            {
                return;
            }
            if (_patameters == null) _patameters = new SortedDictionary<string, object>(StringComparer.Ordinal);
            foreach (var item in parameter)
            {
                if (_patameters.ContainsKey(item.Key))
                {
                    _patameters[item.Key] = item.Value;
                }
                else
                {
                    _patameters.Add(item.Key, item.Value);
                }

            }
        }

        /// <summary>
        /// 清空请求参数表
        /// </summary>
        public void ClearParameter()
        {
            _patameters = new SortedDictionary<string, object>(StringComparer.Ordinal);
        }


        /// <summary>
        /// 签名方法
        /// https://www.qcloud.com/document/product/240/8329
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private void GetSignature(APIUrl url,
            SortedDictionary<string, object> requestParams,
            RequestMethod requestMethod = RequestMethod.GET,
            SignatureMethod signatureMethod = SignatureMethod.HmacSHA1)
        {
            /*
             1. 对参数排序
             2. 拼接请求字符串
             3. 拼接签名原文字符串
             4. 生成签名串
             5. 签名串编码(BASE64编码)
             */
            if (_patameters == null) _patameters = new SortedDictionary<string, object>();
            string tempStr = "";
            foreach (string key in requestParams.Keys)
            {
                if (key == "Signature")
                {
                    continue;
                }
                if (requestMethod == RequestMethod.POST && requestParams[key].ToString().Substring(0, 1).Equals("@"))
                {
                    continue;
                }
                tempStr += string.Format("{0}={1}&", key.Replace("_", "."), requestParams[key]);
            }

            tempStr = $"?{tempStr.TrimEnd('&')}";

            string retStr = $"{requestMethod.ToString()}{url.GetRemark()}{_ServerUri}{tempStr}";


            if (signatureMethod == SignatureMethod.HmacSHA1)
            {
                using (var mac = new HMACSHA1(Encoding.UTF8.GetBytes(_SecretKey)))
                {
                    byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(retStr));
                    _patameters.Add("Signature", Convert.ToBase64String(hash));
                }
            }

            if (signatureMethod == SignatureMethod.HmacSHA256)
            {
                using (var mac = new HMACSHA256(Encoding.UTF8.GetBytes(_SecretKey)))
                {
                    byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(retStr));
                    _patameters.Add("Signature", Convert.ToBase64String(hash));
                    _patameters.Add("SignatureMethod", "HmacSHA256");
                }
            }

        }


        /// <summary>
        /// API请求主方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="requestMethod"></param>
        /// <returns>JSON</returns>
        private string Send(APIUrl url, SortedDictionary<string, object> data, RequestMethod requestMethod = RequestMethod.GET)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            GetSignature(url, data);

            using (var client = new HttpClient())
            {
                string tempUrl = "";
                if (requestMethod == RequestMethod.GET)
                {
                    var paramStr = "";
                    foreach (var key in _patameters.Keys)
                    {
                        paramStr += string.Format("{0}={1}&", key, HttpUtility.UrlEncode(_patameters[key].ToString()));
                    }
                    tempUrl = paramStr.TrimEnd('&');
                }
                var bb = $"https://{url.GetRemark()}{_ServerUri}?{tempUrl}";
                var message = client.GetAsync(bb).Result;
                return message.Content.ReadAsStringAsync().Result;
            }

        }

        /// <summary>
        /// 请求API的通用方法
        /// </summary>
        /// <param name="action">接口名</param>
        /// <param name="url">域名</param>
        /// <param name="region">区域</param>
        /// <returns></returns>
        public string RequestAPi(string action, SortedDictionary<string, object> patameters, APIUrl url, CVMRegion region = CVMRegion.sh)
        {
            var basePatameters = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                { "Action", action },
                { "Nonce", new Random().Next().ToString() },
                { "Region", region.ToString() },
                { "SecretId", _SecretId },
                { "Timestamp", DateTime.Now.DateTimeToStamp().ToString() }
            };

            if (_patameters != null) ClearParameter();

            AddParameter(basePatameters);
            AddParameter(patameters);

            return Send(url, _patameters);
        }


        public QCloudHelper()
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






    }
}
