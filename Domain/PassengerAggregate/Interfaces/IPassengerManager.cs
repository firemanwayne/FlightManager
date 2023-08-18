using AirportManagement.Domain;
using AirportManagement.Shared;

namespace AirportManagement.Infrastructure
{
    public interface IPassengerManager
    {
        void Handle(ICommand cmd);
        void CheckIn(Passenger p, string flight);
        void RemovePassenger(Passenger p, string flight);
    }
}