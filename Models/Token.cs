using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTu.Models
{
    public class Token
    {
        [Key]
        public int? Id { get; set; }
        public string? stoken { get; set; }
        public DateTime? expiresAt { get; set; }
        public bool? expired { get; private set; } 
       
        public bool? revoked { get; private set; }

        public string? token_type { get; set; }
        public int? phatTuId { get; set; }
        public PhanTu? phatTu { get; set; }

        
        
    }
}
