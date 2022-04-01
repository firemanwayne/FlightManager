namespace Events.Shared
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