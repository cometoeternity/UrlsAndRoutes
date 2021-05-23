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
            // ¬ методе ConfigureServices конфигурируетс€ объект RouteOptions, который управл€ет р€дом линий проведени€ системы маршрутизации.
            // —войство ConstraintMap возвращает словарь, используемый дл€ трансл€ции имен встраиваемых ограничеий в классы реализации
            // IRouteConstraint, которые предоставл€ют логику ограничений. ¬ словарь было добавлено новое отображение, поэтому на класс
            // WeekDayConstraint можно ссылатьс€ встраевым образом как на weekday
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));

                // огда это свойство равно true, результирующие URL преобразуютс€ в нижний регистр, если контроллер, действие или
                //значение содержит символы нижнего регистра. —тандартным значением €вл€етс€ false.
                options.LowercaseUrls = true;

                // огда это свойство равно true, к генерируемым системой маршрутизации URL добавл€етс€ завершающий символ косой черты. —тандартным
                //значением €вл€етс€ false.
                options.AppendTrailingSlash = true;
            });
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
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "out", pattern: "outbound/{controller=Home}/{Action=Index}/{id?}");
            });      
        }
    }
}
