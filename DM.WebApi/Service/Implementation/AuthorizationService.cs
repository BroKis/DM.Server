using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using DM.API.Infrastructure.JWTConfiguration;
using DM.API.ModelsDTO;
using DM.API.Service.Interfaces;
using DM.DAL.Models;
using DM.DAL.Repository.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace DM.API.Service.Implementation;

public class AuthorizationService : IAuthorizationService
{
    private IMapper _mapper;
    private ISessionRepository _sessionRepository;
    private IUsersRepository _usersRepository;
    private IMemoryCache _cache;

    public AuthorizationService(IMapper mapper, ISessionRepository sessionRepository, IUsersRepository usersRepository,
        IMemoryCache memoryCache)
    {
        _mapper = mapper;
        _sessionRepository = sessionRepository;
        _usersRepository = usersRepository;
        _cache = memoryCache;
    }
    public async Task<object> SessionCreate(UsersDTO users)
    {
        var encoded_jwt = Token(users.Name);
        SessionsDTO session = new SessionsDTO()
        {
            Name = users.Name,
            UserId = users.Id,
            Token = encoded_jwt
        };
        _cache.Set(session.Token, session,
            new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(60)));
        Sessions mapped = _mapper.Map<Sessions>(session);
        await _sessionRepository.Create(mapped);
        return new
        {
            Name = session.Name, Token = session.Token
        };


    }

    public async Task<UsersDTO> UsersGetByAuth(AuthModel auth)
    {
        _cache.TryGetValue(auth.Login + " " + auth.Password, out UsersDTO? user);
        if (user == null)
        {
            Users users = await _usersRepository.UserByLoginAndPassword(auth.Login, auth.Password);
            
            user = _mapper.Map<UsersDTO>(users);
            _cache.Set(user.Id, user,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
        }

        return user;
    }

    public async Task<object> UsersGetByToken(string token)
    {
        
        _cache.TryGetValue(token, out SessionsDTO? sessionsDto);
        if (sessionsDto == null)
        {
            Sessions sessions = await _sessionRepository.GetByToken(token);
            sessionsDto = _mapper.Map<SessionsDTO>(sessions);
        }

        _cache.TryGetValue(sessionsDto.UserId, out UsersDTO? user);
        if (user == null)
        {
            Users users = await _usersRepository.GetById(sessionsDto.Id);
            user = _mapper.Map<UsersDTO>(users);
        }

        return new
        {
           
            Name = user.Name,
            Role = user.Role
           
        };
    }

    private string Token(string name)
    {
        var claims = new List<Claim> {new Claim(ClaimTypes.Name, name) };
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
    
}