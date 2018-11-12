using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestTest.Db;
using RestTest.Interfaces;
using RestTest.Storage;

namespace RestTest
{
    public class Startup
    {
        // PUBLIC

        // types

        public class CONFIG
        {
            public DbService.CONFIG DbService { get; set; }
            public StorageService.CONFIG StorageService { get; set; }
        }

        // constructor

        public Startup(IConfiguration configuration)
        {
            // populate application config
            mConfig = configuration.Get<CONFIG>();
        }

        // methods

        public void ConfigureServices(IServiceCollection services)
        {
            // add MVC
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // add database service
            services.AddTransient<IDbService, DbService>(
                dbService =>
                {
                    return new DbService(mConfig.DbService);
                }
            );

            // add storage service
            services.AddTransient<IStorageService, StorageService>(
                storageService =>
                {
                    return new StorageService(mConfig.StorageService);
                }
            );
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
            app.UseMvc();
        }

        // PRIVATE

        // members

        private readonly CONFIG mConfig;
    }
}
