using QuanLyPhanTu.Dto;
using QuanLyPhanTu.Models;

namespace QuanLyPhanTu.Iservices
{
    public interface IDaoTrangsServices
    {
        DaoTrangs themDaoTrangs(int? id, DaoTrangsDto daoTrangsDto);
        bool suaDaoTrangs(int? id, DaoTrangsDto daoTrangsDto);
        bool xoaDaoTrangs(int DaoTrangsId);
        IQueryable<DaoTrangs> layDsDaoTrangs(Boolean? daKetThuc, string? noiToChuc, int? thang, int? nam);
    }
}
