using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SBO.Feddit.Domain.Entities;
using SBO.Feddit.Domain.Connections;

namespace SBO.Feddit.Services.Services
{
    public class UserService
    {
        private UserConnection _userConnection;

        public UserService()
        {
            _userConnection = new UserConnection();
        }

        #region Create User

        public async Task<bool> CreateUserAsync(User user)
        {
            return await _userConnection.CreateUserAsync(user);
        }

        #endregion

        #region Read User

        public async Task<User?> GetUserAsync(int userID)
        {
            return await _userConnection.GetUserAsync(userID);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _userConnection.GetUserByUsernameAsync(username);
        }

        public async Task<List<User>?> GetUsersAsync()
        {
            return await _userConnection.GetUsersAsync();
        }

        #endregion

        #region Update User

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await _userConnection.UpdateUserAsync(user);
        }

        #endregion

        #region Delete User

        public async Task<bool> DeleteUserAsync(int userID)
        {
            return await _userConnection.DeleteUserAsync(userID);
        }

        #endregion

        #region Miscellaneous

        // Miscellaneous methods can be added here.

        #endregion
    }
}
