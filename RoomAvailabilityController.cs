using Microsoft.AspNetCore.Mvc;
using RoomBookingApi.Services;

namespace RoomBookingApi.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomAvailabilityController : ControllerBase
{
    private readonly RoomAvailabilityService _service;

    public RoomAvailabilityController(RoomAvailabilityService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAllRooms()
    {
        return Ok(_service.GetAllRooms());
    }

    [HttpGet("available")]
    public IActionResult GetAvailableRooms()
    {
        return Ok(_service.GetAvailableRooms());
    }

    [HttpPut("{id}/unavailable")]
    public IActionResult MarkUnavailable(int id)
    {
        var updated = _service.MarkUnavailable(id);
        if (!updated) return NotFound(new { message = "Room not found" });

        return Ok(new { message = "Room marked unavailable" });
    }

    [HttpPut("{id}/available")]
    public IActionResult RestoreAvailability(int id)
    {
        var updated = _service.RestoreAvailability(id);
        if (!updated) return NotFound(new { message = "Room not found" });

        return Ok(new { message = "Room restored to available" });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAvailability(int id, [FromBody] UpdateRoomAvailabilityRequest request)
    {
        var updated = _service.UpdateAvailability(id, request.IsAvailable);
        if (!updated) return NotFound(new { message = "Room not found" });

        return Ok(new { message = "Room availability updated" });
    }
}

public class UpdateRoomAvailabilityRequest
{
    public bool IsAvailable { get; set; }
}