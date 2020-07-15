using Amore.Data.Local;
using Amore.Data.Local.Dao;
using Amore.Data.Website.Context;
using Amore.Data.Website.Provider;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Provider;
using Amore.Domain.Order;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Amore.PizzaPoll
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
            // asp mvc config
            services.AddRazorPages();
            services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
            
            // app settings
            services.Configure<AmoreCheckoutDataProvider>(Configuration.GetSection("AmoreCheckoutDataProvider"));
            services.AddSingleton<IAmoreCheckoutDataProvider>(sp =>
                sp.GetRequiredService<IOptions<AmoreCheckoutDataProvider>>().Value);

            // daos and services
            var localDataProvider = new AmoreLocalDataProvider();
            localDataProvider.Reload();
            
            services.AddSingleton<IAmoreLocalDataProvider>(localDataProvider);
            services.AddSingleton<IAmoreConfigurationLoader>(localDataProvider);

            services.AddSingleton<IPizzaDao, LocalPizzaDao>();
            services.AddSingleton<IGoodieDao, LocalGoodieDao>();
            services.AddSingleton<IOrderDao, TransientOrderDao>();

            services.AddSingleton<ISessionProvider, ThatsAmoreSessionProvider>();
            services.AddSingleton<IThatsAmoreWebSiteAccessProvider, ThatsAmoreWebSiteAccessProvider>();

            // domain
            services.AddSingleton<IAmoreOrderService, DummyAmoreOrderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapRazorPages());
        }
    }
}