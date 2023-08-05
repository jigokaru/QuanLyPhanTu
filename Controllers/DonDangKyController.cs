using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhanTu.Dto;
using QuanLyPhanTu.Iservices;
using QuanLyPhanTu.Models;
using QuanLyPhanTu.Services;
using System.IdentityModel.Tokens.Jwt;

namespace QuanLyPhanTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonDangKyController : ControllerBase
    {
        private readonly IDonDangKyServices donDangKyServices;

        public DonDangKyController()
        {
            donDangKyServices = new DonDangKyServices();
        }
        [HttpPost("ThemDonDangKy"),Authorize(Roles ="ADMIN")]
        public IActionResult themDonDangKys(DonDangKysDto donDangKysDto)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            var res = donDangKyServices.themDonDangKys(id ,donDangKysDto);
            return Ok(res);
        }
        
        [HttpPost("XoaDonDangKy"), Authorize(Roles = "ADMIN")]
        public IActionResult xoaDonDangKys(int donDangKyId)
        {
            var res = donDangKyServices.xoaDonDangKys(donDangKyId);
            if (res)
            {
                return BadRequest("xoa thanh cong!");
            }
            return BadRequest("don dang ky id not found");
        }
        [HttpPost("DuyetDon"), Authorize(Roles ="ADMIN")]
        public IActionResult duyetDon(DuyetDon duyetDon)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            var res = donDangKyServices.duyetDon(id, duyetDon);
            return Ok(res);
        }
        private int GetIdFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);

            var IdClaim = token.Claims.FirstOrDefault(c => c.Type == "accountId");
            int Id = int.Parse(IdClaim.Value);
            return Id;
        }
    }
}
