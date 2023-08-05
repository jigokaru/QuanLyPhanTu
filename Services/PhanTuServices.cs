using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QuanLyPhanTu.Dto;
using QuanLyPhanTu.Iservices;
using QuanLyPhanTu.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace QuanLyPhanTu.Services
{
    public class PhanTuServices : IphatuServices
    {
        private readonly AppDbContext appDbContext;

        public PhanTuServices()
        {
            appDbContext = new AppDbContext();
        }

        [Authorize(Roles ="ADMIN")]
        public IQueryable<PhanTu> LayDsPhatTu(string? ten, 
                                                string? ho, 
                                                int? soDienThoai, 
                                                string? email, 
                                                DateTime? ngayCapNhap, 
                                                DateTime? ngayHoanTuc, 
                                                DateTime? ngayXuatGia, 
                                                DateTime? ngaySinh, 
                                                int? thangSinh = null, 
                                                int? namSinh = null, 
                                                DateTime? ngayCapNhapmin = null, 
                                                DateTime? ngayCapNhapmax = null)
        {
            
            var query = appDbContext.PhanTu.OrderByDescending(x => x.ngayCapNhap).AsQueryable();
            
            if(!string.IsNullOrEmpty(ten))
            {
                query = query.Where(x => x.ten.Contains(ten.ToLower()));
            }
            else
            {
                query = query.OrderBy(x => x.ten);
                
            }
            if (!string.IsNullOrEmpty(ho))
            {
                query = query.Where(x => x.ho.Contains(ho));
            }
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.email.Contains(email.ToLower()));
            }
            if (ngayCapNhap.HasValue)
            {
                query = query.Where(x => x.ngayCapNhap == ngayCapNhap);
            }
            if (ngayHoanTuc.HasValue)
            {
                query = query.Where(x => x.ngayHoanTuc == ngayHoanTuc);
            }
            if (ngayXuatGia.HasValue)
            {
                query = query.Where(x => x.ngayXuatGia == ngayXuatGia);
            }
            if (ngaySinh.HasValue)
            {
                query = query.Where(x => x.ngaySinh == ngaySinh);
            }
            if (thangSinh.HasValue)
            {
                query = query.Where(x => x.ngaySinh.Value.Month == thangSinh);
            }
            if (namSinh.HasValue)
            {
                query = query.Where(x => x.ngaySinh.Value.Year == namSinh);
            }
            if (ngayCapNhapmin.HasValue)
            {
                query = query.Where(x => x.ngayCapNhap >= ngayCapNhapmin);
            }
            if (ngayCapNhapmax.HasValue)
            {
                query = query.Where(x => x.ngayCapNhap <= ngayCapNhapmax);
            }
            return query;
        }

        public PhanTu ThemPhatTu(int? id)
        {
            return appDbContext.PhanTu.FirstOrDefault(x => x.phatTuId == id);
        }

        public PhanTu XoaPhanTu(int? id)
        {
            return appDbContext.PhanTu.FirstOrDefault(x => x.phatTuId == id);
        }
    }
}
