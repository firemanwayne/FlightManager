using AirportManagement.Shared;

namespace AirportManagement.Domain
{
    public class FlightChangedEventArgs : AirportObjectChangedEventArgs
    {
        public FlightChangedEventArgs(Flight f)
        {
            Flight = f;
        }

        public Flight Flight { get; }
    }
}