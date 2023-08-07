using AutoMapper;
using DarkmoomSession.DAL.Models;
using DarkmoonSession.API.ModelsDTO;

namespace DarkmoonSession.API.Infrastructure.ProfilesForMapping;

public class SessionProfile:Profile
{
    public SessionProfile()
    {
        CreateMap<SessionsDTO, Sessions>().ReverseMap();
    }
}