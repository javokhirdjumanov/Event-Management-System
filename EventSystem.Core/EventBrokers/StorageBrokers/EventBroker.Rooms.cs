using EventSystem.Core.EventBrokers.Data;
using EventSystem.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EventSystem.Core.EventBrokers.StorageBrokers;
public partial class EventBroker
{
    //:::::::::::::::::::::::::::: BROKER SECTION :::::::::::::::::::::::::::://

    /// </summary>
    /// Exist Rooms In Database
    /// </summary>
    public async Task<bool> RoomExistToDbAsync(int room_number)
    {
        bool exist_room = await Context().Rooms
            .AnyAsync(room => room.RoomNumber == room_number);

        return exist_room;
    }

    /// </summary>
    /// Create Rooms To Database
    /// </summary>
    public async Task CreateRoomToDbAsync(Rooms room)
    {
        await Context().Rooms.AddAsync(room);

        await Context().SaveChangesAsync();
    }

    /// </summary>
    /// Read Rooms From Database
    /// </summary>
    public async Task<List<Rooms>> ReadRoomFromDb(string room_name)
    {
        var rooms = await Context().Rooms
            .Where(room => room.RoomName == room_name).ToListAsync();

        return rooms;
    }

    /// </summary>
    /// Update Rooms From Database
    /// </summary>
    public async Task UpdateRoomDbAsync(int room_id, string room_name, int room_number)
    {
        Rooms room = await Context().Rooms.FindAsync(room_id);

        if (room is null)
            throw new ArgumentNullException(nameof(room));

        room.RoomName = room_name;
        room.RoomNumber = room_number;

        await Context().SaveChangesAsync();
    }

    /// </summary>
    /// Delete Rooms From Database
    /// </summary>
    public async Task DeleteRoomDbAsync(int room_id)
    {
        Rooms room = await Context().Rooms.FindAsync(room_id);

        if (room is null)
            throw new ArgumentNullException();

        Context().Rooms.Remove(room);
        await Context().SaveChangesAsync();
    }
}
