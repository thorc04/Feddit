using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBO.Feddit.Domain.Entities;
using SBO.Feddit.Domain.Connections;

namespace SBO.Feddit.Services.Services
{
    public class SubredditService
    {
        private SubredditConnection _subredditConnection;

        public SubredditService()
        {
            _subredditConnection = new SubredditConnection();
        }

        #region Create Subreddit

        public async Task<bool> CreateSubredditAsync(Subreddit subreddit)
        {
            return await _subredditConnection.CreateSubredditAsync(subreddit);
        }

        #endregion

        #region Miscellaneous

        // Miscellaneous methods can be added here.

        #endregion
    }
}
