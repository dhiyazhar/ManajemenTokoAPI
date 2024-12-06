using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KategoriJabatan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Jabatan = table.Column<string>(type: "text", nullable: false),
                    Gaji = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriJabatan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KategoriProduk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kategori = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriProduk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KategoriTransaksi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Tipe = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriTransaksi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Karyawan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: true),
                    Alamat = table.Column<string>(type: "text", nullable: true),
                    TanggalLahir = table.Column<DateOnly>(type: "date", nullable: false),
                    MulaiBekerja = table.Column<DateOnly>(type: "date", nullable: false),
                    JabatanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karyawan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Karyawan_KategoriJabatan_JabatanId",
                        column: x => x.JabatanId,
                        principalTable: "KategoriJabatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TokoId = table.Column<int>(type: "integer", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: true),
                    Harga = table.Column<decimal>(type: "numeric", nullable: false),
                    Diskon = table.Column<int>(type: "integer", nullable: false),
                    KategoriId = table.Column<int>(type: "integer", nullable: true),
                    Expired = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_KategoriProduk_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "KategoriProduk",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transaksi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TokoId = table.Column<int>(type: "integer", nullable: false),
                    TanggalTransaksi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipe = table.Column<int>(type: "integer", nullable: false),
                    Nominal = table.Column<int>(type: "integer", nullable: false),
                    KategoriId = table.Column<int>(type: "integer", nullable: false),
                    KategoriTransaksiId = table.Column<int>(type: "integer", nullable: true),
                    Deskripsi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaksi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaksi_KategoriTransaksi_KategoriTransaksiId",
                        column: x => x.KategoriTransaksiId,
                        principalTable: "KategoriTransaksi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karyawan_JabatanId",
                table: "Karyawan",
                column: "JabatanId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_KategoriId",
                table: "Product",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaksi_KategoriTransaksiId",
                table: "Transaksi",
                column: "KategoriTransaksiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Karyawan");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Transaksi");

            migrationBuilder.DropTable(
                name: "KategoriJabatan");

            migrationBuilder.DropTable(
                name: "KategoriProduk");

            migrationBuilder.DropTable(
                name: "KategoriTransaksi");
        }
    }
}
