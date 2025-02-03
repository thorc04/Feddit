using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.Feddit.Domain.Entities
{
    public class Message
    {
        public int? MessageID { get; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

        public Message(int? messageId, int senderId, int receiverId, string content, DateTime timestamp, bool isRead)
        {
            MessageID = messageId;
            SenderID = senderId;
            ReceiverID = receiverId;
            Content = content;
            Timestamp = timestamp;
            IsRead = isRead;
        }
    }
}
