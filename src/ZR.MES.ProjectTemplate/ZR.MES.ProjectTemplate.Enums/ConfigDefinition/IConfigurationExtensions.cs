using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.MES.ProjectTemplate.Enums.ConfigDefinition
{
    public static class IConfigurationExtensions
    {
        public static string GetStringValue(this IConfiguration configuration, string key)
        {
            var temp = configuration[key];
            return temp;
        }

        public static int GetIntValue(this IConfiguration configuration, string key)
        {
            var temp = configuration[key];
            int value = int.Parse(temp);
            return value;
        }

        public static long GetLongValue(this IConfiguration configuration, string key)
        {
            var temp = configuration[key];
            long value = long.Parse(temp);
            return value;
        }
        public static decimal GetDecimalValue(this IConfiguration configuration, string key)
        {
            var temp = configuration[key];
            decimal value = decimal.Parse(temp);
            return value;
        }

        public static T GetValue<T>(this IConfiguration configuration, string key)
        {
            var temp = configuration[key];
            return (T)Convert.ChangeType(temp, typeof(T));
        }

    }
}
