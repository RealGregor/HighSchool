using LMA.Data.Contracts;
using LMA.Data.Contracts.Readers;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LMA.Data.UI.ViewModels.ViewModels;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using LMA.Services.Contracts;

namespace LMA.Services
{
    public class LoginService : ILoginService

    {
        private readonly IUserReader<UserModel> _authService;
        private readonly IMapper _mapper;

        public LoginService(IUserReader<UserModel> authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        //Check if email with this password exists and return AuthenticationResponseViewModel with specific message
        public async Task<ReturnViewModel> Authenticate(string username, string password) {
            ReturnViewModel result = new ReturnViewModel();

            //Get user with given username(Email)
            UserModel user = await _authService.GetUser(username);
            //Create empty AuthenticationResponseViewModel
            AuthenticationResponseViewModel res = new AuthenticationResponseViewModel();

            //if user exist
            if (user != null) {
                //if email and password are correct then return token and user
                if (user.Email.Equals(username) && user.Password.Equals(password)) {
                    if (true/*user.EmailConfirmed != false*/) {
                        res.Token = GetToken(user);
                        res.User = _mapper.Map<UserModel, UserViewModel>(user);
                        result.Result.Object = res;
                        result.Result.Messages.Add(new MessageViewModel(3));
                        return result;
                    } else {
                        result.Ok = false;
                        result.Result.Messages.Add(new MessageViewModel(12));
                        return result;
                    }
                }
                //if email and password are not correct then return error message
                else {
                    result.Ok = false;
                    result.Result.Messages.Add(new MessageViewModel(13));
                    return result;
                }
            }
            //if user does not exist then return error
            else {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(14));
                return result;
            }
        }

        //Returns JSON Web Token
        public string GetToken(UserModel user)
        {
            var claimsData = new[] { new Claim(ClaimTypes.Email, user.Email), new Claim(ClaimTypes.Role, user.Role), new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("akjsdfkjahskdjhfjkahskjhfkhmwveocnogweniotrnmxqweuhtcincmgqicg"));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer: "http://localhost:5000/",
                audience: "mysite.com",
                expires: DateTime.Now.AddDays(1),
                claims: claimsData,
                signingCredentials: signInCred
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
