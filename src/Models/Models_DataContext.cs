using Microsoft.EntityFrameworkCore;

namespace src.Models
{
    public class Models_DataContext : DbContext
    {
        public Models_DataContext(DbContextOptions<Models_DataContext> options) : base(options) { } 
        
        public DbSet<Produk> Produks { get; set; }
        public DbSet<KategoriProduk> KategoriProduk { get; set; }

        public DbSet<Karyawan> Karyawan { get; set; } 
        public DbSet<KategoriJabatan> KategoriJabatan { get; set; }

        public DbSet<Transaksi> Transaksi { get; set; }
        public DbSet<KategoriTransaksi> KategoriTransaksi { get; set; }

    }
}
