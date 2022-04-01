namespace Events.Shared
{
    public class FlightCreatedEventArgs : AirportObjectChangedEventArgs
    {
        public FlightCreatedEventArgs(Flight f)
        {
            Flight = f;
        }

        public Flight Flight { get; }
    }
}