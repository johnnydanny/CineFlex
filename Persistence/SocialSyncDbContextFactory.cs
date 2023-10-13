using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class SocialSyncDbContextFactory : IDesignTimeDbContextFactory<SocialSyncApplicationDbContext>
    {
        public SocialSyncApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();


            var builder = new DbContextOptionsBuilder<SocialSyncApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DbConnectionString");
            builder.UseNpgsql(connectionString);

            return new SocialSyncApplicationDbContext(builder.Options);
        }
    }
}
