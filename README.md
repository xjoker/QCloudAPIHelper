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
            // 如无参数可不构建
            var requestParams = new SortedDictionary<string, object>(StringComparer.Ordinal)
            {
                ["instanceId"] = "ins-2z4l8jwq"
            };
            
            
            //请求 返回为JSON原始格式
            var returnJson=qcloud.RequestAPi("ResetInstances", requestParams, APIEnum.APIUrl.Cvm,APIEnum.CVMRegion.gz);

            // 手动请求接口 返回为JSON原始格式
            var returnJson=qcloud.RequestAPiManually("ResetInstances", requestParams, "cvm.api.qcloud.com", "gz");
            // 无参数方式
            var returnJson=qcloud.RequestAPiManually("ResetInstances", null, "cvm.api.qcloud.com", "gz");

            // 手动请求接口 返回为动态类型
            dynamic dda = qcloud.RequestAPiDynamic("ResetInstances", requestParams, "cvm.api.qcloud.com", "gz");
            Console.WriteLine(dda.code);

            // 辅助类请求方法 返回JSON解析后类型 (许多接口未写，可以调用手动接口来返回)
            var returnType = CvmHelper.GetCVMList(qcloud);
        }
    }
}
```