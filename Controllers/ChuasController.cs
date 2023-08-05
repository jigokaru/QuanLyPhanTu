using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhanTu.Iservices;
using QuanLyPhanTu.Models;
using QuanLyPhanTu.Services;

namespace QuanLyPhanTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuasController : ControllerBase
    {
        private readonly IChuasServices chuasService;

        public ChuasController()
        {
            chuasService = new ChuasServices();
        }
        [HttpPost("ThemChuas")]
        public IActionResult themChuas(Chuas chuas)
        {
            var res = chuasService.themChuas(chuas);
            return Ok(res);
        }
        [HttpPost("SuaChuas")]
        public IActionResult suachuas(Chuas chuas)
        {
            var res = chuasService.suaChuas(chuas);
            if (res)
            {
                return BadRequest("sua thong tin chua thanh cong!");
            }
            else
            {
                return BadRequest("id chùa sai!");
            }
        }
        [HttpPost("XoaChuas")]
        public IActionResult xoachuas(Chuas chuas)
        {
            var res = chuasService.xoaChuas(chuas);
            if (res)
            {
                return BadRequest("xoa thong tin chua thanh cong!");
            }
            else
            {
                return BadRequest("id chùa sai!");
            }
        }

    }
}
