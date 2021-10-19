using System.Collections.Generic;
using System.Linq;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.ChatGroup;
using Core.Utilities.Results;
using Core.Utilities.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class ChatGroupManager : IChatGroupService
    {
        private readonly IChatGroupDal _chatGroupDal;

        public ChatGroupManager(IChatGroupDal chatGroupDal)
        {
            _chatGroupDal = chatGroupDal;
        }

        public IDataResult<List<GetChatGroupDetailsDto>> GetChatGroupDetails()
        {
            return new DataResult<List<GetChatGroupDetailsDto>>(ResultType.Success, _chatGroupDal.GetAllSelect(
                selector: cg => new GetChatGroupDetailsDto
                {
                    Id = cg.Id,
                    FullName = cg.Occupant.FullName
                },
                enableTracking: false,
                orderBy: cgq => cgq.OrderByDescending(cg => cg.Id),
                predicate: cgq => cgq.ManagerId == CurrentUser.Id,
                include: cgq => cgq.Include(cg => cg.Occupant)
            ).ToList());
        }
    }
}