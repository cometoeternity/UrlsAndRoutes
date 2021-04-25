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
                endpoints.MapControllerRoute(name: "NewRoute", pattern: "{controller}/{action}/{id?}",defaults: new { controller = "Home", action = "Index"}, 
                    constraints: new { id = new IntRouteConstraint ()});
            });  
            // AlphaRouteConstraint() - Соответствие алфавитным символам независимо от регистра.
            // BoolRouteConstraint() - Соответствие значению, которое может быть преобразовано в тип bool.
            // DateTimeRouteConstraint() - Соответствие значению, которое может быть преобразовано в тип DateTime.
            // DecimalRouteConstraint() - Соответствие значению, которе может быть преобразовано в тип decimal.
            // DoubleRouteConstaraint() - Соответствие значению, которое может быть преобразовано в тип double.
            // FloatRouteConstraint() - Соответствие значению, которое может быть преобразовано в тип float.
            // GuidRouteConstraint() - Соответствие значению глобального уникального идентификатора
            // IntRouteConstraint() - Соответствие значению, которое может быть преобразовано в тип int.
            // LengthRouteConstraint(len) - Соответствует строковому значению, которое содержит указаное число символов.
            // LengthRouteConstraint(min,max) - Соответствует строковому значению, которое содержит число символов между min и max включительно.
            // LongRouteConstraint() - Соответствует значению, которое может быть преобразовано в тип long
            // MaxLengthRouteConstraint(len) - Соответствует строковому значению с количеством символов не более len.
            // MaxRouteConstraint(val) - Соответствует значению int, если оно меньше val.
            // MinLengthRouteConstraint(len) - Соответствует строковому значению, которое имеет, по крайней мере, len символов.
            // MinRouteConstraint(val) - Соотвтетствует значению int, если оно больше val.
            // RangeRouteConstraint(min,max) - Соответствует значению int, если оно находится между min и max включительно.
            // RegexRouteConstraint(expr) - Соответствует регулярному выражению.
        }
    }
}
