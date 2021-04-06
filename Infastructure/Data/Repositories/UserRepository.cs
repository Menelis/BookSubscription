using AutoMapper;
using Core.Dto;
using Core.Dto.GatewayResponses.Repositories;
using Core.Entities;
using Core.Interfaces.Gateways.Repositories;
using Infastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<AppUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<bool> CheckPasswordAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user != null && await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<CreateUserResponse> CreateAsync(User user, string password)
        {
            var appUser = _mapper.Map<AppUser>(user);
            var identityResult = await _userManager.CreateAsync(appUser, password);
            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, Common.RoleConstants.Visitor);
            }
            return new CreateUserResponse(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(_ => new Error(_.Code, _.Description)));
        }

        public Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByIdAsync(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null) return null;

            return _mapper.Map<User>(appUser);
        }

        public async Task<User> FindByNameAsync(string username)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null) return null;
            return _mapper.Map<User>(appUser);
        }
    }
}
