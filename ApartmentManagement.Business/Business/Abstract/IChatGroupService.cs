using System.Collections.Generic;
using ApartmentManagement.Entities.Dtos.ChatGroup;
using Core.Utilities.Results;

namespace ApartmentManagement.Business.Business.Abstract
{
    public interface IChatGroupService
    {
        IDataResult<List<GetChatGroupDetailsDto>> GetChatGroupDetails();
    }
}