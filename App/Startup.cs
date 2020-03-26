using Amore.D.Dao;
using Amore.Data.Dao;
using Amore.Data.Models;
using Amore.Domain.Context;
using Amore.Domain.Order;
using amore.domain.Site;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace App
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
            services.Configure<GoodiesDatabaseSettings>(Configuration.GetSection(nameof(GoodiesDatabaseSettings)));
            services.AddSingleton<IGoodiesDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<GoodiesDatabaseSettings>>().Value);
            
            services.Configure<PizzasDatabaseSettings>(Configuration.GetSection(nameof(PizzasDatabaseSettings)));
            services.AddSingleton<IPizzasDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PizzasDatabaseSettings>>().Value);
            
            services.Configure<AmoreCheckoutDataProvider>(Configuration.GetSection(nameof(AmoreCheckoutDataProvider)));
            services.AddSingleton<IAmoreCheckoutDataProvider>(sp =>
                sp.GetRequiredService<IOptions<AmoreCheckoutDataProvider>>().Value);

            // daos and services
            services.AddSingleton<IGoodieDao, GoodieDao>();
            services.AddSingleton<IPizzaDao, PizzaDao>();

            services.AddSingleton<IAmoreOrderService, DummyAmoreOrderService>();

            // domain
            services.AddSingleton<IPizzaSiteProxy, PizzaSiteProxy>();
            services.AddSingleton<IPizzaSiteProxyFactory, PizzaSiteProxyFactory>();

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