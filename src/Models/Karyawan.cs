using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace src.Models
{
    [Table("Karyawan")]
    public class Karyawan
    {
        [Key, Required]
        public int Id { get; private set; }
        public string? Nama { get; set; }
        public string? Alamat { get; set; }
        public DateOnly TanggalLahir { get; set; }
        public DateOnly MulaiBekerja { get; set; }
        public int JabatanId { get; set; }
        public KategoriJabatan? Jabatan { get; set; }

    }

    [Table("KategoriJabatan")]
    public class KategoriJabatan
    {
        [Key, Required]
        public int Id { get; private set;}
        public string Jabatan { get; set;}
        public int Gaji { get; set; }
        public ICollection<Karyawan> Karyawan { get; set; }

    }

    
}
