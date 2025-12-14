namespace ISG_api.Models.Entities
{
    public class City
    {
        public int Id { get; set; }

        public int StateId { get; set; }   // FK

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
