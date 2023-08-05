using QuanLyPhanTu.Iservices;
using QuanLyPhanTu.Models;

namespace QuanLyPhanTu.Services
{
    public class ChuasServices : IChuasServices
    {
        private readonly AppDbContext appDbContext;

        public ChuasServices()
        {
            appDbContext = new AppDbContext();
        }

        public bool suaChuas(Chuas chuas)
        {
            Chuas chuasUpdate = appDbContext.Chuas.FirstOrDefault(x => x.chuaId == chuas.chuaId);
            if (chuasUpdate != null)
            {
                chuasUpdate.diaChi = chuas.diaChi;
                chuasUpdate.capNhap = DateTime.Now;
                chuasUpdate.ngayThanhLap = chuas.ngayThanhLap;
                chuasUpdate.tenChua = chuas.tenChua;
                appDbContext.Chuas.Update(chuasUpdate);
                appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Chuas themChuas(Chuas chuas)
        {
            appDbContext.Chuas.Add(chuas);
            appDbContext.SaveChanges();
            return chuas;
        }

        public bool xoaChuas(Chuas chuas)
        {
            Chuas chuasDelete = appDbContext.Chuas.FirstOrDefault(x => x.chuaId == chuas.chuaId);
            if (chuasDelete != null)
            {
                appDbContext.Chuas.Remove(chuasDelete);
                appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public IQueryable<Chuas> layDsChua(string tenchua, string diachi)
        {
            var query = appDbContext.Chuas.AsQueryable();
            if (!string.IsNullOrEmpty(tenchua))
            {
                query = query.Where(x => x.tenChua.Contains(tenchua));
            }
            if(!string.IsNullOrEmpty(diachi))
            {
                query = query.Where(x => x.diaChi.Contains(diachi));
            }
            return query;
        }

    }
}
