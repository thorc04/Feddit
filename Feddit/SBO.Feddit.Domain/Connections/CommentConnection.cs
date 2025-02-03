using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBO.Feddit.Domain.Entities; // Import your entity namespace here

namespace SBO.Feddit.Domain.Connections
{
    public class CommentConnection
    {
        private SQL _sql;

        public CommentConnection()
        {
            _sql = new SQL();
        }

        #region Create Comment

        public async Task<bool> CreateCommentAsync(Comment comment)
        {
            SqlCommand sqlCommand = _sql.Execute("CreateComment");
            sqlCommand.Parameters.AddWithValue("@PostID", comment.PostID);
            sqlCommand.Parameters.AddWithValue("@UserID", comment.UserID);
            sqlCommand.Parameters.AddWithValue("@Content", comment.Content);
            sqlCommand.Parameters.AddWithValue("@Timestamp", comment.Timestamp);
            sqlCommand.Parameters.AddWithValue("@Upvotes", comment.Upvotes);
            sqlCommand.Parameters.AddWithValue("@Downvotes", comment.Downvotes);

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

        #region Read Comment

        public async Task<Comment> GetCommentAsync(int commentID)
        {
            SqlCommand sqlCommand = _sql.Execute("GetComment");
            sqlCommand.Parameters.AddWithValue("@CommentID", commentID);

            try
            {
                await sqlCommand.Connection.OpenAsync();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                Comment comment = null;

                if ( sqlDataReader.HasRows )
                {
                    while ( await sqlDataReader.ReadAsync() )
                    {
                        comment = new Comment(
                            sqlDataReader.GetInt32("CommentID"),
                            sqlDataReader.GetInt32("PostID"),
                            sqlDataReader.GetInt32("UserID"),
                            sqlDataReader.GetString("Content"),
                            sqlDataReader.GetDateTime("Timestamp"),
                            sqlDataReader.GetInt32("Upvotes"),
                            sqlDataReader.GetInt32("Downvotes")
                        );
                    }

                    await sqlDataReader.CloseAsync();
                }

                await sqlCommand.Connection.CloseAsync();

                return comment;
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

        // Other read methods (e.g., GetCommentsByPostAsync, GetCommentsByUserAsync) can be added here.

        #endregion

        #region Update Comment

        public async Task<bool> UpdateCommentAsync(Comment comment)
        {
            SqlCommand sqlCommand = _sql.Execute("UpdateComment");
            sqlCommand.Parameters.AddWithValue("@CommentID", comment.CommentID);
            sqlCommand.Parameters.AddWithValue("@PostID", comment.PostID);
            sqlCommand.Parameters.AddWithValue("@UserID", comment.UserID);
            sqlCommand.Parameters.AddWithValue("@Content", comment.Content);
            sqlCommand.Parameters.AddWithValue("@Timestamp", comment.Timestamp);
            sqlCommand.Parameters.AddWithValue("@Upvotes", comment.Upvotes);
            sqlCommand.Parameters.AddWithValue("@Downvotes", comment.Downvotes);

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

        #region Delete Comment

        public async Task<bool> DeleteCommentAsync(int commentID)
        {
            SqlCommand sqlCommand = _sql.Execute("DeleteComment");
            sqlCommand.Parameters.AddWithValue("@CommentID", commentID);

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
