using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    public class PhatTuController : ControllerBase
    {
        private readonly IphatuServices phatuServices;
        private readonly AppDbContext appDbContext;
        public PhatTuController()
        {
            phatuServices = new PhanTuServices();
            appDbContext = new AppDbContext();
        }
        [HttpPost("ThemPhatTu")]
        public async Task<IActionResult> ThemPhatTu([FromForm]PhatTuDto phatTuDto, [FromForm] ImageModels? files)
        {
            var jwt = Request.Cookies["token"];
            var id = GetIdFromToken(jwt);
            var res = phatuServices.ThemPhatTu(id); 
            if(res != null)
            {
                res.ho = phatTuDto.ho;
                res.ten = phatTuDto.ten;
                res.tenDem = phatTuDto.tenDem;
                res.ngayHoanTuc = phatTuDto.ngayHoanTuc;
                res.ngaySinh = phatTuDto.ngaySinh;
                res.ngayXuatGia = phatTuDto.ngayXuatGia;
                res.phapDanh = phatTuDto.phapDanh;
                res.soDienThoai = phatTuDto.soDienThoai;
                res.gioiTinh = phatTuDto.gioiTinh;
                res.daHoanTuc = phatTuDto.daHoanTuc;
                res.ngayCapNhap = DateTime.Now;
                //string wwwRootPath = _webHostEnvironment.WebRootPath;
                //if (files.file != null)
                //{
                //    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(files.file.FileName);
                //    string filePath = Path.Combine(wwwRootPath, @"images\phattu");
                //    using (var fileSteam = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                //    {
                //        files.file.CopyTo(fileSteam);
                //    }
                //    phanTu.anhChup = @"\images\phattu\" + fileName;
                //}
                if(files.file != null)
                {
                    string link = await uplloadFile.UploadFile(files.file);
                    res.anhChup = link;
                }
                appDbContext.PhanTu.Update(res);
                appDbContext.SaveChanges();
                return Ok(res);
            }
            else
            {
                return BadRequest("email khong trung khop!");
            }
        }
        [HttpPost("XoaPhatTu"), Authorize(Roles ="ADMIN")]
        public IActionResult XoaPhatTu(int? id)
        {
            var res = phatuServices.XoaPhanTu(id);
            if (res != null)
            {

                res.isActive = false;
                appDbContext.PhanTu.Update(res) ;
                appDbContext.SaveChanges();
                return BadRequest("xoa thong tin phat tu thanh cong!");
            }
            else
            {
                return BadRequest("email khong trung khop!");
            }
        }
        [HttpGet("LayDsPhatTu"), Authorize(Roles = "ADMIN")]
        public IActionResult LayDsPhatTu(       string? ten,
                                                string? ho,
                                                int? soDienThoai,
                                                string? email,
                                                DateTime? ngayCapNhap,
                                                DateTime? ngayHoanTuc,
                                                DateTime? ngayXuatGia,
                                                DateTime? ngaySinh,
                                                int pageNumber = 1,
                                                int pageSize = 10,
                                                int? thangSinh = null,
                                                int? namSinh = null,
                                                DateTime? ngayCapNhapmin = null,
                                                DateTime? ngayCapNhapmax = null )
        {
            var res = phatuServices.LayDsPhatTu(ten, ho, soDienThoai, email, ngayCapNhap, ngayHoanTuc, ngayXuatGia, ngaySinh, thangSinh, namSinh, ngayCapNhapmin, ngayCapNhapmax);
            var phattus = PageResult<PhanTu>.ToPageResult(res, pageNumber, pageSize);

            return Ok(phattus);
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
