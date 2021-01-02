using System;

namespace Models
{
    public class DbMessage
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public DbUser Sender { get; set; }
        public int RecipientId { get; set; }
        public DbUser Recipient { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; }
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
    }
}