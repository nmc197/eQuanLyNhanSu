using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EQuanLyNhanSu.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HKTT",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HocVan",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguyenQuan",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiSinh",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuocTich",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SDT",
                table: "NhanViens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TonGiao",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrinhDoNgoaiNgu",
                table: "NhanViens",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrinhDoNgoaiNgu",
                table: "Infos",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TonGiao",
                table: "Infos",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuocTich",
                table: "Infos",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoiSinh",
                table: "Infos",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NguyenQuan",
                table: "Infos",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HocVan",
                table: "Infos",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HKTT",
                table: "Infos",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            

            migrationBuilder.DropColumn(
                name: "HKTT",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "HocVan",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "NguyenQuan",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "NoiSinh",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "QuocTich",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "TonGiao",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "TrinhDoNgoaiNgu",
                table: "NhanViens");

            migrationBuilder.AlterColumn<string>(
                name: "TrinhDoNgoaiNgu",
                table: "Infos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "TonGiao",
                table: "Infos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "QuocTich",
                table: "Infos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NoiSinh",
                table: "Infos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NguyenQuan",
                table: "Infos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "HocVan",
                table: "Infos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "HKTT",
                table: "Infos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
