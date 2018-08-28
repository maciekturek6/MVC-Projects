using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise_2.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise_2
{
    public class Startup
    {
        public Startup()
        {

            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddXmlFile("appsettings.xml");
            Configuration = configBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<EFCDbContext>(config => config.UseSqlServer(connectionString), ServiceLifetime.Transient);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=ProductModels}/{action=Index}/{id?}");
            });
        }
    }
}
