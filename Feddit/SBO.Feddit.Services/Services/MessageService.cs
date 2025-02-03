using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBO.Feddit.Domain.Entities;
using SBO.Feddit.Domain.Connections;

namespace SBO.Feddit.Services.Services
{
    public class MessageService
    {
        private MessageConnection _messageConnection;

        public MessageService()
        {
            _messageConnection = new MessageConnection();
        }

        #region Create Message

        public async Task<bool> CreateMessageAsync(Message message)
        {
            return await _messageConnection.CreateMessageAsync(message);
        }

        #endregion

        #region Miscellaneous



        #endregion
    }
}
