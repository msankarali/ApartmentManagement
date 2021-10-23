using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagement.Mvc.Areas.Manager.Controllers
{
    public class InvoicesController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
