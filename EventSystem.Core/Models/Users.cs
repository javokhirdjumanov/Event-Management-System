namespace EventSystem.Core.Models;

public class Users
{
    public Users(string name, string username,
        string password, int role)
    {
        Name = name;
        Username = username;
        Password = password;
        Role = role;
    }
    public Users(int id, string name, string username,
        string password, int role, Orders order, Events @event)
    {
        Id = id;
        Name = name;
        Username = username;
        Password = password;
        Role = role;
        Order = order;
        Event = @event;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Role { get; set; }
    public Orders Order { get; set; }
    public Events Event { get; set; }
}

