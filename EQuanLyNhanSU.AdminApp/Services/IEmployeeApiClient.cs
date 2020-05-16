using EQuanLyNhanSu.ViewModel.Catalog.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EQuanLyNhanSU.AdminApp.Services
{
    public interface IEmployeeApiClient
    {
        Task<List<EmployeeViewModel>> GetAll();
        Task<bool> Create(EmployeeCreateRequest request);
        Task<bool> Delete(int MaNV);
        Task<List<EmployeeViewModel>> GetById(int MaNV);
        Task<bool> Update(int MaNV,EmployeeUpdateRequest request);

    }
}
