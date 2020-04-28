using EQuanLyNhanSu.ViewModel.Catalog.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQuanLyNhanSu.Application.Catalog.System
{
    public interface IUserService
    {
        Task<bool> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
