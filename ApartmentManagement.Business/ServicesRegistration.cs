using System;
using System.Collections.Generic;
using System.Text;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.Business.Business.Concrete;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace ApartmentManagement.Business
{
    public static class ServicesRegistration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceDal, EfInvoiceDal>();
            services.AddScoped<IInvoiceService, InvoiceManager>();

            return services;
        }
    }
}
