namespace Common.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int CurrentPostId { get; set; }
        public Post CurrentPost { get; set; }
    }
}
