using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBO.Feddit.Domain.Entities;
using SBO.Feddit.Domain.Connections;

namespace SBO.Feddit.Services.Services
{
    public class CommentService
    {
        private CommentConnection _commentConnection;

        public CommentService()
        {
            _commentConnection = new CommentConnection();
        }

        #region Create Comment

        public async Task<bool> CreateCommentAsync(Comment comment)
        {
            return await _commentConnection.CreateCommentAsync(comment);
        }

        #endregion

        #region Read Comment

        public async Task<Comment?> GetCommentAsync(int commentID)
        {
            return await _commentConnection.GetCommentAsync(commentID);
        }

        // Other read methods (e.g., GetCommentsByPostAsync, GetCommentsByUserAsync) can be added here.

        #endregion

        #region Update Comment

        public async Task<bool> UpdateCommentAsync(Comment comment)
        {
            return await _commentConnection.UpdateCommentAsync(comment);
        }

        #endregion

        #region Delete Comment

        public async Task<bool> DeleteCommentAsync(int commentID)
        {
            return await _commentConnection.DeleteCommentAsync(commentID);
        }

        #endregion

        #region Miscellaneous

        // Miscellaneous methods can be added here.

        #endregion
    }
}
