using SBO.Feddit.Domain.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Connections
{
    public class NotificationConnection
    {
        private SQL _sql;

        public NotificationConnection()
        {
            _sql = new SQL();
        }

        #region Create Notification

        public async Task<bool> CreateNotificationAsync(Notification notification)
        {
            SqlCommand sqlCommand = _sql.Execute("CreateNotification");
            sqlCommand.Parameters.AddWithValue("@UserID", notification.UserID);
            sqlCommand.Parameters.AddWithValue("@Content", notification.Content);
            sqlCommand.Parameters.AddWithValue("@Timestamp", notification.Timestamp);
            sqlCommand.Parameters.AddWithValue("@IsRead", notification.IsRead);
            sqlCommand.Parameters.AddWithValue("@NotificationType", notification.NotificationType);

            try
            {
                await sqlCommand.Connection.OpenAsync();
                int rowsAffected = await sqlCommand.ExecuteNonQueryAsync();
                await sqlCommand.Connection.CloseAsync();
                return rowsAffected > 0;
            }
            catch ( SqlException exception )
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                await sqlCommand.Connection.CloseAsync();
            }

            return false;
        }

        #endregion

        #region Update Notification

        public async Task<bool> UpdateNotificationAsync(Notification notification)
        {
            SqlCommand sqlCommand = _sql.Execute("UpdateNotification");
            sqlCommand.Parameters.AddWithValue("@NotificationID", notification.NotificationID);
            sqlCommand.Parameters.AddWithValue("@UserID", notification.UserID);
            sqlCommand.Parameters.AddWithValue("@Content", notification.Content);
            sqlCommand.Parameters.AddWithValue("@Timestamp", notification.Timestamp);
            sqlCommand.Parameters.AddWithValue("@IsRead", notification.IsRead);
            sqlCommand.Parameters.AddWithValue("@NotificationType", notification.NotificationType);

            try
            {
                await sqlCommand.Connection.OpenAsync();
                int rowsAffected = await sqlCommand.ExecuteNonQueryAsync();
                await sqlCommand.Connection.CloseAsync();
                return rowsAffected > 0;
            }
            catch ( SqlException exception )
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                await sqlCommand.Connection.CloseAsync();
            }

            return false;
        }

        #endregion

        #region Delete Notification

        public async Task<bool> DeleteNotificationAsync(int notificationID)
        {
            SqlCommand sqlCommand = _sql.Execute("DeleteNotification");
            sqlCommand.Parameters.AddWithValue("@NotificationID", notificationID);

            try
            {
                await sqlCommand.Connection.OpenAsync();
                int rowsAffected = await sqlCommand.ExecuteNonQueryAsync();
                await sqlCommand.Connection.CloseAsync();
                return rowsAffected > 0;
            }
            catch ( SqlException exception )
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                await sqlCommand.Connection.CloseAsync();
            }

            return false;
        }

        #endregion

        #region Get Notification

        public async Task<Notification> GetNotificationAsync(int notificationID)
        {
            SqlCommand sqlCommand = _sql.Execute("GetNotification");
            sqlCommand.Parameters.AddWithValue("@NotificationID", notificationID);

            try
            {
                await sqlCommand.Connection.OpenAsync();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                Notification notification = null;

                if ( sqlDataReader.HasRows )
                {
                    while ( await sqlDataReader.ReadAsync() )
                    {
                        notification = new Notification(
                            sqlDataReader.GetInt32("NotificationID"),
                            sqlDataReader.GetInt32("UserID"),
                            sqlDataReader.GetString("Content"),
                            sqlDataReader.GetDateTime("Timestamp"),
                            sqlDataReader.GetBoolean("IsRead"),
                            sqlDataReader.GetString("NotificationType")
                        );
                    }

                    await sqlDataReader.CloseAsync();
                }

                await sqlCommand.Connection.CloseAsync();

                return notification;
            }
            catch ( SqlException exception )
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                await sqlCommand.Connection.CloseAsync();
            }

            return null;
        }

        #endregion

        #region Miscellaneous

        // Miscellaneous methods can be added here.

        #endregion
    }
}
