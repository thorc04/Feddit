using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Entities
{
    public class Comment
    {
        public int? CommentID { get; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }

        public Comment(int? commentId, int postId, int userId, string content, DateTime timestamp, int upvotes, int downvotes)
        {
            CommentID = commentId;
            PostID = postId;
            UserID = userId;
            Content = content;
            Timestamp = timestamp;
            Upvotes = upvotes;
            Downvotes = downvotes;
        }
    }
}
