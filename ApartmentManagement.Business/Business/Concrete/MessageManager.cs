using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.DataAccess.Abstract;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
    }
}