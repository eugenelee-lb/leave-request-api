using LeaveRequestAPI.Models;
using LeaveRequestAPI.Models.DataManager;
using LeaveRequestAPI.Models.Repository;
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

namespace LeaveRequestAPI
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
            services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:LeaveRequestDB"]));
            services.AddScoped<IEmployeeRepository<Employee>, EmployeeManager>();
            services.AddScoped<IEmployeeAccrualRepository<EmployeeAccrual>, EmployeeAccrualManager>();
            services.AddScoped<IRequestRepository<LeaveRequest>, RequestManager>();
            services.AddControllers();

            setCORS(services);
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

            app.UseCors("CorsBasicPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void setCORS(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsBasicPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });
        }

    }
}
