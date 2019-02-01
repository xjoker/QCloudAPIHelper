using System;
using System.Security.Cryptography;

namespace QCloudAPIHelper.Base
{
    public static class RandomHelper
    {
        /// <summary>
        /// 基于RNGCryptoServiceProvider的安全随机数生成(Int)
        /// 返回小于指定最大值的非负随机整数
        /// </summary>
        /// <returns></returns>
        public static int RNGRandom(int maxValue)
        {
            return RNGRandomInt(1, maxValue);
        }

        /// <summary>
        /// 基于RNGCryptoServiceProvider的安全随机数生成(Int)
        /// 自定义范围
        /// </summary>
        /// <returns></returns>
        public static int RNGRandomInt(int minValue, int maxValue)
        {
            if (maxValue <= minValue)
            {
                throw new ArgumentOutOfRangeException("maxValue");
            }
            return (int)RNGRandomLong(Convert.ToInt64(minValue), Convert.ToInt64(maxValue));
        }

        /// <summary>
        /// 基于RNGCryptoServiceProvider的安全随机数生成(Long)
        /// 自定义范围
        /// </summary>
        /// <returns></returns>
        public static long RNGRandomLong(long minValue, long maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException("minValue");
            if (minValue == maxValue) return minValue;

            byte[] data = new byte[8];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(data);
                long result = BitConverter.ToInt64(data, 0);
                return (Math.Abs(result % (maxValue - minValue)) + minValue);
            }
        }
    }
}