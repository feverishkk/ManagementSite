using System.ComponentModel.DataAnnotations;

namespace CommonDatabase.Models.Accessories
{
    public class Belt
    {
        [Key]
        public int? BeltId { get; set; } = default(int?);
        public string? Name { get; set; } = default;
        public int? AC { get; set; } = default(int?);
        public string? Class { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

    }
}
