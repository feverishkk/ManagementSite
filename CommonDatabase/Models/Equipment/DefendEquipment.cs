using System.ComponentModel.DataAnnotations;

namespace CommonDatabase.Models.Equipment
{
    public class DefendEquipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AC { get; set; }
        public string Class { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
