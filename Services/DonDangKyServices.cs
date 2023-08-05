using QuanLyPhanTu.Dto;
using QuanLyPhanTu.Iservices;
using QuanLyPhanTu.Models;

namespace QuanLyPhanTu.Services
{
    public class DonDangKyServices : IDonDangKyServices
    {
        private readonly AppDbContext appDbContext;

        public DonDangKyServices()
        {
            appDbContext = new AppDbContext();
        }

        public DonDangKys duyetDon(int? PhatTuId, DuyetDon duyetDon)
        {
            DonDangKys donDangKys = appDbContext.DonDangKys.FirstOrDefault(x => x.donDangkyId == duyetDon.donDangkyId);
            var daoTrangs = appDbContext.DaoTrangs.FirstOrDefault(x => x.daoTrangId == donDangKys.daoTrangId);
            if (donDangKys != null )
            {
                donDangKys.ngayXuLy = DateTime.UtcNow;
                donDangKys.phatTuId = PhatTuId;
                donDangKys.trangThaiDon = duyetDon.trangThaiDon;
            }
            appDbContext.DonDangKys.Update(donDangKys);
            appDbContext.SaveChanges();
            if(donDangKys.trangThaiDon == true)
            {
                daoTrangs.soThanhVienThamGia += 1;
                
            }
            else
            {
                daoTrangs.soThanhVienThamGia -= 1;
            }
            appDbContext.DaoTrangs.Update(daoTrangs);
            appDbContext.SaveChanges();
            return donDangKys;
        }


        public DonDangKys themDonDangKys(int? PhatTuId, DonDangKysDto donDangKysDto)
        {
            var donDangKy = new DonDangKys
            {
                phatTuId = PhatTuId,
                daoTrangId = donDangKysDto.daoTrangId,
                ngayGuiDon = DateTime.UtcNow
            };
            appDbContext.DonDangKys.Add(donDangKy);
            appDbContext.SaveChanges();
            return donDangKy;
        }


        public bool xoaDonDangKys(int donDangKyId)
        {
           DonDangKys donDangKysDelete = appDbContext.DonDangKys.FirstOrDefault(x => x.donDangkyId == donDangKyId);
            DaoTrangs daoTrangs = appDbContext.DaoTrangs.FirstOrDefault(x => x.daoTrangId == donDangKysDelete.daoTrangId);
            if (donDangKysDelete != null)
            {
                appDbContext.DonDangKys.Remove(donDangKysDelete);
                appDbContext.SaveChanges();
                daoTrangs.soThanhVienThamGia -= 1;
                appDbContext.DaoTrangs.Update(daoTrangs);
                appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
