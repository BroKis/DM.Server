﻿namespace DarkmoomSession.DAL.Models;

public class Sessions
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Token { get; set; }
    public int UserId { get; set; }
}