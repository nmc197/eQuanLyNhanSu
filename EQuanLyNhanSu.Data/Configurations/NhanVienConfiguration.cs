using EQuanLyNhanSu.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Configurations
{
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("NhanViens");
            builder.HasKey(x => x.MaNV);
            builder.Property(x => x.MaNV).UseIdentityColumn();
            builder.HasOne(x => x.PhongBan).WithMany(x => x.NhanViens).HasForeignKey(x => x.MaPb);

        }
    }
}
