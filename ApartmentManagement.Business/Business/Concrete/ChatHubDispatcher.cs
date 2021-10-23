

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Message;
using ApartmentManagement.Entities.Models;
using Core.Utilities.UserManagement;
using Mapster;
using Microsoft.AspNetCore.SignalR;

namespace ApartmentManagement.Business.Business.Concrete
{
    public class ChatHubDispatcher : Hub
    {
        private readonly IChatGroupDal _chatGroupDal;
        private readonly IMessageDal _messageDal;

        public ChatHubDispatcher(
            IChatGroupDal chatGroupDal,
            IMessageDal messageDal)
        {
            _chatGroupDal = chatGroupDal;
            _messageDal = messageDal;
        }

        public async Task GetConversation(int chatGroupId)
        {
            if (!_chatGroupDal.Any(cg => cg.Id == chatGroupId)) return;

            await Groups.AddToGroupAsync(Context.ConnectionId, chatGroupId.ToString());

            var messages = _messageDal.GetAll(
                predicate: m => m.ChatGroupId == chatGroupId,
                orderBy: mq => mq.OrderByDescending(m => m.Id)
            ).Adapt<List<GetMessageDto>>();

            await Clients.Group(chatGroupId.ToString()).SendAsync("receiveMessages", messages.Select(m => new
            {
                Content = m.Content,
                CreatedAt = m.CreatedAt.ToString("f"),
                CreatedBy = m.CreatedBy
            }));
        }

        public async Task SendMessageToManager(int managerId, string message)
        {
            ChatGroup chatGroup;
            if (!_chatGroupDal.Any(cg => cg.ManagerId == managerId && cg.OccupantId == CurrentUser.Id))
            {
                chatGroup = _chatGroupDal.Add(new ChatGroup
                {
                    ManagerId = managerId,
                    OccupantId = CurrentUser.Id
                });
            }
            else
            {
                chatGroup = _chatGroupDal.GetFirst(cg => cg.ManagerId == managerId && cg.OccupantId == CurrentUser.Id);
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, chatGroup.Id.ToString());

            _messageDal.Add(new Message
            {
                ChatGroupId = chatGroup.Id,
                Content = message,
                CreatedAt = DateTime.Now,
                CreatedBy = CurrentUser.Name
            });

            await GetConversation(chatGroup.Id);
        }

        public async Task SendMessageToOccupant(int occupantId, string message)
        {
            ChatGroup chatGroup;
            if (!_chatGroupDal.Any(cg => cg.ManagerId == CurrentUser.Id && cg.OccupantId == occupantId))
            {
                chatGroup = _chatGroupDal.Add(new ChatGroup
                {
                    ManagerId = CurrentUser.Id,
                    OccupantId = occupantId
                });
            }
            else
            {
                chatGroup = _chatGroupDal.GetFirst(cg => cg.ManagerId == CurrentUser.Id && cg.OccupantId == occupantId);
            }

            _messageDal.Add(new Message
            {
                ChatGroupId = chatGroup.Id,
                Content = message,
                CreatedAt = DateTime.Now,
                CreatedBy = CurrentUser.Name
            });

            await GetConversation(chatGroup.Id);
        }
    }
}