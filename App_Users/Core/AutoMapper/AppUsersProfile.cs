using App.Users.Commons.Dto;
using App.Users.Data.Entities;
using AutoMapper;

namespace App_Users.Core.AutoMapper
{
    public class AppUsersProfile : Profile
    {
        public AppUsersProfile() 
        { 
            CreateMap<Usuario, UsuariosDto>().ReverseMap();
        }
    }
}
