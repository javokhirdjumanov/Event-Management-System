namespace EventSystem.Core.Models;
public class Orders
{
    public Orders(Rooms room, Users user, int user_id)
    {
        Room = room;
        User = user;
        User_id = user_id;
    }
    public Orders(int id, Rooms room, Users user, int user_id)
    {
        Id = id;
        Room = room;
        User = user;
        User_id = user_id;
    }
    public int Id { get; set; }
    public Rooms Room { get; set; }
    public Users User { get; set; }
    public int User_id { get; set; }
}
