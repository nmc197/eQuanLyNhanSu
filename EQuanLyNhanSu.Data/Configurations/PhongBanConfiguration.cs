using EQuanLyNhanSu.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Configurations
{
    public class PhongBanConfiguration : IEntityTypeConfiguration<PhongBan>
    {
        public void Configure(EntityTypeBuilder<PhongBan> builder)
        {
            builder.ToTable("PhongBans");
            builder.HasKey(x => x.MaPb);
            builder.Property(x => x.MaPb).UseIdentityColumn().ValueGeneratedOnAdd();
        }
    }
}
