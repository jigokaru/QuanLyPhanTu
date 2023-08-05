using QuanLyPhanTu.Dto;
using QuanLyPhanTu.Iservices;
using QuanLyPhanTu.Models;

namespace QuanLyPhanTu.Services
{
    public class DaoTrangsServices : IDaoTrangsServices
    {
        private readonly AppDbContext appDbContext;

        public DaoTrangsServices()
        {
            appDbContext = new AppDbContext();
        }

        public IQueryable<DaoTrangs> layDsDaoTrangs(bool? daKetThuc, string? noiToChuc, int? thang, int? nam)
        {
            var query = appDbContext.DaoTrangs.AsQueryable();
            if(daKetThuc.HasValue)
            {
                query = query.Where(x => x.daKetThuc == daKetThuc);
            }
            if (!string.IsNullOrEmpty(noiToChuc))
            {
                query = query.Where(x => x.noiToChuc.Contains(noiToChuc));
            }
            if (thang.HasValue)
            {
                query = query.Where(x => x.thoiGianToChuc.Value.Month == thang);
            }
            if(nam.HasValue)
            {
                query = query.Where(x => x.thoiGianToChuc.Value.Year == nam);
            }
            return query;
        }

        public bool suaDaoTrangs(int? id, DaoTrangsDto daoTrangsDto)
        {
            DaoTrangs daoTrangsUpdate = appDbContext.DaoTrangs.FirstOrDefault(x => x.daoTrangId == id);
            if (daoTrangsUpdate != null)
            {
                daoTrangsUpdate.daKetThuc = daoTrangsDto.daKetThuc;
                daoTrangsUpdate.thoiGianToChuc = daoTrangsDto.thoiGianToChuc;
                daoTrangsUpdate.noiDung = daoTrangsDto.noiDung;
                daoTrangsUpdate.noiToChuc = daoTrangsDto.noiToChuc;
                appDbContext.DaoTrangs.Update(daoTrangsUpdate);
                appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public DaoTrangs themDaoTrangs(int? id, DaoTrangsDto daoTrangsDto)
        {
            PhanTu phanTu = appDbContext.PhanTu.FirstOrDefault(x => x.phatTuId == id);
            if(phanTu != null)
            {
                DaoTrangs daoTrangs = new DaoTrangs();
                daoTrangs.daKetThuc = daoTrangsDto.daKetThuc;
                daoTrangs.phatTuId = id;
                daoTrangs.noiDung = daoTrangsDto.noiDung;
                daoTrangs.noiToChuc = daoTrangsDto.noiToChuc;
                daoTrangs.thoiGianToChuc = daoTrangsDto.thoiGianToChuc;
                appDbContext.DaoTrangs.Add(daoTrangs);
                appDbContext.SaveChanges();
                return daoTrangs;
            }
            
            return null;
        }

        public bool xoaDaoTrangs(int DaoTrangsId)
        {
            DaoTrangs daoTrangsDelete = appDbContext.DaoTrangs.FirstOrDefault(x => x.daoTrangId == DaoTrangsId);
            if (daoTrangsDelete != null)
            {
                appDbContext.DaoTrangs.Remove(daoTrangsDelete);
                appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        

        
    }
}
