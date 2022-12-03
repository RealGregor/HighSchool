using AutoMapper;
using LMA.Data.Contracts.Readers;
using LMA.Data.Contracts.Writers;
using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Services.Contracts;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Services
{
	public class AdminService : IAdminService
	{
        private readonly IAdminReader<AdminModel> _adminReadService;
        private readonly IWriter<AdminModel> _adminWriteService;
        private readonly IMapper _mapper;

        public AdminService(IAdminReader<AdminModel> adminReadService,IWriter<AdminModel> adminWriteService, IMapper mapper) {
            _adminReadService = adminReadService;
            _adminWriteService = adminWriteService;
            _mapper = mapper;
        }

        //Check if email with this password exists and return AuthenticationResponseViewModel with specific message
        public async Task<ReturnViewModel> Authenticate(string username, string password) {
            ReturnViewModel result = new ReturnViewModel();

            //Get user with given username(Email)
            AdminModel admin = await _adminReadService.GetAdmin(username);
            //Create empty AuthenticationResponseViewModel
            AdminAuthenticationResponseViewModel res = new AdminAuthenticationResponseViewModel();

            //if user exist
            if (admin != null) {
                //if email and password are correct then return token and user
                if (admin.Username.Equals(username) && admin.Password.Equals(password)) {
                    if (true/*user.EmailConfirmed != false*/) {
                        res.Token = GetToken(admin);
                        res.Admin = _mapper.Map<AdminModel, AdminViewModel>(admin);
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
        public string GetToken(AdminModel admin) {
            var claimsData = new[] { new Claim(ClaimTypes.Email, admin.Username), new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()) };
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