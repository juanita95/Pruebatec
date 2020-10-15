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
using Webmvcapi.Models;
using Webmvcapi.Services;


namespace Webmvcapi
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
            services.Configure<FacturasSettings>(
                Configuration.GetSection(nameof(FacturasSettings)));
            services.AddSingleton<IFacturasSettings>(sp =>
            sp.GetRequiredService<IOptions<FacturasSettings>>().Value);

            services.AddSingleton<UserService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "Prueba Api Angular"
                });
            });

            services.AddControllers().AddNewtonsoftJson(options => options.UseMemberCasing());
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Angular API");
            });

            app.UseCors(option =>
            {
                option.AllowAnyHeader();
                option.AllowAnyMethod();
                option.AllowAnyOrigin();
            });

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
