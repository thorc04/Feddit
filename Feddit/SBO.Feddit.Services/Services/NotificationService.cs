using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBO.Feddit.Domain.Entities;
using SBO.Feddit.Domain.Connections;

namespace SBO.Feddit.Services.Services
{
    public class NotificationService
    {
        private NotificationConnection _notificationConnection;

        public NotificationService()
        {
            _notificationConnection = new NotificationConnection();
        }

        #region Create Notification

        public async Task<bool> CreateNotificationAsync(Notification notification)
        {
            return await _notificationConnection.CreateNotificationAsync(notification);
        }

        #endregion

        #region Miscellaneous




        #endregion
    }
}
