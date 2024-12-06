using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace src.Models
{
    [Table("Product")]
    public class Produk
    {
        [Key, Required]
        public int Id { get; private set; }
        public int TokoId { get; private set; }
        public string? Nama { get; set; }
        public decimal Harga { get; set; }
        public int Diskon { get; set; }
        public KategoriProduk? Kategori { get; set; }
        public DateTime Expired { get; set; }

    }

    [Table("KategoriProduk")]
    public class KategoriProduk
    {
        [Key, Required]
        public int Id { get; private set; }
        public string Kategori { get; set; }
    }
}
