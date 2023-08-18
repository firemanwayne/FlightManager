using AirportManagement.Shared;

namespace AirportManagement.Domain;

public interface IFlightManager
{       
    void Handle(ICommand cmd);        
    Flight? GetFlight(string id);
    IEnumerable<Flight> GetFlights(Func<Flight, bool>? predicate);

    event FlightChangedEventHandler OnFlightUpdated;
}