using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                // Примененное к маршруту ограничение обеспечивает его соответствие только таким URL, в которых сегмент controller начинается с буквы H
                endpoints.MapControllerRoute(name: "NewRoute", pattern: "{controller:regex(^H.*)=Home}/{action=Index}/{id?}");
                // Ограничение соответствует только таким URL, в которых значение переменной controller начинается на букву H, а значением action
                // являются Index или About.
                endpoints.MapControllerRoute(name: "MeNewRoute2", pattern: "{controller:regex(^H.*)=Home}/"+"{action:regex(^Index$|^About$)=Index}/{id?}");

            });      
        }
    }
}
