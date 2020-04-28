using EQuanLyNhanSu.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.HasOne(x => x.NhanVien).WithMany(x => x.Users).HasForeignKey(x => x.MaNV);
        }
    }
}
