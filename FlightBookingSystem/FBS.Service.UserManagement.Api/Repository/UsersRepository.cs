using FBS.Service.Common;
using FBS.Service.UserManagement.Api.DataContext;
using FBS.Service.UserManagement.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Service.UserManagement.Api.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UsersDbContext _dbContext;
        private readonly IConfiguration _config;
        public UsersRepository(UsersDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }
        public Response<TokenDetails> Authenticate(UserLogin user)
        {
            var userObj = _dbContext.Users.Where(x => x.UserName == user.UserName).SingleOrDefault();
            if (userObj == null)
                return new Response<TokenDetails>(null,StatusCodes.Status404NotFound.ToString(),new[] {"User Name Doesn't Exits"});
            var validatePassword = userObj.Password.Equals(user.Password);
            if (!validatePassword)
                return new Response<TokenDetails>(null, StatusCodes.Status404NotFound.ToString(), new[] { "Password Doesn't Match" });
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
                new Claim(ClaimTypes.Name, user.UserName)
              }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenDetails = new TokenDetails() { Token = tokenHandler.WriteToken(token), UserName = userObj.UserName, IsAdminUser = userObj.IsAdmin };
            return new Response<TokenDetails>(tokenDetails, StatusCodes.Status200OK.ToString(), new[] { "Login Sucess!" });
        }
        public Response<bool> AddUser(UserRegister user)
        {
            try
            {
                if (user != null)
                {
                    _dbContext.Users.Add(user);
                    SaveChanges();
                    return new Response<bool>(true, StatusCodes.Status200OK.ToString(),new[] { "Your registration is successful!" });
                }
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString(), new[] { ex.Message });
            }
            return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString(),new[] {"Your Registration Failed" });
        }
        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
