using SBO.Feddit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Connections
{
    public class SubscriptionConnection
    {
        private SQL _sql;

        public SubscriptionConnection()
        {
            _sql = new SQL();
        }

        #region Create Subscription

        public async Task<bool> CreateSubscriptionAsync(Subscription subscription)
        {
            SqlCommand sqlCommand = _sql.Execute("CreateSubscription");
            sqlCommand.Parameters.AddWithValue("@UserID", subscription.UserID);
            sqlCommand.Parameters.AddWithValue("@SubredditID", subscription.SubredditID);
            sqlCommand.Parameters.AddWithValue("@SubscriptionDate", subscription.SubscriptionDate);

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

        #region Miscellaneous

        // Miscellaneous methods can be added here.

        #endregion
    }
}
