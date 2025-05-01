namespace LMS.DTOs
{
    public class CreateNotificationDto
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public string NotificationType { get; set; }
        public string ReferenceId { get; set; }
    }
}
