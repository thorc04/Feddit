using SBO.Feddit.Domain.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Connections
{
    public class MessageConnection
    {
        private SQL _sql;

        public MessageConnection()
        {
            _sql = new SQL();
        }

        #region Create Message

        public async Task<bool> CreateMessageAsync(Message message)
        {
            SqlCommand sqlCommand = _sql.Execute("CreateMessage");
            sqlCommand.Parameters.AddWithValue("@SenderID", message.SenderID);
            sqlCommand.Parameters.AddWithValue("@ReceiverID", message.ReceiverID);
            sqlCommand.Parameters.AddWithValue("@Content", message.Content);
            sqlCommand.Parameters.AddWithValue("@Timestamp", message.Timestamp);
            sqlCommand.Parameters.AddWithValue("@IsRead", message.IsRead);

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

        #region Update Message

        public async Task<bool> UpdateMessageAsync(Message message)
        {
            SqlCommand sqlCommand = _sql.Execute("UpdateMessage");
            sqlCommand.Parameters.AddWithValue("@MessageID", message.MessageID);
            sqlCommand.Parameters.AddWithValue("@SenderID", message.SenderID);
            sqlCommand.Parameters.AddWithValue("@ReceiverID", message.ReceiverID);
            sqlCommand.Parameters.AddWithValue("@Content", message.Content);
            sqlCommand.Parameters.AddWithValue("@Timestamp", message.Timestamp);
            sqlCommand.Parameters.AddWithValue("@IsRead", message.IsRead);

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

        #region Delete Message

        public async Task<bool> DeleteMessageAsync(int messageID)
        {
            SqlCommand sqlCommand = _sql.Execute("DeleteMessage");
            sqlCommand.Parameters.AddWithValue("@MessageID", messageID);

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

        #region Get Message

        public async Task<Message> GetMessageAsync(int messageID)
        {
            SqlCommand sqlCommand = _sql.Execute("GetMessage");
            sqlCommand.Parameters.AddWithValue("@MessageID", messageID);

            try
            {
                await sqlCommand.Connection.OpenAsync();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                Message message = null;

                if ( sqlDataReader.HasRows )
                {
                    while ( await sqlDataReader.ReadAsync() )
                    {
                        message = new Message(
                            sqlDataReader.GetInt32("MessageID"),
                            sqlDataReader.GetInt32("SenderID"),
                            sqlDataReader.GetInt32("ReceiverID"),
                            sqlDataReader.GetString("Content"),
                            sqlDataReader.GetDateTime("Timestamp"),
                            sqlDataReader.GetBoolean("IsRead")
                        );
                    }

                    await sqlDataReader.CloseAsync();
                }

                await sqlCommand.Connection.CloseAsync();

                return message;
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
