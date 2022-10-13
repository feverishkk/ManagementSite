﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Dto.Account
{
    public class LoginResult
    {
        public bool Successful { get; set; }   
        public string Errors { get; set; }

        public string Token { get; set; }
    }
}
