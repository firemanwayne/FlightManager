using AirportManagement.Shared;

namespace AirportManagement.Domain;

public class DeleteFlight : ICommand
{
    public DeleteFlight() { }

    public DeleteFlight(string flightId)
    {
        FlightId = flightId;
    }

    public string? FlightId { get; }
}
