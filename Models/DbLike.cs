namespace Models
{
    public class DbLike
    {
        public int LikerId { get; set; }
        public int LikeeId { get; set; }
        public DbUser Liker { get; set; }
        public DbUser Likee { get; set; }
    }
}