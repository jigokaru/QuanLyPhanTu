using QuanLyPhanTu.Models;

namespace QuanLyPhanTu.Iservices
{
    public interface IChuasServices
    {
        Chuas themChuas(Chuas chuas);
        bool suaChuas(Chuas chuas);
        bool xoaChuas(Chuas chuas);
        IQueryable<Chuas> layDsChua(string tenchua, string diachi);
    }
}
