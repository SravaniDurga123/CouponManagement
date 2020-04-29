using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using UserManagement.Helper;
using Microsoft.OpenApi.Models;
using UserManagement.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UserManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserManagementHelper, UserManagementHelper>();
            //services.AddSingleton<IUserRepository, UserRepository>();
            services.AddDbContext<CouponManagementContext>();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API USER", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API USER V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
