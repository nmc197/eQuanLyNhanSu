using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Entities
{
    public class NhanVien
    {
       public int MaNV { get; set; }
       public string TenNv { get; set; }
        public string GioiTinh { get; set; }
        public string ChucVu { get; set; }
        public int MaPb { get; set; }
        public int CMND { get; set; }
        public DateTime NgaySinh { get; set; }
        public PhongBan PhongBan { get; set; }
        public List<Luong> Luongs { get; set; }
        public HopDong HopDong { get; set; }
        public Info Info { get; set; }
    }
}
