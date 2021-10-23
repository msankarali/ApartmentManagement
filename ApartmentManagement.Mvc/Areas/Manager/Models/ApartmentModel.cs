using System.Collections.Generic;
using ApartmentManagement.Entities.Models;

namespace ApartmentManagement.Mvc.Areas.Manager.Models
{
    public class ApartmentModel
    {
        public List<Apartment> Apartments { get; set; }
    }
}