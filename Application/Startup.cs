﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SLICKIce.Application.Models;
using SLICKIce.Application.Data;

namespace SLICKIce.Application
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        /// <summary>
        /// Adds services to the site. Is called by the runtime.
        /// </summary>
        /// <param name="services">The services this site uses.</param>
        public void ConfigureServices(IServiceCollection services)
        {
			// add database context and set the connection
			services.AddDbContext<SLICKIceDBContext>(options => options.UseSqlServer(AppUtil.sqlserverConnectionString));

			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });

            app.UseMvc(routes =>
            {
                // configure route signiture
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
