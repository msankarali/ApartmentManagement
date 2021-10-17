using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.DataAccess.Abstract;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class ChatGroupManager : IChatGroupService
    {
        private readonly IChatGroupDal _chatGroupDal;

        public ChatGroupManager(IChatGroupDal chatGroupDal)
        {
            _chatGroupDal = chatGroupDal;
        }
    }
}