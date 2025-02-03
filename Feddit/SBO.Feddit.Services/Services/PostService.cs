using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBO.Feddit.Domain.Entities;
using SBO.Feddit.Domain.Connections;

namespace SBO.Feddit.Services.Services
{
    public class PostService
    {
        private PostConnection _postConnection;

        public PostService()
        {
            _postConnection = new PostConnection();
        }

        #region Create Post

        public async Task<bool> CreatePostAsync(Post post)
        {
            return await _postConnection.CreatePostAsync(post);
        }

        #endregion

        #region Read Post

        public async Task<Post?> GetPostAsync(int postID)
        {
            return await _postConnection.GetPostAsync(postID);
        }

        // Other read methods (e.g., GetPostsByUserAsync) can be added here.

        #endregion

        #region Update Post

        public async Task<bool> UpdatePostAsync(Post post)
        {
            return await _postConnection.UpdatePostAsync(post);
        }

        #endregion

        #region Delete Post

        public async Task<bool> DeletePostAsync(int postID)
        {
            return await _postConnection.DeletePostAsync(postID);
        }

        #endregion

        #region Miscellaneous

        // Miscellaneous methods can be added here.

        #endregion
    }
}
