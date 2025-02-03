using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Entities
{
    public class Subreddit
    {
        public int? SubredditID { get; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Subreddit(int? subredditId, string name, string description)
        {
            SubredditID = subredditId;
            Name = name;
            Description = description;
        }
    }
}
