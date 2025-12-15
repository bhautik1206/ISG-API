using System.ComponentModel.DataAnnotations;

namespace ISG_api.Models.Entities
{
    public class Threads
    {
        [Key]
        public int ThreadID { get; set; }
        public int  UserID { get; set; }
        public int  City { get; set; }
        public int  RegionID { get; set; }
        public int  CountryID { get; set; }
        public DateTime CreateBy { get; set; } =DateTime.Now;
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdateBy { get; set; } 

    }
}
