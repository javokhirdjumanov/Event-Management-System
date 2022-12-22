using EventSystem.Core.Models;

namespace EventSystem.Core.EventServices;
public partial class EventServices
{
    //:::::::::::::::::::::::::::: SERVICES SECTION :::::::::::::::::::::::::::://

    /// </summary>
    /// Exist Room In Database
    /// </summary>
    public async Task<bool> RoomExistToDbAsync(int room_number)
        => await brokers.RoomExistToDbAsync(room_number);

    /// </summary>
    /// Create Room To Database
    /// </summary>
    public async Task CreateRoomToDbAsync(Rooms room)
        => await brokers.CreateRoomToDbAsync(room);

    /// </summary>
    /// Get Rooms From Database
    /// </summary>
    public async Task<List<Rooms>> ReadRoomFromDb(string room_name)
        => await brokers.ReadRoomFromDb(room_name);

    /// </summary>
    /// Update Rooms From Database
    /// </summary>
    public async Task UpdateRoomDbAsync(int room_id, string room_name, int room_number)
        => await brokers.UpdateRoomDbAsync(room_id, room_name, room_number);

    /// </summary>
    /// Delete Rooms From Database
    /// </summary>
    public async Task DeleteRoomDbAsync(int room_id)
        => await brokers.DeleteRoomDbAsync(room_id);
}
