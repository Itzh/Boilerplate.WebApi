using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Boilerplate.WebApi
{
    public class Startup
    {
        private IConfiguration configuration;
        public static String Name = (typeof(Startup).Namespace) ?? "API";

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(this.configuration)
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Add db Context
            services.AddControllers(opt =>
            {
                opt.UseNamespaceRouteToken();
            });

            services.Configure<ApiBehaviorOptions>(abOpt =>
            {
                abOpt.SuppressInferBindingSourcesForParameters = true;
            });

            // Generate Api Docs
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = Name, Version = "v1" });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Name}.xml"));
                c.UseApiEndpoints();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // Swagger middleware for OpenAPI
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Name} V1"));

            // ardalis ApiEndpoints Configuration
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
