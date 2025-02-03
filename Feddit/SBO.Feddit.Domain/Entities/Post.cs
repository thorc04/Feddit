using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Entities
{
    public class Post
    {
        public int? PostID { get; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }

        public Post(int? postId, int userId, string title, string content, DateTime timestamp, int upvotes, int downvotes)
        {
            PostID = postId;
            UserID = userId;
            Title = title;
            Content = content;
            Timestamp = timestamp;
            Upvotes = upvotes;
            Downvotes = downvotes;
        }
    }
}
