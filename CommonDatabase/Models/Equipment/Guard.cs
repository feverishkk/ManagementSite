using System.ComponentModel.DataAnnotations;

namespace CommonDatabase.Models.Equipment
{
    public class Guard
    {
        [Key]
        public int GuardId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int AC { get; set; } = 0;
        public string Class { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
