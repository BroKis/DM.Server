using AutoMapper;
using DM.API.ModelsDTO;
using DM.DAL.Models;

namespace DM.API.Infrastructure.ProfilesForMapping;

public class UsersProfile:Profile
{
    public UsersProfile()
    {
        CreateMap<UsersDTO, Users>().ReverseMap();
    }
}