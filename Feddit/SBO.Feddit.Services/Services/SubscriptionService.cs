using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBO.Feddit.Domain.Entities;
using SBO.Feddit.Domain.Connections;

namespace SBO.Feddit.Services.Services
{
    public class SubscriptionService
    {
        private SubscriptionConnection _subscriptionConnection;

        public SubscriptionService()
        {
            _subscriptionConnection = new SubscriptionConnection();
        }

        #region Create Subscription

        public async Task<bool> CreateSubscriptionAsync(Subscription subscription)
        {
            return await _subscriptionConnection.CreateSubscriptionAsync(subscription);
        }

        #endregion

        #region Miscellaneous

        // Miscellaneous methods can be added here.

        #endregion
    }
}
