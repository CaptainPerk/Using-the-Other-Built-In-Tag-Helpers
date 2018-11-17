﻿using Cities.Models;
using Cities.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Cities
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICityRepository, MemoryCityRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Map("/mvcapp", appBuilder =>
            {
                appBuilder.UseStatusCodePages();
                appBuilder.UseDeveloperExceptionPage();
                appBuilder.UseStaticFiles();
                appBuilder.UseMvcWithDefaultRoute();
            });

        }
    }
}
