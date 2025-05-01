using AutoMapper;
using LMS.DTOs;
using LMS.Models.Social;
using LMS.Repositories.Interfaces;
using LMS.Services.Interfaces;

namespace LMS.Services.Implement
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task DeleteAsync(int id, string userId)
        {
            var notification=await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(notification);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<NotificationDto>> GetUserNotificationsAsync(string userId)
        {
            var notification= await _repository.GetUserNotificationsAsync(userId);
            return _mapper.Map<IEnumerable<NotificationDto>>(notification);
        }

        public async Task MarkAllAsReadAsync(string userId)
        {
            await _repository.MarkAllAsReadAsync(userId);
            await _repository.SaveChangesAsync();
        }

        public async Task MarkAsReadAsync(int id, string userId)
        {
            var notification=await _repository.GetByIdAsync(id);
            await _repository.MarkAsReadAsync(notification);
            await _repository.SaveChangesAsync();
        }

        public async Task<NotificationDto> CreateNotificationAsync(CreateNotificationDto notificationDto)
        {
            var notifcation= _mapper.Map<Notification>(notificationDto);
            await _repository.AddAsync(notifcation);
            await _repository.SaveChangesAsync();
            return _mapper.Map<NotificationDto>(notifcation);
        }
    }
}
