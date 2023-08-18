using AirportManagement.Domain;
using AirportManagement.Shared;
using System.Collections.Concurrent;

namespace Infrastructure.Contexts
{
    public static class AirportDataContext
    {
        static readonly ConcurrentDictionary<string, Bag> _bags = new();
        static readonly ConcurrentDictionary<string, Flight> _flights = new();
        static readonly ConcurrentDictionary<string, Ticket> _tickets = new();
        static readonly ConcurrentDictionary<string, Passenger> _passengers = new();     

        public static AirportBaseModel? Save(AirportBaseModel entity)
        {
            return entity switch
            {
                Bag e => _bags.AddOrUpdate(e.Id, e, (k, v) => e),
                Flight e => _flights.AddOrUpdate(e.Id, e, (k, v) => e),
                Passenger e => _passengers.AddOrUpdate(e.Id, e, (k, v) => e),
                Ticket e => _tickets.AddOrUpdate(e.Id, e, (k, v) => e),
                _ => throw new InvalidOperationException("Unable to handle object presistence"),
            };
        }
        public static bool Delete(AirportBaseModel entity)
        {
            return entity switch
            {
                Bag e => _bags.TryRemove(new(e.Id, e)),
                Flight e => _flights.TryRemove(new(e.Id, e)),
                Passenger e => _passengers.TryRemove(new(e.Id, e)),
                Ticket e => _tickets.TryRemove(new(e.Id, e)),
                _ => throw new InvalidOperationException("Unable to handle object presistence"),
            };
        }

        public static IEnumerable<Bag> Bags { get => _bags.Values; }
        public static IEnumerable<Flight> Flights { get => _flights.Values; }
        public static IEnumerable<Ticket> Tickets { get => _tickets.Values; }
        public static IEnumerable<Passenger> Passengers { get => _passengers.Values; }

        public static void SeedData()
        {
            if (_flights.IsEmpty)
            {
                var f1 = new Flight(departure: Airport.GetAirport("JFK"), destination: Airport.GetAirport("IAH"), departureDate: DateTime.Now.AddHours(1), flightDuration: TimeSpan.FromHours(2.5), availableFirstClassSeats: 20, availableCoachPlusSeats: 108, availableCoachSeats: 36);
                
                var f2 = new Flight(departure: Airport.GetAirport("IAH"), destination: Airport.GetAirport("MIA"), departureDate: DateTime.Now, flightDuration: TimeSpan.FromHours(3.5), availableFirstClassSeats: 20, availableCoachPlusSeats: 108, availableCoachSeats: 36);
                var f3 = new Flight(departure: Airport.GetAirport("IAH"), destination: Airport.GetAirport("BWI"), departureDate: DateTime.Now.AddHours(2), flightDuration: TimeSpan.FromHours(1.5), availableFirstClassSeats: 20, availableCoachPlusSeats: 108, availableCoachSeats: 36);
                var f4 = new Flight(departure: Airport.GetAirport("MIA"), destination: Airport.GetAirport("PHX"), departureDate: DateTime.Now.AddHours(3), flightDuration: TimeSpan.FromHours(4.5), availableFirstClassSeats: 20, availableCoachPlusSeats: 108, availableCoachSeats: 36);

                var f5 = new Flight(departure: Airport.GetAirport("JFK"), destination: Airport.GetAirport("IAH"), departureDate: DateTime.Now.AddDays(2).AddHours(1), flightDuration: TimeSpan.FromHours(2.5), availableFirstClassSeats: 20, availableCoachPlusSeats: 108, availableCoachSeats: 36);
                var f6 = new Flight(departure: Airport.GetAirport("IAH"), destination: Airport.GetAirport("MIA"), departureDate: DateTime.Now.AddDays(5), flightDuration: TimeSpan.FromHours(3.5), availableFirstClassSeats: 20, availableCoachPlusSeats: 108, availableCoachSeats: 36);
                var f7 = new Flight(departure: Airport.GetAirport("IAH"), destination: Airport.GetAirport("BWI"), departureDate: DateTime.Now.AddDays(3).AddHours(2), flightDuration: TimeSpan.FromHours(1.5), availableFirstClassSeats: 20, availableCoachPlusSeats: 108, availableCoachSeats: 36);
                var f8 = new Flight(departure: Airport.GetAirport("MIA"), destination: Airport.GetAirport("PHX"), departureDate: DateTime.Now.AddDays(1).AddHours(3), flightDuration: TimeSpan.FromHours(4.5), availableFirstClassSeats: 20, availableCoachPlusSeats: 108, availableCoachSeats: 36);

                Save(f1);
                Save(f2);
                Save(f3);
                Save(f4);

                Save(f5);
                Save(f6);
                Save(f7);
                Save(f8);
            }
        }
    }
}
