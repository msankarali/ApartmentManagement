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
            services.AddScoped<IApartmentDal, EfApartmentDal>();
            services.AddScoped<IApartmentService, ApartmentManager>();

            services.AddScoped<IChatGroupDal, EfChatGroupDal>();
            services.AddScoped<IChatGroupService, ChatGroupManager>();

            services.AddScoped<IInvoiceDal, EfInvoiceDal>();
            services.AddScoped<IInvoiceService, InvoiceManager>();

            services.AddScoped<IInvoiceTypeDal, EfInvoiceTypeDal>();
            services.AddScoped<IInvoiceTypeService, InvoiceTypeManager>();

            services.AddScoped<IManagerDal, EfManagerDal>();
            services.AddScoped<IManagerService, ManagerManager>();

            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();

            services.AddScoped<IOccupantDal, EfOccupantDal>();
            services.AddScoped<IOccupantService, OccupantManager>();

            services.AddScoped<IAuthService, AuthManager>();

            return services;
        }
    }
}
