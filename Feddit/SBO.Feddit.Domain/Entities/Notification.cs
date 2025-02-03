using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Entities
{
    public class Notification
    {
        public int? NotificationID { get; }
        public int UserID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public string NotificationType { get; set; }

        public Notification(int? notificationId, int userId, string content, DateTime timestamp, bool isRead, string notificationType)
        {
            NotificationID = notificationId;
            UserID = userId;
            Content = content;
            Timestamp = timestamp;
            IsRead = isRead;
            NotificationType = notificationType;
        }
    }
}
