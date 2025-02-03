using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Entities
{
    public class Vote
    {
        public int? VoteID { get; }
        public int UserID { get; set; }
        public int PostID { get; set; }
        public int CommentID { get; set; }
        public int VoteType { get; set; }

        public Vote(int? voteId, int userId, int postId, int commentId, int voteType)
        {
            VoteID = voteId;
            UserID = userId;
            PostID = postId;
            CommentID = commentId;
            VoteType = voteType;
        }
    }
}
