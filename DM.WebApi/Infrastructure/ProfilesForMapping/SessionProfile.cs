using AutoMapper;
using DM.API.ModelsDTO;
using DM.DAL.Models;

namespace DM.API.Infrastructure.ProfilesForMapping;

public class SessionProfile:Profile
{
    public SessionProfile()
    {
        CreateMap<SessionsDTO, Sessions>().ReverseMap();
    }
}