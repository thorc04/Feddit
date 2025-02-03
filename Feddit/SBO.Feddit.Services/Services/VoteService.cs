using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBO.Feddit.Domain.Entities;
using SBO.Feddit.Domain.Connections;

namespace SBO.Feddit.Services.Services
{
    public class VoteService
    {
        private VoteConnection _voteConnection;

        public VoteService()
        {
            _voteConnection = new VoteConnection();
        }

        #region Create Vote

        public async Task<bool> CreateVoteAsync(Vote vote)
        {
            return await _voteConnection.CreateVoteAsync(vote);
        }

        #endregion

        #region Miscellaneous

        // Miscellaneous methods can be added here.

        #endregion
    }
}
