using LMS.DTOs;
using LMS.Models.Social;

namespace LMS.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetUserNotificationsAsync(string userId);
        Task MarkAsReadAsync(int id, string userId);
        Task DeleteAsync(int id, string userId);
        Task MarkAllAsReadAsync(string userId);
        Task<NotificationDto> CreateNotificationAsync(CreateNotificationDto notificationDto);
    }
}
