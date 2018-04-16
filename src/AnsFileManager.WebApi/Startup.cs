using AnsFileManager.AppService;
using AnsFileManager.Data.Context;
using AnsFileManager.Data.Repositories;
using AnsFileManager.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace AnsFileManager.WebApi
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
            //services.AddDbContext<IAnsFileManagerOracleDbContext>(
            //    services.AddScoped<IAnsFileManagerOracleDbContext, AnsFileManagerOracleDbContext>(
            //        new Func<IServiceProvider, ServiceCollection>(s =>
            //            new AnsFileManagerOracleDbContext(Configuration.GetConnectionString("DefaultConnection"), Configuration.GetConnectionString("DefaultSchema")))));

            services.AddSingleton<IAnsFileService, AnsFileService>();
            services.AddSingleton<IFtpClientService, FtpClientService>();
            services.AddSingleton<IAnsFileRepository, AnsFileRepository>();

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "AnsFile Web Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnsFile Web Api");
            });

            app.UseMvc();
        }
    }
}
