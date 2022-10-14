using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpiryDate { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        
    }
}
