using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Entities
{
    public class Info
    {
        public int iMaNV { get; set; }
        public int MaNV { get; set; }
        public string NoiSinh { get; set; }
        public string NguyenQuan { get; set; }
        public string HKTT { get; set; }
        public int SDT { get; set; }
        public string TonGiao { get; set; }
        public string QuocTich { get; set; }
        public string HocVan { get; set; }
        public string TrinhDoNgoaiNgu { get; set; }
        public NhanVien NhanVien { get; set; }

    }
}
