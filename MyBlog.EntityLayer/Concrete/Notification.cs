namespace MyBlog.EntityLayer.Concrete
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string? Title { get; set; }
        public string? Description{ get; set; }
        public bool Status { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
