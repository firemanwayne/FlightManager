using AirportManagement.Shared;

namespace AirportManagement.Domain
{
    public static class FlightExtensions
    {
        public static Flight ToFlight(this CreateFlight cmd)
        {
            return new Flight
            {
                Departure = Airport.GetAirport(cmd.Departure),
                Destination = Airport.GetAirport(cmd.Destination),
                DepartureDate = cmd.DepartureDate,
                AvailableFirstClassSeats = cmd.AvailableFirstClassSeats,
                AvailableCoachPlusSeats = cmd.AvailableCoachPlusSeats,
                AvailableCoachSeats = cmd.AvailableCoachSeats,
                FlightStatus = FlightStatus.InQueue,
                FlightDuration = cmd.FlightDuration,
            };
        }       
    }
}
