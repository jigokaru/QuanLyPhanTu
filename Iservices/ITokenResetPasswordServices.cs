using QuanLyPhanTu.Models;

namespace QuanLyPhanTu.Iservices
{
    public interface ITokenResetPasswordServices
    {
        TokenResetPassword ThemToken(TokenResetPassword tokenResetPassword);
    }
}
