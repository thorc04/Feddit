using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Entities
{
    public class Subscription
    {
        public int? SubscriptionID { get; }
        public int UserID { get; set; }
        public int SubredditID { get; set; }
        public DateTime SubscriptionDate { get; set; }

        public Subscription(int? subscriptionId, int userId, int subredditId, DateTime subscriptionDate)
        {
            SubscriptionID = subscriptionId;
            UserID = userId;
            SubredditID = subredditId;
            SubscriptionDate = subscriptionDate;
        }
    }
}
