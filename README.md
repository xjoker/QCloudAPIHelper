QcloudAPIHelper
===

[![Build status](https://ci.appveyor.com/api/projects/status/y0ujjupllx5ux5r8?svg=true)](https://ci.appveyor.com/project/xjoker/qcloudapihelper)
[![NuGet version](https://badge.fury.io/nu/QCloudAPIHelper.png)](https://badge.fury.io/nu/QCloudAPIHelper)

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