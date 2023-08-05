using QuanLyPhanTu.Models;

namespace QuanLyPhanTu.Iservices
{
    public interface IChangePasswordServices
    {
        bool DoiMatKhau(string email, ChangePassword changePassword);
    }
}
