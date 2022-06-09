using CifrovikDEL;
using CifrovikDEL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bachelor_Net60.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<CifrovikDB>(opt =>
            {
                var type = configuration["Type"];
                switch (type)
                {
                    case null: throw new InvalidOperationException("Не определен тип БД");
                    default: throw new InvalidOperationException($"Тип подключения {type} не поддерживается");
                    case "MySQL":
                        opt.UseMySql(configuration.GetConnectionString(type), new MySqlServerVersion(new Version(8, 0, 27)));
                        break;
                    case "MSSQL":
                        opt.UseSqlServer(configuration.GetConnectionString(type));
                        break;
                }
            })
            //.AddSingleton<DbInitializer>()
            .AddTransient<DbInitializer>()
            .AddRepositoriesInDB()
            ;
    }
}
