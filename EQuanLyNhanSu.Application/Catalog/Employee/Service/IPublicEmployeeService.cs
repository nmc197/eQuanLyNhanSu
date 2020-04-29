using EQuanLyNhanSu.ViewModel.Catalog.Common;
using EQuanLyNhanSu.ViewModel.Catalog.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQuanLyNhanSu.Application.Catalog.Employee
{
    public interface IPublicEmployeeService
    {
        Task<List<EmployeeViewModel>> GetAllByNhanVienId(int id);
        Task<List<EmployeeViewModel>> GetAll();
        Task<List<EmployeeViewModel>> GetAllEByMaPb(int idPb);
    }

  
}
