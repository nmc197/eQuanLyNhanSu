using EQuanLyNhanSu.Data.Configurations;
using EQuanLyNhanSu.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Data.EF
{
    public class EQuanLyNhanSuDbContext : IdentityDbContext<AppUser, AppRole, Guid>
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
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<Luong> Luongs { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }
        public DbSet<Info> Infos { get; set; }
    }
}