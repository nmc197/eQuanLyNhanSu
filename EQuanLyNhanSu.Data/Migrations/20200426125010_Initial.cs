using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EQuanLyNhanSu.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhongBans",
                columns: table => new
                {
                    MaPb = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhongBan = table.Column<string>(nullable: true),
                    SDT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBans", x => x.MaPb);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNV = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNv = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<string>(nullable: true),
                    ChucVu = table.Column<string>(nullable: true),
                    MaPb = table.Column<int>(nullable: false),
                    CMND = table.Column<int>(nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanViens_PhongBans_MaPb",
                        column: x => x.MaPb,
                        principalTable: "PhongBans",
                        principalColumn: "MaPb",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDongs",
                columns: table => new
                {
                    MaHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayBatDau = table.Column<int>(nullable: false),
                    NgayKetThuc = table.Column<int>(nullable: false),
                    MaNV = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongs", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HopDongs_NhanViens_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanViens",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    iMaNV = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<int>(nullable: false),
                    NoiSinh = table.Column<string>(nullable: true),
                    NguyenQuan = table.Column<string>(nullable: true),
                    HKTT = table.Column<string>(nullable: true),
                    SDT = table.Column<int>(nullable: false),
                    TonGiao = table.Column<string>(nullable: true),
                    QuocTich = table.Column<string>(nullable: true),
                    HocVan = table.Column<string>(nullable: true),
                    TrinhDoNgoaiNgu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.iMaNV);
                    table.ForeignKey(
                        name: "FK_Infos_NhanViens_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanViens",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Luongs",
                columns: table => new
                {
                    MaLuong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuongCoBan = table.Column<int>(nullable: false),
                    SoNgayLam = table.Column<int>(nullable: false),
                    PhuCap = table.Column<int>(nullable: false),
                    MaNV = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luongs", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK_Luongs_NhanViens_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanViens",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_MaNV",
                table: "HopDongs",
                column: "MaNV",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Infos_MaNV",
                table: "Infos",
                column: "MaNV",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Luongs_MaNV",
                table: "Luongs",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_MaPb",
                table: "NhanViens",
                column: "MaPb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HopDongs");

            migrationBuilder.DropTable(
                name: "Infos");

            migrationBuilder.DropTable(
                name: "Luongs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "PhongBans");
        }
    }
}
