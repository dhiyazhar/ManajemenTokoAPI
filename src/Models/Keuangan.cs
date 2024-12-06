using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace src.Models
{
    [Table("Transaksi")]    
    public class Transaksi
    {
        [Key, Required]
        public int Id { get; private set; }
        public int TokoId { get; private set; }
        public DateTime TanggalTransaksi {  get; set; }
        public TipeTransaksi Tipe { get; set; }
        public int Nominal { get; set; }

        public int KategoriId { get; set; }
        public KategoriTransaksi? KategoriTransaksi { get; set; }
        public string? Deskripsi { get; set; }

    }
    public enum TipeTransaksi
    {
        Income = 1,
        Expense = 2
    }

    [Table("KategoriTransaksi")]
    public class KategoriTransaksi
    {
        [Key, Required]
        public int Id { get; private set; }
        public string Nama { get; set; } 
        public string Tipe { get; set; }
    }
}
