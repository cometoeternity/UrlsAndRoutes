using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index() => View("Result", new Result { Controller = nameof(HomeController), Action = nameof(Index) });
        public ViewResult List() => View("Result", new Result { Controller = nameof(HomeController), Action = nameof(List) });
        
        
        
        // /Home/CustomVariable/All/1   = controller=Home, action=CustomVariable, id=All, catchall=1
        // /Home/CustomVariable/All/1/2/3 = controller=Home, action=CustomVariable, id=All, catchall= 1/2/3
        public ViewResult CustomVariable(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable)
            };
            r.Data["Id"] = id ?? "<no values>";
            r.Data["catchall"] = RouteData.Values["catchall"] ?? "<>";
            return View("Result", r);
        }
    }
}
