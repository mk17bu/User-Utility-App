namespace UserData
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostingDate { get; set; }
        public User Author { get; set; }
    }
}
