using AirportManagement.Shared;

namespace AirportManagement.Domain;

public class DelayFlight : ICommand
{
    public DelayFlight() { }

    public DelayFlight(string flightId, double delay)
    {
        if(delay == 0 || delay < 0)
            throw new ArgumentOutOfRangeException(nameof(delay));

        FlightId = flightId;
        Delay = delay;
    }

    public string? FlightId { get; }
    public double? Delay { get; }
}
