using System.ComponentModel.DataAnnotations;

namespace ISG_api.Models.Entities
{
    public class Country
    {
        [Key]
       public int CountryId { get; set; }
      public string ? CountryName { get; set; }
      public int RegionID { get; set; }
    }
}
