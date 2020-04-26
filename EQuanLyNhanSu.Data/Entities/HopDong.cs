using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Entities
{
    public class HopDong
    {
        public int MaHD { get; set; }
        public int NgayBatDau { get; set; }
        public int NgayKetThuc { get; set; }
        public int MaNV { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
