namespace ISG_api.Models.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int UserId { get; set; }

        public int? ThreadId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
