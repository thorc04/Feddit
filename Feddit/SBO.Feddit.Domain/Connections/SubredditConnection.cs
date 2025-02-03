using SBO.Feddit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Connections
{
    public class SubredditConnection
    {
        private SQL _sql;

        public SubredditConnection()
        {
            _sql = new SQL();
        }

        #region Create Subreddit

        public async Task<bool> CreateSubredditAsync(Subreddit subreddit)
        {
            SqlCommand sqlCommand = _sql.Execute("CreateSubreddit");
            sqlCommand.Parameters.AddWithValue("@Name", subreddit.Name);
            sqlCommand.Parameters.AddWithValue("@Description", subreddit.Description);

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
