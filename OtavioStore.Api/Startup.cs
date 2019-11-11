using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OtavioStore.Domain.StoreContext.Handlers;
using OtavioStore.Domain.StoreContext.Repositories;
using OtavioStore.Domain.StoreContext.Services;
using OtavioStore.Infra.DataContexts;
using OtavioStore.Infra.StoreContext.Repositories;
using OtavioStore.Infra.StoreContext.Services;
using Swashbuckle.AspNetCore.Swagger;
using Elmah.Io.AspNetCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using OtavioStore.Shared;

namespace OtavioStore.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();
            
            services.AddResponseCompression();

            services.AddScoped<OtavioDataContext, OtavioDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Otavio Store", Version = "v1" });
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            
            app.UseResponseCompression();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Otavio Store - V1");
            });

            app.UseElmahIo();
        }
    }
}
