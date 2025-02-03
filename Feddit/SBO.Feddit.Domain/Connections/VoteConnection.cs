using SBO.Feddit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Connections
{
    public class VoteConnection
    {
        private SQL _sql;

        public VoteConnection()
        {
            _sql = new SQL();
        }

        #region Create Vote

        public async Task<bool> CreateVoteAsync(Vote vote)
        {
            SqlCommand sqlCommand = _sql.Execute("CreateVote");
            sqlCommand.Parameters.AddWithValue("@UserID", vote.UserID);
            sqlCommand.Parameters.AddWithValue("@PostID", vote.PostID);
            sqlCommand.Parameters.AddWithValue("@CommentID", vote.CommentID);
            sqlCommand.Parameters.AddWithValue("@VoteType", vote.VoteType);

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
