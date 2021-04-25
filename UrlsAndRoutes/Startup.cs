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
            // AlphaRouteConstraint() - ������������ ���������� �������� ���������� �� ��������.
            // BoolRouteConstraint() - ������������ ��������, ������� ����� ���� ������������� � ��� bool.
            // DateTimeRouteConstraint() - ������������ ��������, ������� ����� ���� ������������� � ��� DateTime.
            // DecimalRouteConstraint() - ������������ ��������, ������ ����� ���� ������������� � ��� decimal.
            // DoubleRouteConstaraint() - ������������ ��������, ������� ����� ���� ������������� � ��� double.
            // FloatRouteConstraint() - ������������ ��������, ������� ����� ���� ������������� � ��� float.
            // GuidRouteConstraint() - ������������ �������� ����������� ����������� ��������������
            // IntRouteConstraint() - ������������ ��������, ������� ����� ���� ������������� � ��� int.
            // LengthRouteConstraint(len) - ������������� ���������� ��������, ������� �������� �������� ����� ��������.
            // LengthRouteConstraint(min,max) - ������������� ���������� ��������, ������� �������� ����� �������� ����� min � max ������������.
            // LongRouteConstraint() - ������������� ��������, ������� ����� ���� ������������� � ��� long
            // MaxLengthRouteConstraint(len) - ������������� ���������� �������� � ����������� �������� �� ����� len.
            // MaxRouteConstraint(val) - ������������� �������� int, ���� ��� ������ val.
            // MinLengthRouteConstraint(len) - ������������� ���������� ��������, ������� �����, �� ������� ����, len ��������.
            // MinRouteConstraint(val) - �������������� �������� int, ���� ��� ������ val.
            // RangeRouteConstraint(min,max) - ������������� �������� int, ���� ��� ��������� ����� min � max ������������.
            // RegexRouteConstraint(expr) - ������������� ����������� ���������.
        }
    }
}
