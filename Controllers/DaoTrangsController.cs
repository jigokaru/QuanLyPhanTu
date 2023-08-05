using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhanTu.Dto;
using QuanLyPhanTu.Helper;
using QuanLyPhanTu.Iservices;
using QuanLyPhanTu.Models;
using QuanLyPhanTu.Services;
using System.IdentityModel.Tokens.Jwt;

namespace QuanLyPhanTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaoTrangsController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly IDaoTrangsServices daoTrangsServices;
        public DaoTrangsController()
        {
            appDbContext = new AppDbContext();
            daoTrangsServices = new DaoTrangsServices();
        }
        [HttpPost("ThemDaoTrangs"), Authorize(Roles = "ADMIN")]
        public IActionResult themDaoTrangs(DaoTrangsDto daoTrangsDto)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            var res = daoTrangsServices.themDaoTrangs(id, daoTrangsDto);
            return Ok(res);
        }
        [HttpPost("SuaDaoTrangs"), Authorize(Roles = "ADMIN")]
        public IActionResult suaDaoTrangs(DaoTrangsDto daoTrangsDto)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            var res = daoTrangsServices.suaDaoTrangs(id, daoTrangsDto);
            if (res == true)
            {

                return BadRequest("sua thanh cong!");
            }
            else
            {
                return BadRequest("dao trangs not foud!");
            }
        }
        [HttpPost("XoaDaoTrangs"), Authorize(Roles = "ADMIN")]
        public IActionResult xoaDaoTrangs(int DaoTrangsId)
        {
            var res = daoTrangsServices.xoaDaoTrangs(DaoTrangsId);
            if (res)
            {
                return BadRequest("xoa chanh cong!");
            }
            else
            {
                return BadRequest("dao trangs Id not foud!");
            }
        }
        [HttpGet("LayDanhSachDaoTrangs"), Authorize(Roles ="ADMIN")]
        public IActionResult layDsDaoTrangs(bool? daKetThuc, string? noiToChuc, int? thang, int? nam, int pageNumber = 1,
                                                int pageSize = 10)
        {
            var res = daoTrangsServices.layDsDaoTrangs(daKetThuc, noiToChuc, thang, nam);
            var result = PageResult<DaoTrangs>.ToPageResult(res, pageNumber, pageSize);
            return Ok(result);
        }

        private int? GetIdFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);

            var idClaim = token.Claims.FirstOrDefault(c => c.Type == "accountId");
            if (idClaim != null)
            {
                int Id;
                if (int.TryParse(idClaim.Value, out Id))
                {
                    return Id;
                }
            }

            return null;
        }

    }
}
