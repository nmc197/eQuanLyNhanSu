using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EQuanLyNhanSu.Data.EF
{
    public class EQuanLyNhanSuDbContextFactory : IDesignTimeDbContextFactory<EQuanLyNhanSuDbContext>
    {
        public EQuanLyNhanSuDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("eQuanLyNhanSuDb");
            var optionsBuilder = new DbContextOptionsBuilder<EQuanLyNhanSuDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EQuanLyNhanSuDbContext(optionsBuilder.Options);
        }
    }
}
