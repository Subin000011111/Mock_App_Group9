using RoomBookingApi.Models;

namespace RoomBookingApi.Services;

public class RoomAvailabilityService
{
    private readonly List<Room> _rooms =
    [
        new Room { Id = 1, Name = "Room 101", Location = "Block A", Capacity = 30, Equipment = "Projector, Whiteboard", IsAvailable = true },
        new Room { Id = 2, Name = "Room 102", Location = "Block A", Capacity = 20, Equipment = "Whiteboard", IsAvailable = true },
        new Room { Id = 3, Name = "Room 201", Location = "Science Building", Capacity = 25, Equipment = "Projector", IsAvailable = false },
        new Room { Id = 4, Name = "Room 301", Location = "Engineering Block", Capacity = 40, Equipment = "Smart Board", IsAvailable = true }
    ];

    public List<Room> GetAllRooms()
    {
        return _rooms;
    }

    public List<Room> GetAvailableRooms()
    {
        return _rooms.Where(r => r.IsAvailable).ToList();
    }

    public Room? GetRoomById(int id)
    {
        return _rooms.FirstOrDefault(r => r.Id == id);
    }

    public bool MarkUnavailable(int id)
    {
        var room = GetRoomById(id);
        if (room == null) return false;

        room.IsAvailable = false;
        return true;
    }

    public bool RestoreAvailability(int id)
    {
        var room = GetRoomById(id);
        if (room == null) return false;

        room.IsAvailable = true;
        return true;
    }

    public bool UpdateAvailability(int id, bool isAvailable)
    {
        var room = GetRoomById(id);
        if (room == null) return false;

        room.IsAvailable = isAvailable;
        return true;
    }
}