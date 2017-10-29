using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using halloween.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace halloween
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
            services.AddMvc();

            //ADD DB AS A SERVICE
            services.AddDbContext<DB>(options => options.UseSqlite(Configuration["DB"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            //CREATE THE DB, IF IT DOES NOT EXIT YET!
            using (var serviceScope = app
                   .ApplicationServices
                   .GetRequiredService<IServiceScopeFactory>()
                   .CreateScope())
            {
                serviceScope
                    .ServiceProvider
                    .GetService<DB>()
                    .Database
                    .EnsureCreated();
            }
        }
    }
}
