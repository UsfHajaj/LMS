using LMS.Models.Context;
using LMS.Models.Social;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories.Implementions
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(string userId)
        {
            return await _dbSet
                .Where(x => x.UserId == userId)
                .OrderBy(m=>m.Id)
                .ToListAsync();
        }

        public async Task MarkAllAsReadAsync(string userId)
        {
            var notifications = await _dbSet
                .Where(m => m.UserId == userId && !m.IsRead)
                .ToListAsync();
            foreach(var i in notifications)
            {
                i.IsRead = true;
            }
        }

        public async Task MarkAsReadAsync(Notification notification)
        {
            notification.IsRead = true;   
            _dbSet.Update(notification);
        }
    }
}
