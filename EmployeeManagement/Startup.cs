using EmployeeManagement.Entities;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
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
            services.AddControllers();

            var connection = "server=LAPTOP-J8T7UO1H; database=EmployeeManagement; trusted_connection=true;";
            services.AddDbContext<EmployeeManagementContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<ITaskRepository, TaskRepository>();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddSwaggerGen();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v5.6.0",
            //                 new Info { Title = "EmployeeManagement", Version = "5.6.0" });
            //});

            services.AddSwaggerDocument();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "EmployeeManagement (V 5.6.0)");
            //});

            // This middleware serves the Swagger documentation UI
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeManagement API V1");
            //});

            //app.UseSwagger();
            //app.UseSwaggerUi3();
        }
    }
}
