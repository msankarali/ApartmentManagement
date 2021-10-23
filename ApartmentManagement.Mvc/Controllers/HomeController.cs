using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.Business.Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApartmentManagement.Mvc.Models;
using Microsoft.AspNetCore.SignalR;

namespace ApartmentManagement.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IOccupantService _occupantService;
        private readonly IManagerService _managerService;
        private readonly IChatGroupService _chatGroupService;
        private readonly IHubContext<ChatHubDispatcher> _hubContext;
        private readonly IApartmentService _apartmentService;

        public HomeController(
            IInvoiceService invoiceService,
            IOccupantService occupantService,
            IManagerService managerService,
            IChatGroupService chatGroupService,
            IHubContext<ChatHubDispatcher> hubContext,
            IApartmentService apartmentService)
        {
            _invoiceService = invoiceService;
            _occupantService = occupantService;
            _managerService = managerService;
            _chatGroupService = chatGroupService;
            _hubContext = hubContext;
            _apartmentService = apartmentService;
        }
        public IActionResult Index(int page = 0)
        {
            return View(_invoiceService.GetInvoiceDetails(page).Data);
        }

        [Route(nameof(Profile))]
        public IActionResult Profile()
        {
            var bla = _apartmentService.GetAllOwnedApartments();
            var model = new ProfileModel
            {
                OccupantInfo = _occupantService.GetOccupantInfoDto().Data,
                OwnedApartments = _apartmentService.GetAllOwnedApartments().Data
            };
            return View(model);
        }

        [Route(nameof(Messages))] public IActionResult Messages() => View(_managerService.GetManagers().Data);

        [Route(nameof(Conversation))]
        public async Task<IActionResult> Conversation(int managerId)
        {
            ViewBag.managerId = managerId;
            ViewBag.chatGroupId = _chatGroupService.GetGroupChatIdByManagerId(managerId);
            return View();
        }

    }
}
