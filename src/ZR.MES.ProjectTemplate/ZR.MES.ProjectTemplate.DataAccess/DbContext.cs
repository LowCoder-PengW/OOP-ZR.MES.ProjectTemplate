using SqlSugar;
using System.Text;
using ZR.MES.ProjectTemplate.Enums.ConfigDefinition;

namespace ZR.MES.ProjectTemplate.DataAccess
{
    public class DbContext
    {

        public ISqlSugarClient Client { get; private set; }

        /// <summary>
        /// Set Db 
        /// </summary>
        public DbContext()
        {
            Client = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = AppConfig.ConnectionString,
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });
            //调式代码 用来打印SQL 
            Client.Aop.OnLogExecuting = (sql, pars) =>
            {
#if DEBUG
                foreach (var item in pars)
                {
                    sql = sql.Replace(item.ParameterName, $"'{item.Value}'");
                }
                Console.WriteLine();
                Console.WriteLine(sql);
#endif
            };

            //执行sql后
            Client.Aop.OnLogExecuted = (sql, pars) => //SQL执行完事件
            {
                if ("Development".Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine(sql);
                    pars.Aggregate(builder, (b, sp) => b.AppendLine($"{sp.ParameterName}={sp.Value}"));
                    builder.AppendLine($"执行耗时：{Client.Ado.SqlExecutionTime.TotalMilliseconds}ms");
                    // Log<DbContext>.Debug(builder.ToString());
                }
            };
        }

    }
}
