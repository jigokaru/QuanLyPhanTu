using QuanLyPhanTu.Iservices;
using QuanLyPhanTu.Models;
using System.Text.RegularExpressions;

namespace QuanLyPhanTu.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly AppDbContext appDbContext;

        public LoginServices()
        {
            appDbContext = new AppDbContext();
        }

        

        public PhanTu dangNhap(Login login)
        {
            
            var user = appDbContext.PhanTu.FirstOrDefault(x => x.email == login.email);
            if(user != null)
            {
                if(BCrypt.Net.BCrypt.Verify(login.password, user.password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
