using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTu.Models
{
    public class Chuas
    {
        [Key]
        public int chuaId { get; set; }
        public DateTime capNhap { get; set; }
        public string diaChi { get; set; }
        public DateTime ngayThanhLap { get; set; }
        public string tenChua { get; set; }
        
    }
}
