using EQuanLyNhanSu.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Configurations
{
    public class LuongConfiguration : IEntityTypeConfiguration<Luong>
    {
        public void Configure(EntityTypeBuilder<Luong> builder)
        {
            builder.ToTable("Luongs");
            builder.HasKey(x => x.MaLuong);
            builder.Property(x => x.MaLuong).UseIdentityColumn();
            builder.HasOne(x => x.NhanVien).WithMany(x => x.Luongs).HasForeignKey(x => x.MaNV);
        }
    }
}
