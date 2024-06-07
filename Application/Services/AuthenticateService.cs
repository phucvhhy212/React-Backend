using Application.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Application.Dtos.RequestModel.Authenticate;
using Application.Dtos.ResponseModel;


namespace Application.Services
{
    public class AuthenticateService:IAuthenticateService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AuthenticateService(UserManager<User> userManager, IConfiguration configuration, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        public async Task<BaseResponse<string>> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new BaseResponse<string>
                {
                    StatusCode = 400,
                    Message = "User not exist"
                };
            }

            if (await _userManager.CheckPasswordAsync(user,request.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("email", user.Email),
                    new Claim("userName",user.UserName),
                    new Claim("role",_userManager.GetRolesAsync(user).Result.First())
                };
                var token = GetToken(authClaims);
                return new BaseResponse<string>
                {
                    StatusCode = 200,
                    Body = new JwtSecurityTokenHandler().WriteToken(token),
                    Message = "Login successfully"
                };
            }
            return new BaseResponse<string>
            {
                StatusCode = 400,
                Message = "Login failed"
            };
        }

        public async Task<BaseResponse<string>> Register(RegisterRequest request)
        {
            var newUser = new User
            {
                UserName = request.UserName,
                Email = request.Email,
            };
            var result = await _userManager.CreateAsync(newUser, request.Password);
            await _userManager.AddToRoleAsync(newUser, "User");
            return result.Succeeded
                ? new BaseResponse<string>
                {
                    StatusCode = 200,
                    Message = "Register successfully"
                }
                : new BaseResponse<string>
                {
                    StatusCode = 400,
                    Message = "Register failed"
                };

        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(int.Parse(_configuration["JWT:ExpiredHour"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return token;

        }
    }
}
