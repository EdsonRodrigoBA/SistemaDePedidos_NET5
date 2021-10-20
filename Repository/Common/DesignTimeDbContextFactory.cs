
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyAppContext>
    {
        public MyAppContext CreateDbContext(string[] args)
        {
            
            var enviromentename = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var filename = Directory.GetCurrentDirectory() + $"/../WebApi/appsettings.{enviromentename}.json";
            var configuration = new ConfigurationBuilder().AddJsonFile(filename).Build();
            var ConnectionString = configuration.GetConnectionString("AppConnection");
            var builder = new DbContextOptionsBuilder<MyAppContext>();

  
            builder.UseNpgsql(ConnectionString);

            return new MyAppContext(builder.Options);
        }
    }
}
