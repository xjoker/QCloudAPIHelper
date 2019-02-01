using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace QCloudAPIHelper.Base
{
    public class Signature
    {
        /// <summary>
        /// 签名方法
        /// https://www.qcloud.com/document/product/240/8329
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static void GetSignature(string url, string ServerUri, string SecretKey,
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
            if (requestParams == null) requestParams = new SortedDictionary<string, object>();
            StringBuilder tempStr = new StringBuilder();
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
                tempStr.Append($"{key.Replace("_", ".")}={requestParams[key]}&");
            }

            string retStr = $"{requestMethod.ToString()}{url}{ServerUri}{tempStr.ToString().TrimEnd('&')}";

            if (signatureMethod == SignatureMethod.HmacSHA1)
            {
                using (var mac = new HMACSHA1(Encoding.UTF8.GetBytes(SecretKey)))
                {
                    byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(retStr));
                    requestParams.Add("Signature", Convert.ToBase64String(hash));
                }
            }

            if (signatureMethod == SignatureMethod.HmacSHA256)
            {
                using (var mac = new HMACSHA256(Encoding.UTF8.GetBytes(SecretKey)))
                {
                    byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(retStr));
                    requestParams.Add("Signature", Convert.ToBase64String(hash));
                    requestParams.Add("SignatureMethod", "HmacSHA256");
                }
            }
        }

        /// <summary>
        /// 签名方法
        /// https://cloud.tencent.com/document/api/213/15692
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ServerUri"></param>
        /// <param name="SecretKey"></param>
        /// <param name="requestParams"></param>
        /// <param name="requestMethod"></param>
        public static void GetSignatureV3(string url, string ServerUri, string SecretKey,SortedDictionary<string, object> requestParams,RequestMethod requestMethod = RequestMethod.GET)
        {

        }
    }
}