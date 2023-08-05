using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTu.Models
{
    public class DaoTrangs
    {
        [Key]
        public int daoTrangId { get; set; }
        public Boolean? daKetThuc { get; set; } = false;
        public string? noiDung{ get; set; }
        public string? noiToChuc { get; set; }
        public int? soThanhVienThamGia { get; set; }
        public DateTime? thoiGianToChuc { get; set; }
        public int? phatTuId { get; set; }
        public PhanTu? PhatTu { get; set; }
    }
}
