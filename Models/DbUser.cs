using System;
using System.Collections.Generic;

namespace Models
{
    public class DbUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<DbPhoto> Photos { get; set; }
        public ICollection<DbLike> Likers { get; set; }
        public ICollection<DbLike> Likees { get; set; }
        public ICollection<DbMessage> MessagesSent { get; set; }
        public ICollection<DbMessage> MessagesReceived { get; set; }
    }
}