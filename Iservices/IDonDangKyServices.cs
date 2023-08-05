using QuanLyPhanTu.Dto;
using QuanLyPhanTu.Models;

namespace QuanLyPhanTu.Iservices
{
    public interface IDonDangKyServices
    {
        DonDangKys  themDonDangKys(int? PhatTuId, DonDangKysDto donDangKysDto);
        DonDangKys duyetDon(int? PhatTuId, DuyetDon duyetDon);
        bool xoaDonDangKys(int donDangKyId);
    }
}
