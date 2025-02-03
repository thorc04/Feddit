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
    
    public class UserConnection
        {
            private SQL _sql;

            public UserConnection()
            {
                _sql = new SQL();
            }

            #region Create User

            public async Task<bool> CreateUserAsync(User user)
            {
                SqlCommand sqlCommand = _sql.Execute("CreateUser");
                sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                sqlCommand.Parameters.AddWithValue("@ProfilePicture", user.ProfilePicture);

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

        #region Read User

        public async Task<List<User>?> GetUsersAsync()
        {
            SqlCommand sqlCommand = _sql.Execute("GetUsers");
            try
            {
                await sqlCommand.Connection.OpenAsync();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                List<User> users = new List<User>();

                if ( sqlDataReader.HasRows )
                {
                    while ( await sqlDataReader.ReadAsync() )
                    {
                        users.Add(new User(
                            sqlDataReader.GetInt32("UserID"),
                            sqlDataReader.GetString("Username"),
                            sqlDataReader.GetString("Password"),
                            sqlDataReader.GetString("Email"),
                            sqlDataReader.GetDateTime("RegistrationDate"),
                            sqlDataReader.GetString("ProfilePicture")
                        ));
                    }

                    await sqlDataReader.CloseAsync();
                }

                await sqlCommand.Connection.CloseAsync();

                return users;
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

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            SqlCommand sqlCommand = _sql.Execute("GetUserByUsername");
            sqlCommand.Parameters.AddWithValue("@Username", username);

            try
            {
                await sqlCommand.Connection.OpenAsync();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                if ( sqlDataReader.HasRows && await sqlDataReader.ReadAsync() )
                {
                    User user = new User(
                        sqlDataReader.GetInt32("UserID"),
                        sqlDataReader.GetString("Username"),
                        sqlDataReader.GetString("Password"),
                        sqlDataReader.GetString("Email"),
                        sqlDataReader.GetDateTime("RegistrationDate"),
                        sqlDataReader.GetString("ProfilePicture")
                    );

                    await sqlDataReader.CloseAsync();
                    await sqlCommand.Connection.CloseAsync();

                    return user;
                }

                await sqlCommand.Connection.CloseAsync();
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



        #region Read User

        public async Task<User?> GetUserAsync(int userID)
        {
            SqlCommand sqlCommand = _sql.Execute("GetUser");
            sqlCommand.Parameters.AddWithValue("@UserID", userID);

            try
            {
                await sqlCommand.Connection.OpenAsync();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                User user = null;

                if ( sqlDataReader.HasRows )
                {
                    while ( await sqlDataReader.ReadAsync() )
                    {
                        user = new User(
                            sqlDataReader.GetInt32("UserID"),
                            sqlDataReader.GetString("Username"),
                            sqlDataReader.GetString("Password"),
                            sqlDataReader.GetString("Email"),
                            sqlDataReader.GetDateTime("RegistrationDate"),
                            sqlDataReader.GetString("ProfilePicture")
                        );
                    }

                    await sqlDataReader.CloseAsync();
                }

                await sqlCommand.Connection.CloseAsync();

                return user;
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

.



        #endregion

        #region Update User

        public async Task<bool> UpdateUserAsync(User user)
            {
                SqlCommand sqlCommand = _sql.Execute("UpdateUser");
                sqlCommand.Parameters.AddWithValue("@UserID", user.UserID);
                sqlCommand.Parameters.AddWithValue("@Username", user.Username);
                sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                sqlCommand.Parameters.AddWithValue("@ProfilePicture", user.ProfilePicture);

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

            #region Delete User

            public async Task<bool> DeleteUserAsync(int userID)
            {
                SqlCommand sqlCommand = _sql.Execute("DeleteUser");
                sqlCommand.Parameters.AddWithValue("@UserID", userID);

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

            public async Task<int> GetUsersCountAsync()
            {
                try
                {
                    int count = 0;

                    SqlCommand sqlCommand = _sql.Execute("GetUsersCount");
                    await sqlCommand.Connection.OpenAsync();
                    count = Convert.ToInt32(await sqlCommand.ExecuteScalarAsync());
                    await sqlCommand.Connection.CloseAsync();

                    return count;
                }
                catch ( SqlException sqlException )
                {
                    Console.WriteLine(sqlException.Message);
                }

                return 0;
            }

      

            #endregion
        }
    }
