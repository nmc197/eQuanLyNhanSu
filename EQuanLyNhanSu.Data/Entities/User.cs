using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Entities
{
    public class User
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MaNV { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
