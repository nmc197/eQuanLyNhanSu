﻿using EQuanLyNhanSu.ViewModel.Catalog.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQuanLyNhanSu.Application.Catalog.System
{
    public class UserService : IUserService
    {
        public Task<bool> Authencate(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
