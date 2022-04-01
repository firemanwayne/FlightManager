namespace Events.Shared
{
    public static class FlightExtensions
    {
        public static Flight ToFlight(this CreateFlightCommand cmd)
        {
            var airport = new Airport();

            return new Flight
            {
                Departure = airport[cmd.Departure],
                Destination = airport[cmd.Destination],
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
