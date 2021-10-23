using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Mvc.Areas.Manager.Models;
using Core.Utilities.Results;
using Mapster;

namespace ApartmentManagement.Mvc.Areas.Manager.Controllers
{
    public class ApartmentsController : BaseController
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        public IActionResult Index()
        {
            var model = new ApartmentModel
            {
                Apartments = _apartmentService.GetAll().Data
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int apartmentId)
        {
            var apartment = _apartmentService.GetById(apartmentId);
            return View(apartment.Adapt<UpdateApartmentDto>());
        }

        [HttpPost]
        public IActionResult Update(UpdateApartmentDto updateApartmentDto)
        {
            var result = _apartmentService.Update(updateApartmentDto);
            return Json(result);
        }

        [HttpPost]
        public JsonResult Delete(int apartmentId)
        {
            var result = _apartmentService.SwitchDeleteById(apartmentId);
            return Json(result);
        }
    }
}
