using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // В методе ConfigureServices конфигурируется объект RouteOptions, который управляет рядом линий проведения системы маршрутизации.
            // Свойство ConstraintMap возвращает словарь, используемый для трансляции имен встраиваемых ограничеий в классы реализации
            // IRouteConstraint, которые предоставляют логику ограничений. В словарь было добавлено новое отображение, поэтому на класс
            // WeekDayConstraint можно ссылаться встраевым образом как на weekday
            services.Configure<RouteOptions>(options => options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));
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
                endpoints.MapControllerRoute(name: "NewRoute", pattern: "{controller}/{action/{id?}",defaults: new { controller = "Home", action = "Index"}, 
                    constraints: new { id = new WeekDayConstraint()});
                // Практическое применение специального ограничения встраиваемым образом.
                endpoints.MapControllerRoute(name: "NewRoute2", pattern: "{controller=Home}/{action=Index}/{id:weekday?}");
            });      
        }
    }
}
