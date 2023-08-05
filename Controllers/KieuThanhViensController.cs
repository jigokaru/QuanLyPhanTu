using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhanTu.Iservices;
using QuanLyPhanTu.Models;
using QuanLyPhanTu.Services;

namespace QuanLyPhanTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KieuThanhViensController : ControllerBase
    {
        private readonly IKieuThanhViensServices kieuThanhViensServices;

        public KieuThanhViensController(IKieuThanhViensServices kieuThanhViensServices)
        {
            kieuThanhViensServices = new KieuThanhViensServices();
        }

        [HttpPost("ThemKieuThanhViens")]
        public IActionResult themkieuthanhvien(KieuThanhViens kieuThanhViens)
        {
            var res = kieuThanhViensServices.themkieuthanhvien(kieuThanhViens);
            return BadRequest("them kieu thanh vien thanh cong!");
        }
    }
}
