using AutoMapper;
using DarkmoomSession.DAL.Models;
using DarkmoomSession.DAL.Repository.Interfaces;
using DarkmoonSession.API.Infrastructure.JWTConfiguration;
using DarkmoonSession.API.Infrastructure.Respounce;
using DarkmoonSession.API.ModelsDTO;
using Microsoft.Extensions.Caching.Memory;

namespace DarkmoonSession.API.Service.Implementation;

public class AutorizationService : IAutorizationService
{
    private IMapper _mapper;
    private ISessionRepository _sessionRepository;
    private IUsersRepository _usersRepository;
    private IMemoryCache _cache;

    public AutorizationService(IMapper mapper, ISessionRepository sessionRepository, IUsersRepository usersRepository,
        IMemoryCache memoryCache)
    {
        _mapper = mapper;
        _sessionRepository = sessionRepository;
        _usersRepository = usersRepository;
        _cache = memoryCache;
    }

    public async Task<Responce<object>> SessionCreate(UsersDTO users)
    {
        var session = new SessionsDTO()
        {
            Name = users.Name,
            UserId = users.Id,
            Token = TokenCreater.Token(users.Name)
        };
        
        _cache.Set(session.Token, session,
            new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(60)));
        var mapped = _mapper.Map<Sessions>(session);
        await _sessionRepository.Create(mapped);
        return new Responce<object>()
        {
            Data = new { Name = session.Name, Token = session.Token }
        };

    }

    public async Task<UsersDTO> UsersGetByAuth(AuthModel auth)
    {
        _cache.TryGetValue(auth.Login + " " + auth.Password, out UsersDTO? user);
        if (user == null)
        {
            var users = await _usersRepository.UserByLoginAndPassword(auth.Login, auth.Password);
            
            user = _mapper.Map<UsersDTO>(users);
            _cache.Set(user.Id, user,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
        }

        return user;
    }

    public async Task<Responce<object>> UsersGetByToken(string token)
    {
        
        _cache.TryGetValue(token, out SessionsDTO? sessionsDto);
        if (sessionsDto == null)
        {
            var sessions = await _sessionRepository.GetByToken(token);
            sessionsDto = _mapper.Map<SessionsDTO>(sessions);
        }

        _cache.TryGetValue(sessionsDto.UserId, out UsersDTO? user);
        if (user == null)
        {
            var users = await _usersRepository.GetById(sessionsDto.Id);
            user = _mapper.Map<UsersDTO>(users);
        }

        return new Responce<object>()
        {
            Data = new
            {
                Name = user.Name,
                Role = user.Role
            }
        };
    }
}
   