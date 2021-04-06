using AutoMapper;
using Core.Entities;
using Infastructure.Data.Entities;

namespace Infastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.LastName,
                Email = u.Email,
                PasswordHash = u.PasswordHash
            });


            CreateMap<AppUser, User>().ConvertUsing(au => new User(au.FirstName, au.LastName, au.Email, au.UserName, au.PasswordHash, au.Id));
        }
    }
}
