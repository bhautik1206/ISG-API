namespace ISG_api.Models.Entities
{
    public class User
    {
        public  int? UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }   
        public string Password { get; set; }
        public int isActive { get; set; }
        public int isDelete { get; set; }

    }
}
