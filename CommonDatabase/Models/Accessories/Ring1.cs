using System.ComponentModel.DataAnnotations;

namespace CommonDatabase.Models.Accessories
{
    public class Ring1
    {
        [Key]
        public int Ring1Id { get; set; } 
        public string Name { get; set; } 
        public int AC { get; set; } 
        public string Class { get; set; } 
        public string Image { get; set; } 
        public string Description { get; set; }

    }
    
}
