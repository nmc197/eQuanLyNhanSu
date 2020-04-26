using EQuanLyNhanSu.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Configurations
{
    public class HopDongConfiguration : IEntityTypeConfiguration<HopDong>
    {
        public void Configure(EntityTypeBuilder<HopDong> builder)
        {
            builder.ToTable("HopDongs");
            builder.HasKey(x => x.MaHD);
            builder.Property(x => x.MaHD).UseIdentityColumn();
            builder.HasOne(x => x.NhanVien).WithOne(x => x.HopDong).HasForeignKey<HopDong>(x => x.MaNV);
        }
    }
}
