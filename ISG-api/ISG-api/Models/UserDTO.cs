using System.ComponentModel.DataAnnotations;

namespace ISG_api.Models
{
    public class UserDTO
    {
        public required int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Password { get; set; }
        public int isActive { get; set; }
        public int isDelete { get; set; }
    }
    public class ThreadDTO
    {
        public int ThreadID { get; set; }
        public int UserID { get; set; }
        public int City { get; set; }
        public int RegionID { get; set; }
        public int CountryID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? UpdateBy { get; set; }
    }
    public class ReviewDTO
    {
        public int UserId { get; set; }
        public int ThreadId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }

}
