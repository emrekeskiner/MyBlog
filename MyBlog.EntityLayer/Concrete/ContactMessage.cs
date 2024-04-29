namespace MyBlog.EntityLayer.Concrete
{
    public class ContactMessage
    {
        public int ContactMessageId { get; set; }
        public string? NameSurname { get; set; }
        public string? Mail { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
