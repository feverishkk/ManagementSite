using Management.Application.Enums.Roles;
using System.ComponentModel.DataAnnotations;

namespace Management.Application.ViewModel.Account
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }
        
        public string ConfirmEmail { get; set; }
        
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string Department { get; set; }

        public string DepartmentNumber { get; set; }

        [Required]
        public RoleList Role { get; set; }


    }
}
