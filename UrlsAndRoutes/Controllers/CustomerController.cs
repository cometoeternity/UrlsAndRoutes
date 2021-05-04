using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class CustomerController : Controller
    {
        [Route("[controller]/MyIndex")]
        public ViewResult Index()
        {
            return View("Result", new Result { Controller = nameof(CustomerController), Action = nameof(Index) });
        }
        public ViewResult List()
        {
            return View("Result", new Result { Controller = nameof(CustomerController), Action = nameof(List) });
        }
    }
}
