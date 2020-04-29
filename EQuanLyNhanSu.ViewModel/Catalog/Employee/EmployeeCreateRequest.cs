using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.ViewModel.Catalog.Employee
{
    public class EmployeeCreateRequest
    {
        public string TenNv { get; set; }
        public string GioiTinh { get; set; }
        public string ChucVu { get; set; }
        public int MaPb { get; set; }
        public int CMND { get; set; }
        public DateTime NgaySinh { get; set; }
    }
}
