namespace DarkmoonSession.API.ModelsDTO;

public class SessionsDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Token { get; set; }
    public int UserId { get; set; }
}