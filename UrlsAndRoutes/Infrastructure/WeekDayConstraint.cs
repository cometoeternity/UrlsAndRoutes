using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlsAndRoutes.Infrastructure
{
    public class WeekDayConstraint : IRouteConstraint
    {
        private static string[] Days = new[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun" };
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return Days.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
    // В интрейфейсе IRouteConstraint определен метод Match(), который вызывается, чтобы позволить ограничению решить, должен ли запрос соответствовать
    // маршруту. Параметры метода Match() предоставляют доступ к запросу, поступившему от клиента, маршруту, имени ограничиваемого сегмента, переменных сегментов,
    // извлеченных из URL, и признаку того, для какого URL проверяется запрос - входящего или исходящего.
    // В примере с помощью параметра routeKey из параметра values извлекается значение переменной сегмента, к которому было применено ограничение, преобразуется
    // в строку нижнего регистра и проверяется на предмет соответствия одному из дней недели, определенных в статическом поле Days.

}
