using Management.Shared.Enums.Roles;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    /// <summary>
    /// DB에 저장되는 모델들
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        [Required]
        [Compare("Email", ErrorMessage = "Please Write Email Address")]
        public string ConfirmEmail { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password NOT MATCH!")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Text, ErrorMessage = "Invalid")]
        public string GivenName { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Invalid")]
        public string FamilyName { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string DepartmentNumber { get; set; }

        public DateTime? MemberSince { get; set; } = DateTime.UtcNow;


        [NotMapped]
        public string Role { get; set; } = string.Empty;

        [NotMapped]
        public RoleList RoleLists { get; set; }
    }
}
