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
            // � ������ ConfigureServices ��������������� ������ RouteOptions, ������� ��������� ����� ����� ���������� ������� �������������.
            // �������� ConstraintMap ���������� �������, ������������ ��� ���������� ���� ������������ ���������� � ������ ����������
            // IRouteConstraint, ������� ������������� ������ �����������. � ������� ���� ��������� ����� �����������, ������� �� �����
            // WeekDayConstraint ����� ��������� ��������� ������� ��� �� weekday
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));

                //����� ��� �������� ����� true, �������������� URL ������������� � ������ �������, ���� ����������, �������� ���
                //�������� �������� ������� ������� ��������. ����������� ��������� �������� false.
                options.LowercaseUrls = true;

                //����� ��� �������� ����� true, � ������������ �������� ������������� URL ����������� ����������� ������ ����� �����. �����������
                //��������� �������� false.
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
