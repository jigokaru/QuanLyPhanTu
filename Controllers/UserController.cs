using asp.net_core_6_jwt_authentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using QuanLyPhanTu.Iservices;
using QuanLyPhanTu.Models;
using QuanLyPhanTu.Services;
using sendEmail.Iservices;
using sendEmail.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLyPhanTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginServices loginServices;
        private readonly IRegisterSevices registerSevices;
        private readonly IEmailServices _emailServices;
        private readonly IConfiguration _configuration;
        private readonly IResetPasswordServices resetPasswordServices;
        private readonly IChangePasswordServices changePasswordServices;
        private readonly ITokenResetPasswordServices tokenResetPasswordServices;
        private readonly AppDbContext appDbContext;

        public UserController(IConfiguration configuration, IEmailServices emailServices)
        {
            loginServices = new LoginServices();
            registerSevices = new RegisterServices();
            _emailServices = emailServices;
            resetPasswordServices = new ResetPasswordServices();
            changePasswordServices = new ChangePasswordServices();
            tokenResetPasswordServices = new TokenResetPasswordServices();
            _configuration = configuration;
            appDbContext = new AppDbContext();
        }

        public static bool IsValidEmail(string email)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
        [AllowAnonymous]
        [HttpPost("DangKy")]
        public IActionResult DangKy(Register register)
        {
            //string password
            //    = BCrypt.Net.BCrypt.HashPassword(register.passwordHash);
            //register.passwordHash = password;
            //string repassword
            //    = BCrypt.Net.BCrypt.HashPassword(register.repasswordHash);
            //register.repasswordHash = repassword;
            var res = registerSevices.dangKy(register);
            
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpPost("DangNhap")]
        public IActionResult DangNhap(Login login)
        {
            var loginRespose = new LoginResponse();
            var UsernamePasswordValid = loginServices.dangNhap(login);
            var Tokens = new Token();
            
            if (UsernamePasswordValid != null)
            {
                string token = CreateToken(UsernamePasswordValid);
                loginRespose.Token = token;
                loginRespose.responseMsg = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                };
                appDbContext.PhanTu.Update(UsernamePasswordValid);
                Tokens.stoken = loginRespose.Token;
                Tokens.expiresAt = DateTime.Now.AddHours(1);
                Tokens.phatTuId = UsernamePasswordValid.phatTuId;
                Response.Cookies.Append("token", token, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddHours(1)
                });
                appDbContext.Token.Add(Tokens);
                appDbContext.SaveChanges();
                return Ok(new { loginRespose });
            }
            else
            {
                // if username/password are not valid send unauthorized status code in response               
                return BadRequest("Username or Password Invalid!");
            }
            
        }

        [Authorize(policy: "ADMINANDMEMBER")]
        [HttpPost("DoiMatKhau")]
        public IActionResult DoiMatKhau(ChangePassword changePassword)
        {
            var jwt = Request.Cookies["token"];
            var email = GetEmailFromToken(jwt);
            var user = appDbContext.PhanTu.FirstOrDefault(x => x.email == email && x.password == changePassword.oldPasswordHash);
            bool isSuccess = changePasswordServices.DoiMatKhau(email, changePassword);
            if(isSuccess)
            {
                string password =
                BCrypt.Net.BCrypt.HashPassword(changePassword.passwordHash);
                changePassword.passwordHash = password;
                string repassword =
                    BCrypt.Net.BCrypt.HashPassword(changePassword.repasswordHash);
                changePassword.repasswordHash = repassword;
                return Ok();

            }
            else
            {
                return BadRequest("Đổi mật khẩu không thành công");
            }
            
        }
        private string GetEmailFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);

            var emailClaim = token.Claims.FirstOrDefault(c => c.Type == "username");
            if (emailClaim != null)
            {
                string email = emailClaim.Value;
                return email;
            }

            return null;
        }

        private bool IsValidUser(string username)
        {
            PhanTu phanTu = appDbContext.PhanTu.FirstOrDefault(x => x.email == username);
            if(phanTu == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost("QuenMatKhau")]
        public  IActionResult QuenMatKhau(string email)
        {
            
            var user = appDbContext.TokenResetPassword.FirstOrDefault(x => x.emailToken == email);
            
            if (user == null)
            {
                return BadRequest("user not found.");
            }
            else
            {
                user.PasswordResetToken = CreateRandomCode();
                user.ResetTokenExpires = DateTime.Now.AddHours(1);
                appDbContext.TokenResetPassword.Update(user);
                appDbContext.SaveChanges();
                var sendEmail = _emailServices.sendEmail(email);
            }
            return Ok();

        }


        [HttpPost("DatLaiMatKhau")]
        public IActionResult DatLaiMatKhau(ResetPassword resetPassword)
        {
            var res = resetPasswordServices.DatLaiMatKhau(resetPassword);
            string password =
                BCrypt.Net.BCrypt.HashPassword(resetPassword.passwordHash);
            resetPassword.passwordHash = password;
            string repassword =
                BCrypt.Net.BCrypt.HashPassword(resetPassword.repasswordHash);
            resetPassword.repasswordHash = repassword;
            return Ok(res);

        }


        private string CreateToken(PhanTu phanTu)
        {
            List<Claim> claims = new()
            {
                new Claim("username", Convert.ToString(phanTu.email)),
                new Claim("accountId", Convert.ToString(phanTu.phatTuId)),
                new Claim("role", Convert.ToString(phanTu.Role)),
                new Claim(ClaimTypes.Role, phanTu.Role)
            };
            //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //var authProperties = new AuthenticationProperties();

            //HttpContext.SignInAsync(
            //    CookieAuthenticationDefaults.AuthenticationScheme,
            //    new ClaimsPrincipal(claimsIdentity),
            //    authProperties).Wait();

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: cred,
                expires: DateTime.Now.AddHours(1));
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
            //var Token = new JwtSecurityTokenHandler();
            //var SecretKeyBytes = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
            //var tokenDescription = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[]
            //    {
            //        new Claim("username", Convert.ToString(phanTu.email)),
            //        new Claim(ClaimTypes.Role, phanTu.Role)
            //    }),
            //    Expires = DateTime.UtcNow.AddMinutes(1),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            //};
            //var TokenHandler = Token.CreateToken(tokenDescription);
            //return Token.WriteToken(TokenHandler);
        }
        private string CreateRandomCode()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(3));
        }
        private int CreatRandomInt()
        {
            return Convert.ToInt32(RandomNumberGenerator.GetInt32(2));
        }
    }
}
