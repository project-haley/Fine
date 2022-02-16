using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fine.Data
{
    public static class DataUtility
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            //Default connection string from appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //It will be automatically overwritten if running on Heroku
            //DATABASE_URL will be recognized in the Heroku environment
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }

        public static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            //Required for Npgsql integration with external service
            //var builder = new NpgsqlConnectionStringBuilder
            //{
            //    Host = databaseUri.Host,
            //    Port = databaseUri.Port,
            //    Username = userInfo[0],
            //    Password = userInfo[1],
            //    Database = databaseUri.LocalPath.TrimStart('/'),
            //    SslMode = SslMode.Prefer,
            //    TrustServerCertificate = true
            //};

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(databaseUrl);

            return builder.ToString();
        }
    }
}