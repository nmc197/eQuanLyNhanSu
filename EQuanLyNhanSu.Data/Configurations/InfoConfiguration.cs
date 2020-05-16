using EQuanLyNhanSu.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Configurations
{
    public class InfoConfiguration : IEntityTypeConfiguration<Info>
    {
        public void Configure(EntityTypeBuilder<Info> builder)
        {
            builder.ToTable("Infos");
            builder.HasKey(x => x.iMaNV);
            builder.Property(x => x.iMaNV).UseIdentityColumn();
            builder.Property(x => x.NoiSinh).HasMaxLength(100).IsRequired();
            builder.Property(x => x.TonGiao).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NguyenQuan).HasMaxLength(100).IsRequired();
            builder.Property(x => x.HKTT).HasMaxLength(100).IsRequired();
            builder.Property(x => x.HocVan).HasMaxLength(100).IsRequired();
            builder.Property(x => x.QuocTich).HasMaxLength(100).IsRequired();
            builder.Property(x => x.TrinhDoNgoaiNgu).HasMaxLength(100).IsRequired();
            builder.Property(x => x.SDT).HasMaxLength(100).IsRequired();
            builder.HasOne(x => x.NhanVien).WithOne(x => x.Info).HasForeignKey<Info>(x => x.MaNV);
        }
    }
}
