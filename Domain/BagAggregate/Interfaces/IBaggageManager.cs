using AirportManagement.Shared;

namespace AirportManagement.Domain;

public interface IBaggageManager
{
    void Handle(ICommand cmd);
}