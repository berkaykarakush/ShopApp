using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EFCore
{
    public static class Configuration
    {
        public static IConfiguration _configuration;
        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static void ConnectionString(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
