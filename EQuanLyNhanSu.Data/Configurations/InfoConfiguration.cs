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
            builder.HasOne(x => x.NhanVien).WithOne(x => x.Info).HasForeignKey<Info>(x => x.MaNV);
        }
    }
}
