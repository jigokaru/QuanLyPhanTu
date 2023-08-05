using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTu.Models
{
    public class KieuThanhViens
    {
        [Key]
        public int? kieuThanhVienId { get; set; }
        public string? code{ get; set; }
        public string? tenKieu { get; set; }    
    }
}
