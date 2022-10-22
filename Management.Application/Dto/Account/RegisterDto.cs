using Management.Application.Enums.Roles;
using System.ComponentModel.DataAnnotations;

namespace Management.Application.Dto.Account
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("Email", ErrorMessage = "Please Write Email Address")]
        public string ConfirmEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password Does NOT match")]
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

        [Required]
        public RoleList Role { get; set; }


    }
}
