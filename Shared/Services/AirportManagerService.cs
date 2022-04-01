using System.Collections.Concurrent;

namespace Events.Shared
{
    public delegate void FlightCreatedEventHandler(object o, FlightCreatedEventArgs e);
    public delegate void FlightChangedEventHandler(object o, FlightChangedEventArgs e);

    public interface IAirportManagerService
    {
        void SeedData();
        void Handle(ICommand cmd);

        void CheckIn(Passenger p, string flight);
        void RemovePassenger(Passenger p, string flight);
        IEnumerable<Flight> GetFlights(Func<Flight, bool>? predicate);

        event FlightChangedEventHandler OnFlightUpdated;
    }

    public class AirportManagerService : IAirportManagerService
    {
        static readonly ConcurrentDictionary<string, Flight> _flights = new();

        public event FlightChangedEventHandler? OnFlightUpdated;
        public event FlightCreatedEventHandler? OnFlightCreated;

        public AirportManagerService()
        {
            OnFlightCreated += GenerateFlightTickets;
        }

        public void Handle(ICommand cmd)
        {
            switch (cmd)
            {
                case CreateFlightCommand c:
                    AddFlight(c);
                    break;

                case UpdateFlightStatusCommand c:
                    UpdateFlightStatus(c);
                    break;

                case DelayFlightCommand c:
                    DelayFlight(c);
                    break;

                case DeleteFlightCommand c:
                    RemoveFlight(c);
                    break;

                default: break;
            }
        }

        void AddFlight(CreateFlightCommand cmd)
        {
            var f = cmd.ToFlight();

            var result = _flights.TryAdd(f.Id, f);

            if (result)            
                OnFlightCreated?.Invoke(this, new(f));
        }

        void AddTicketForFlight(string flightId, FlightTicket ticket)
        {
            if (_flights.TryGetValue(flightId, out var flightToUpdate))
            {
                if(flightToUpdate.AddAvailableTicket(ticket))
                    OnFlightUpdated?.Invoke(this, new(flightToUpdate));
            }
        }

        void RemoveFlight(DeleteFlightCommand cmd)
        {
            if (_flights.TryGetValue(cmd.FlightId, out var flightToRemove))
            {
                var result = _flights.TryRemove(KeyValuePair.Create(flightToRemove.Id, flightToRemove));

                if (result)
                    OnFlightUpdated?.Invoke(this, new(flightToRemove));
            }
        }

        void UpdateFlightStatus(UpdateFlightStatusCommand cmd)
        {
            if (_flights.TryGetValue(cmd.FlightId, out var flightToUpdate))
            {
                flightToUpdate.UpdateStatus(cmd.Status);
                OnFlightUpdated?.Invoke(this, new(flightToUpdate));
            }
        }      

        void DelayFlight(DelayFlightCommand cmd)
        {
            if (_flights.TryGetValue(cmd.FlightId, out var flightToUpdate))
            {
                if (cmd.Delay.HasValue)
                {
                    flightToUpdate.DelayFlight(TimeSpan.FromMinutes(cmd.Delay.Value));

                    OnFlightUpdated?.Invoke(this, new(flightToUpdate));
                }
            }
        }

        public void CheckIn(Passenger p, string flight)
        {
            var result = _flights.TryGetValue(flight, out var flightToUpdate);

            if (result && flightToUpdate != null)
            {
                if (flightToUpdate.AddPassenger(p))
                {
                    p.UpdateStatus(PassengerStatus.CheckedIn);

                    OnFlightUpdated?.Invoke(this, new(flightToUpdate));
                }
            }
        }

        public void RemovePassenger(Passenger p, string flight)
        {
            var result = _flights.TryGetValue(flight, out var flightToUpdate);

            if (result && flightToUpdate != null)
            {
                if (flightToUpdate.RemovePassenger(p))
                    OnFlightUpdated?.Invoke(this, new(flightToUpdate));              
            }
        }

        public IEnumerable<Flight> GetFlights(Func<Flight, bool>? predicate)
        {
            if (predicate != null)
                return _flights.Select(f => f.Value).ToList().Where(predicate);
            else
                return _flights.Select(f => f.Value).AsEnumerable();
        }

        public void SeedData()
        {
            if (_flights.IsEmpty)
            {
                var f1 = new CreateFlightCommand(departure: "JFK", destination: "IAH", departureDate: DateTime.Now.AddHours(1), duration: TimeSpan.FromHours(2.5), availableFirstClass: 20, availableCoachPlus: 108, availableCoach: 36);
                var f2 = new CreateFlightCommand(departure: "IAH", destination: "MIA", departureDate: DateTime.Now, duration: TimeSpan.FromHours(3.5), availableFirstClass: 20, availableCoachPlus: 108, availableCoach: 36);
                var f3 = new CreateFlightCommand(departure: "IAH", destination: "BWI", departureDate: DateTime.Now.AddHours(2), duration: TimeSpan.FromHours(1.5), availableFirstClass: 20, availableCoachPlus: 108, availableCoach: 36);
                var f4 = new CreateFlightCommand(departure: "MIA", destination: "PHX", departureDate: DateTime.Now.AddHours(3), duration: TimeSpan.FromHours(4.5), availableFirstClass: 20, availableCoachPlus: 108, availableCoach: 36);

                var f5 = new CreateFlightCommand(departure: "JFK", destination: "IAH", departureDate: DateTime.Now.AddDays(2).AddHours(1), duration: TimeSpan.FromHours(2.5), availableFirstClass: 20, availableCoachPlus: 108, availableCoach: 36);
                var f6 = new CreateFlightCommand(departure: "IAH", destination: "MIA", departureDate: DateTime.Now.AddDays(5), duration: TimeSpan.FromHours(3.5), availableFirstClass: 20, availableCoachPlus: 108, availableCoach: 36);
                var f7 = new CreateFlightCommand(departure: "IAH", destination: "BWI", departureDate: DateTime.Now.AddDays(3).AddHours(2), duration: TimeSpan.FromHours(1.5), availableFirstClass: 20, availableCoachPlus: 108, availableCoach: 36);
                var f8 = new CreateFlightCommand(departure: "MIA", destination: "PHX", departureDate: DateTime.Now.AddDays(1).AddHours(3), duration: TimeSpan.FromHours(4.5), availableFirstClass: 20, availableCoachPlus: 108, availableCoach: 36);

                AddFlight(f1);
                AddFlight(f2);
                AddFlight(f3);
                AddFlight(f4);

                AddFlight(f5);
                AddFlight(f6);
                AddFlight(f7);
                AddFlight(f8);
            }
        }

        void GenerateFlightTickets(object o, FlightCreatedEventArgs args)
        {
            var flight = args.Flight;

            foreach(var row in Standard747Template.SeatingChart.FirstClassRows)
                foreach(var seat in row.Seats)
                {
                    var ticket = new FlightTicket
                    {
                        FlightId = flight.Id,
                        SeatType = seat.SeatType,
                        SeatNumber = seat.SeatNumber,
                        RowNumber = seat.RowNumber,
                        Price = 1250.00
                    };
                    AddTicketForFlight(flightId: flight.Id, ticket);
                }

            foreach (var row in Standard747Template.SeatingChart.CoachPlusRows)
                foreach (var seat in row.Seats) 
                {
                    var ticket = new FlightTicket
                    {
                        FlightId = flight.Id,
                        SeatType = seat.SeatType,
                        SeatNumber = seat.SeatNumber,
                        RowNumber = seat.RowNumber,
                        Price = 750.00
                    };

                    AddTicketForFlight(flightId: flight.Id, ticket);
                }

            foreach (var row in Standard747Template.SeatingChart.CoachRows)
                foreach (var seat in row.Seats) 
                {
                    var ticket = new FlightTicket
                    {
                        FlightId = flight.Id,
                        SeatType = seat.SeatType,
                        SeatNumber = seat.SeatNumber,
                        RowNumber = seat.RowNumber,
                        Price = 500.00
                    };
                    AddTicketForFlight(flightId: flight.Id, ticket);
                }
        }        
    }
}