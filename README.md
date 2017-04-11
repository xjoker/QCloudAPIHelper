QcloudAPIHelper
===

### Example
```csharp
using QCloudAPIHelper;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化类
            var qcloud = new QCloudHelper
            {
                _SecretId = "****",
                _SecretKey = "****"
            };

            // 构建请求参数
            var requestParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                ["instanceId"] = "ins-2z4l8jwq"
            };
            
            //请求 返回为JSON原始格式
            var returnJson=qcloud.RequestAPi("ResetInstances", requestParams, APIEnum.APIUrl.Cvm,APIEnum.CVMRegion.gz);

        }
    }
}
```