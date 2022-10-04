using Cambridge.Test.Data.Abstractions;
using Cambridge.Test.Data.Abstractions.Repository;
using Cambridge.Test.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cambridge.Test.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        var driver = configuration.GetValue("DatabaseDriver", "Sqlite");
        services.AddDbContext<IDbContext, AppDbContext>(options => 
        {
            if(driver == "Sqlite")
                options.UseSqlite(configuration.GetConnectionString("SqliteConnection"));
            else if(driver == "Postgres")
                options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
            else if (driver == "SqlServer")
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
         });

        services.AddTransient<IFileRepository, FileRepository>();
        
        return services;
    }
}