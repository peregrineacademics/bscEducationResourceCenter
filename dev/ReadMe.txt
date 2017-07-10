
Run these commands to enable EF Code in PAS.ResourceCenter.Library.DataAccess:
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design


Run script to Scaffold DB:
Scaffold-DbContext "Server=localhost;Database=erc;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Project PAS.ResourceCenter.Library.DataAccess -Force

Replace the lines of code in ercContext.cs everytime you scaffold the DB (codes are overwritted on the force option): 

using Microsoft.Extensions.Configuration;
using System.IO;

        public IConfigurationRoot Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Read the connection string from appsettings.json
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            optionsBuilder.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
        }
