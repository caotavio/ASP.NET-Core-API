using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OtavioStore.Domain.StoreContext.Handlers;
using OtavioStore.Domain.StoreContext.Repositories;
using OtavioStore.Domain.StoreContext.Services;
using OtavioStore.Infra.DataContexts;
using OtavioStore.Infra.StoreContext.Repositories;
using OtavioStore.Infra.StoreContext.Services;

namespace OtavioStore.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddResponseCompression();

            services.AddScoped<OtavioDataContext, OtavioDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            
            app.UseResponseCompression();
        }
    }
}
