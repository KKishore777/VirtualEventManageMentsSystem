using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace DAL.Models
{
    public static class DataBaseHelper
    {
        public static String GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:false,reloadOnChange:true);
                                                                     //ConnectionString Name in appSettings
            var connectionString = builder.Build().GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
