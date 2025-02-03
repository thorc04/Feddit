using SBO.Feddit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Connections
{
    public class PostConnection
    {
        private SQL _sql;

        public PostConnection()
        {
            _sql = new SQL();
        }

        #region Create Post

        public async Task<bool> CreatePostAsync(Post post)
        {
            SqlCommand sqlCommand = _sql.Execute("CreatePost");
            sqlCommand.Parameters.AddWithValue("@UserID", post.UserID);
            sqlCommand.Parameters.AddWithValue("@Title", post.Title);
            sqlCommand.Parameters.AddWithValue("@Content", post.Content);
            sqlCommand.Parameters.AddWithValue("@Timestamp", post.Timestamp);
            sqlCommand.Parameters.AddWithValue("@Upvotes", post.Upvotes);
            sqlCommand.Parameters.AddWithValue("@Downvotes", post.Downvotes);

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

        #region Read Post

        public async Task<Post> GetPostAsync(int postID)
        {
            SqlCommand sqlCommand = _sql.Execute("GetPost");
            sqlCommand.Parameters.AddWithValue("@PostID", postID);

            try
            {
                await sqlCommand.Connection.OpenAsync();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                Post post = null;

                if ( sqlDataReader.HasRows )
                {
                    while ( await sqlDataReader.ReadAsync() )
                    {
                        post = new Post(
                            sqlDataReader.GetInt32("PostID"),
                            sqlDataReader.GetInt32("UserID"),
                            sqlDataReader.GetString("Title"),
                            sqlDataReader.GetString("Content"),
                            sqlDataReader.GetDateTime("Timestamp"),
                            sqlDataReader.GetInt32("Upvotes"),
                            sqlDataReader.GetInt32("Downvotes")
                        );
                    }

                    await sqlDataReader.CloseAsync();
                }

                await sqlCommand.Connection.CloseAsync();

                return post;
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

        // Other read methods (e.g., GetPostsByUserAsync) can be added here.

        #endregion

        #region Update Post

        public async Task<bool> UpdatePostAsync(Post post)
        {
            SqlCommand sqlCommand = _sql.Execute("UpdatePost");
            sqlCommand.Parameters.AddWithValue("@PostID", post.PostID);
            sqlCommand.Parameters.AddWithValue("@UserID", post.UserID);
            sqlCommand.Parameters.AddWithValue("@Title", post.Title);
            sqlCommand.Parameters.AddWithValue("@Content", post.Content);
            sqlCommand.Parameters.AddWithValue("@Timestamp", post.Timestamp);
            sqlCommand.Parameters.AddWithValue("@Upvotes", post.Upvotes);
            sqlCommand.Parameters.AddWithValue("@Downvotes", post.Downvotes);

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

        #region Delete Post

        public async Task<bool> DeletePostAsync(int postID)
        {
            SqlCommand sqlCommand = _sql.Execute("DeletePost");
            sqlCommand.Parameters.AddWithValue("@PostID", postID);

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
