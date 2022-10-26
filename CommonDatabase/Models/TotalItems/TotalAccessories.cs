using CommonDatabase.Models.Accessories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.TotalItems
{
    /// <summary>
    /// 모든 악세사리들을 다 가져오는 클래스
    /// </summary>
    public class TotalAccessories
    {
        [Key]
        public int TotalAccId { get; set; }
        public string Image { get; set; } = string.Empty;
        public int AC { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
