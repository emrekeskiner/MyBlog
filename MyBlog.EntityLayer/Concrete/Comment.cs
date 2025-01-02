namespace MyBlog.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Description { get; set; }
        public string? NameSurname { get; set; }
        public int UserId { get; set; } = 0;
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public bool Status { get; set; }
        public int ArticleId { get; set; }
        public Article Articles { get; set; }

    }
}
