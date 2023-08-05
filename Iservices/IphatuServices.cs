using QuanLyPhanTu.Models;
using QuanLyPhanTu.Dto;
namespace QuanLyPhanTu.Iservices
{
    public interface IphatuServices
    {
        PhanTu ThemPhatTu(int? id);
        PhanTu XoaPhanTu(int? id);
        IQueryable<PhanTu> LayDsPhatTu(string? ten,
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
                                       DateTime? ngayCapNhapmax = null);
    }
}
