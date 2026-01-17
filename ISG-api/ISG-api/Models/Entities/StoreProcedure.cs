using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ISG_api.Models.Entities
{
    public class StoreProcedure
    {
        [Keyless]
        public class SpAddThread_Result
        {
            public int Result { get; set; }
        }
        [Keyless]
        public class SpAddReview_Result
        {
            public int Result { get; set; }
        }
        public class SpGetAllThread_Result
        {
            [Key]
            public int ThreadID { get; set; }
            public int UserID { get; set; }
            public int City { get; set; }
            public int RegionID { get; set; }
            public int CountryID { get; set; }
            public DateTime CreateBy { get; set; } = DateTime.Now;
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime UpdateBy { get; set; }

        }
    }
}
