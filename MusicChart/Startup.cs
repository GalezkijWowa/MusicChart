﻿using AutoMapper;
using DatabaseModel.Data;
using IF.Lastfm.Core.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Data.SqlClient;
using System.IO;

//https://books.google.by/books?id=r4Q_DwAAQBAJ&pg=PA343&lpg=PA343&dq=asp.net+core+%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5+%D1%81%D1%82%D0%BE%D1%80%D0%BE%D0%BD%D0%B8%D1%85+%D0%B1%D0%B8%D0%B1%D0%BB%D0%B8%D0%BE%D1%82%D0%B5%D0%BA&source=bl&ots=SmoLHHNs-b&sig=_GtZn7JoZzqYFaSvGqDynCtbLb8&hl=ru&sa=X&ved=0ahUKEwjvzNGU4LnZAhVGFCwKHbw0DVkQ6AEIVzAE#v=onepage&q=asp.net%20core%20%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5%20%D1%81%D1%82%D0%BE%D1%80%D0%BE%D0%BD%D0%B8%D1%85%20%D0%B1%D0%B8%D0%B1%D0%BB%D0%B8%D0%BE%D1%82%D0%B5%D0%BA&f=false


namespace MusicChart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                services.AddDbContext<ApplicationDbContext>();
            }
            services.AddAutoMapper();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagination",
                    template: "Singer/SingerList/Page{page}",
                    defaults: new { Controller = "Singer", Action = "SingerList" }
                    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Singer}/{action=SingerList}/{id?}");
            });
        }
    }
}
