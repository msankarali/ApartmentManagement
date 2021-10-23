using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ApartmentManagement.Mvc.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(AuthenticationSchemes = "manager")]
    public class BaseController : Controller
    {

    }
}