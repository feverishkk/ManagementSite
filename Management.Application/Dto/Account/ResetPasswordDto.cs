﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Dto.Account
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get;set; }

        public string Token { get; set; }

    }
}
