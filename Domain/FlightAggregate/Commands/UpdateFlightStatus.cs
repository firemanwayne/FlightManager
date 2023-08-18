using AirportManagement.Shared;

namespace AirportManagement.Domain;

public class UpdateFlightStatus : ICommand
{
    public UpdateFlightStatus(string flightId, FlightStatus status)
    {
        FlightId = flightId;
        Status = status;
    }

    public string? FlightId { get; }
    public FlightStatus Status { get; }
}