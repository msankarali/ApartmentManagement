using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Business.Abstract;

namespace ApartmentManagement.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public HomeController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public IActionResult Index(int page = 0)
        {
            return View(_invoiceService.GetInvoiceDetails(page).Data);
        }
    }
}
