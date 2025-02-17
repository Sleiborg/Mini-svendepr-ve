using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SleiFoodDb.Data;
using Microsoft.EntityFrameworkCore;

namespace SleiFoodDb
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
 
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddDbContext<Databasedcontext>(options => {
                    options.UseSqlServer(Configuration.GetConnectionString("DatabaseProduction"));
                });

                services.AddCors(option => option.AddPolicy("AllowAll", builder =>
                {
                    builder.WithOrigins("https://*", "http://*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }));

            services.AddControllers();
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
