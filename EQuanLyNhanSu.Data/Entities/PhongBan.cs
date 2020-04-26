using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Entities
{
    public class PhongBan
    {
        public int  MaPb { get; set; }
        public string  TenPhongBan { get; set; }
        public int  SDT { get; set; }

        public List<NhanVien> NhanViens { get; set; }
    }
}
