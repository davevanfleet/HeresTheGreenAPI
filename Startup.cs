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
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using HeresTheGreenAPI.Models;

namespace HeresTheGreenAPI
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
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (env == "Development")
            {
                services.Configure<CoursesDatabaseSettings>(
                    Configuration.GetSection(nameof(CoursesDatabaseSettings))
                );
            }

            else
            {
                services.Configure<CoursesDatabaseSettings>(options => 
                {
                    options.CoursesCollectionName = Environment.GetEnvironmentVariable("COURSES_COLLECTION_NAME");
                    options.ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
                    options.DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
                });
            }

            services.AddSingleton<ICoursesDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CoursesDatabaseSettings>>().Value
            );
            
            services.AddSingleton<ICourseRepository, CourseRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HeresTheGreenAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HeresTheGreenAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
