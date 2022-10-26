using System.ComponentModel.DataAnnotations;

namespace CommonDatabase.Models.Accessories
{
    public class Ring2
    {
        [Key]
        public int Ring2Id { get; set; } 
        public string Name { get; set; }
        public int AC { get; set; } 
        public string Class { get; set; } 
        public string Image { get; set; } 
        public string Description { get; set; } 

    }
}
