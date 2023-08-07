using AutoMapper;
using DarkmoomSession.DAL.Models;
using DarkmoonSession.API.ModelsDTO;

namespace DarkmoonSession.API.Infrastructure.ProfilesForMapping;

public class UsersProfile:Profile
{
    public UsersProfile()
    {
        CreateMap<UsersDTO, Users>().ReverseMap();
    }
}