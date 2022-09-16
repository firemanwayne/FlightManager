using System.Security.Claims;

namespace AirportManager.Shared
{
    public class Passenger : AirportBaseModel
    {
        public Passenger() : base()
        {
            Status = PassengerStatus.NotCheckedIn;
        }

        public Passenger(ClaimsPrincipal user, string flight, IEnumerable<Bag>? bags) : base()
        {
            if (user.Identity != null)
            {
                Name = user.FindFirstValue(ClaimTypes.Name);
                UserId = user.FindFirstValue(ClaimTypeExtensions.UniqueIdentifier);
            }
            FlightId = flight;
            Status = PassengerStatus.NotCheckedIn;

            if (bags != null)
                foreach (var b in bags)
                    AddBag(b);            
        }

        public string? UserId { get; set; }

        public string? Name { get; set; }

        public string? FlightId { get; set; }

        public PassengerStatus Status { get; private set; }

        public FlightTicket? Ticket { get; set; }

        public IList<Bag> Bags { get; } = new List<Bag>();

        public void AddBag(Bag b) => Bags.Add(b);

        public void RemoveBag(Bag b) => Bags.Remove(b);

        public void UpdateStatus(PassengerStatus s) => Status = s;
    }
}
