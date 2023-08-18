using AirportManagement.Domain;
using AirportManagement.Shared;

namespace AirportManagement.Infrastructure
{
    internal sealed class BaggageManager : IBaggageManager
    {
        readonly IFlightManager _flightManager;

        public BaggageManager(IFlightManager flightManager)
        {
            _flightManager = flightManager;
        }

        public void Handle(ICommand cmd)
        {

        }
    }
}