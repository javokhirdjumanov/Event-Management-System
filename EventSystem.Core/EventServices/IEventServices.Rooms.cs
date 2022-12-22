using EventSystem.Core.Models;

namespace EventSystem.Core.EventServices;
public partial interface IEventServices
{
    public Task<bool> RoomExistToDbAsync(int room_number);
    public Task CreateRoomToDbAsync(Rooms room);
    public Task<List<Rooms>> ReadRoomFromDb(string room_name);
    public Task UpdateRoomDbAsync(int room_id, string room_name, int room_number);
    public Task DeleteRoomDbAsync(int room_id);
}
