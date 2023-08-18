using AirportManagement.Shared;

namespace AirportManagement.Domain;
public class PurchaseTicket : ICommand
{
    public PurchaseTicket(string ticketId, string passengerId)
    {
        TicketId = ticketId;
        PassengerId = passengerId;
    }

    public string? TicketId { get; }

    public string? PassengerId { get; }
}
