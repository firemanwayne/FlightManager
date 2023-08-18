using AirportManagement.Domain;
using AirportManagement.Shared;

namespace AirportManagement.Infrastructure
{
    internal sealed class PassengerManager : IPassengerManager
    {
        readonly IFlightManager _flightManager;

        public PassengerManager(IFlightManager flightManager)
        {
            _flightManager = flightManager;
        }

        public void CheckIn(Passenger p, string flight)
        {
            throw new NotImplementedException();
        }

        public void Handle(ICommand cmd)
        {

        }

        public void RemovePassenger(Passenger p, string flight)
        {
            throw new NotImplementedException();
        }
    }
}