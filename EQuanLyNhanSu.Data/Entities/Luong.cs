using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Entities
{
    public class Luong 
    {
        public int  MaLuong { get; set; }
        public int LuongCoBan { get; set; }
        public int SoNgayLam { get; set; }
        public int PhuCap { get; set; }
        public int MaNV { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
