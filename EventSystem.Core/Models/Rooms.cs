using Microsoft.Extensions.Logging;

namespace EventSystem.Core.Models;
public class Rooms
{

    public Rooms(int id, string roomName, int roomNumber,
            ICollection<Orders> orders, ICollection<Events> events)
    {
        Id = id;
        RoomName = roomName;
        RoomNumber = roomNumber;
        Orders = orders;
        Events = events;
    }
    public Rooms(string roomName, int roomNumber)
    {
        RoomName = roomName;
        RoomNumber = roomNumber;
    }
    public int Id { get; set; }
    public string RoomName { get; set; }
    public int RoomNumber { get; set; }
    public ICollection<Orders> Orders { get; set; }
    public ICollection<Events> Events { get; set; }

    public override string ToString()
    {
        return 
            $"{Id}".PadRight(10) + $"{RoomName}".PadRight(20) + $"{RoomNumber}".PadRight(10);
    }
}
