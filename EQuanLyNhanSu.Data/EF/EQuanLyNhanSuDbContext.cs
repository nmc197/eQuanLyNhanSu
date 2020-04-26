using EQuanLyNhanSu.Data.Configurations;
using EQuanLyNhanSu.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.EF
{
    public class EQuanLyNhanSuDbContext: DbContext
    {
        public EQuanLyNhanSuDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NhanVienConfiguration());
            modelBuilder.ApplyConfiguration(new PhongBanConfiguration());
            modelBuilder.ApplyConfiguration(new LuongConfiguration());
            modelBuilder.ApplyConfiguration(new HopDongConfiguration());
            modelBuilder.ApplyConfiguration(new InfoConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<Luong> Luongs { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }
        public DbSet<Info> Infos { get; set; }
    }
}
