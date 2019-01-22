using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SingleDDD.Core.Application.Services;
using SingleDDD.Core.Domain.Interfaces.Infrastructures.Contexts;
using SingleDDD.Core.Domain.Interfaces.Infrastructures.Repositories;
using SingleDDD.Core.Domain.Interfaces.Services;
using SingleDDD.Core.Domain.Services;
using SingleDDD.Core.Infrastructures.Data.Contexts;
using SingleDDD.Core.Infrastructures.Data.Repositories;
using SingleDDD.Helpers;

namespace SingleDDD
{
    public class Startup
    {
        private const string DEFAULT_CONNECTION = "DefaultConnection";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigurationHelper(Configuration);
            services.AddTransient<UserApplicationService, UserApplicationService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddDbContext<ISingleDDDContext, SingleDDDContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(DEFAULT_CONNECTION)));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseMvc();
        }
    }
}
