using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperORM.Helpers;
using DapperORM.Services;
using DapperORM.Services.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DapperORM
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //-----------------QUERIES ------------------------
            services.AddTransient<ICommandText, CommandText>();
            services.AddTransient<ICustomerQuery, CustomerQuery>(); 



            //-----------------REPOSITORIES--------------------
            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddTransient<ICustomerRepo, CustomerRepo>();



            //Get the swagger value options
            var swaggerOpt = Configuration.GetSection("SwaggerOptions").Get<SwaggerOptions>();
            // Register Swagger  
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = swaggerOpt.Title,
            //        Version = swaggerOpt.Version
            //    });

            //    var securityScheme = new OpenApiSecurityScheme
            //    {
            //        Name = "JWT Authentication",
            //        Description = "Enter JWT Bearer Token Only",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.Http,
            //        Scheme = "bearer",
            //        BearerFormat = "JWT",
            //        Reference = new OpenApiReference
            //        {
            //            Id = JwtBearerDefaults.AuthenticationScheme,
            //            Type = ReferenceType.SecurityScheme
            //        }
            //    };
            //    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {securityScheme, new string[]{ }}
            //    });
            //});
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
