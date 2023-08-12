namespace DM.DAL.Models;
/// <summary>
/// Users entity
/// </summary>
public class Users
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Role { get; set; }
    public string Password { get; set; }
    
   
}