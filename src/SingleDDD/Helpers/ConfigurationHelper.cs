using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDDD.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfiguration Configuration { get; private set; }

        public static IServiceCollection AddConfigurationHelper(this IServiceCollection source, IConfiguration configuration)
        {
            Configuration = configuration;

            return source;
        }
    }
}
