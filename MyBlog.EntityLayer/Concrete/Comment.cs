namespace MyBlog.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

        public int ArticleId { get; set; }
        public Article Articles { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
