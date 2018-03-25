using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBACK.Models;
using APIBACK.Services.Implementations;
using APIBACK.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace APIBACK
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
            services.AddMvc();


            services.AddDbContext<StoreContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DataBase")));
            services.AddCors();
            services.AddTransient<IMinikuraAPI, MinikuraAPI>();
            services.AddTransient<IModelsStorage, InProjectStorage>();
            services.AddSingleton<IWantModel, WantModel>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseCors(builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx => {
                    ctx.Context.Response.Headers.Append(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Origin", "*"));
                    ctx.Context.Response.Headers.Append(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept"));
                },
                ServeUnknownFileTypes = true,
            });
            app.UseMvc();
        }
    }
}
