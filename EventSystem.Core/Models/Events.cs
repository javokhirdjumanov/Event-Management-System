namespace EventSystem.Core.Models;
public class Events
{
    public Events(int id, string eventName, Rooms room,
        Users user, DateTime date)
    {
        Id = id;
        EventName = eventName;
        Room = room;
        User = user;
        Date = date;
    }
    public Events(string eventName, Rooms room,
        Users user, DateTime date, int user_id)
    {
        EventName = eventName;
        Room = room;
        User = user;
        Date = date;
        User_id = user_id;
    }
    public int Id { get; set; }
    public string EventName { get; set; }
    public Rooms Room { get; set; }
    public Users User { get; set; }
    public DateTime Date { get; set; }
    public int User_id { get; set; }

    public override string ToString()
    {
        return
            $"{Id}".PadRight(10) +
            $"{EventName}".PadRight(20) +
            $"{Room}".PadRight(10) +
            $"{Date}".PadRight(20) + 
            $"{User}".PadRight(10);
    }
}
