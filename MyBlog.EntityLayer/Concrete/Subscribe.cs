namespace MyBlog.EntityLayer.Concrete
{
    public class Subscribe
    {
        public int SubscribeId { get; set; }
        public string? SubscribeMail { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsTrue { get; set; }=true;
    }
}
