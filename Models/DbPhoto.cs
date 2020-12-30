using System;

namespace Models
{
    public class DbPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DatedAdded { get; set; }
        public bool IsMain { get; set; }
        public DbUser User { get; set; }
        public int UserId { get; set; }

    }
}