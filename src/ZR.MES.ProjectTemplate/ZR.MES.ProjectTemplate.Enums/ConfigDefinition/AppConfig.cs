using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.MES.ProjectTemplate.Enums.ConfigDefinition
{
    public static class AppConfig
    { 
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// OpenApi服务名称
        /// </summary>
        public const string OpenApiServiceName = "ZR.MES.ProjectTemplate.OpenAPI";


        /// <summary>
        /// 数据库链接
        /// </summary>
        public static string ConnectionString => Configuration.GetStringValue("conn");

    }
}
