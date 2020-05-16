using EQuanLyNhanSu.ViewModel.Catalog.System;
using EQuanLyNhanSu.ViewModel.Catalog.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EQuanLyNhanSU.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
        Task<List<UserViewModel>> GetUserRequest( );
    }
}
