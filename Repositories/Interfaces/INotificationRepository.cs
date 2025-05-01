using LMS.DTOs;
using LMS.Models.Social;

namespace LMS.Repositories.Interfaces
{
    public interface INotificationRepository:IGenericRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetUserNotificationsAsync(string userId);
        Task MarkAsReadAsync(Notification notification);
        Task MarkAllAsReadAsync(string userId);


    }
}
