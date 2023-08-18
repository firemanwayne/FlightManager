using AirportManagement.Domain;
using AirportManagement.Shared;
using Infrastructure.Contexts;

namespace AirportManagement.Infrastructure
{
    internal class FlightManager : IFlightManager
    {       
        public event FlightChangedEventHandler? OnFlightUpdated;
        public event FlightCreatedEventHandler? OnFlightCreated;

        public FlightManager()
        {
            OnFlightCreated += GenerateFlightTickets;
        }

        public void Handle(ICommand cmd)
        {
            switch (cmd)
            {
                case CreateFlight c:
                    AddFlight(c);
                    break;

                case UpdateFlightStatus c:
                    UpdateFlightStatus(c);
                    break;

                case DelayFlight c:
                    DelayFlight(c);
                    break;

                case DeleteFlight c:
                    RemoveFlight(c);
                    break;

                default: break;
            }
        }
        public Flight? GetFlight(string id) 
            => AirportDataContext.Flights.FirstOrDefault(f => f.Id.Equals(id));
        public IEnumerable<Flight> GetFlights(Func<Flight, bool>? predicate)
        {
            if (predicate != null)
                return AirportDataContext.Flights.Where(predicate).AsEnumerable();
            else
                return AirportDataContext.Flights.AsEnumerable();
        }

        public void CheckIn(Passenger p, string flightId)
        {
            var flight = AirportDataContext.Flights.FirstOrDefault(a => a.Id.Equals(flightId));

            if (flight is not null)
            {
                if (flight.AddPassenger(p))
                {
                    p.UpdateStatus(PassengerStatus.CheckedIn);

                    OnFlightUpdated?.Invoke(this, new(flight));
                }
            }
        }

        public void RemovePassenger(Passenger p, string flightId)
        {
            var flight = AirportDataContext.Flights.FirstOrDefault(a => a.Id.Equals(flightId));

            if (flight is not null)
            {
                if (flight.RemovePassenger(p))
                    OnFlightUpdated?.Invoke(this, new(flight));
            }
        }

        void AddFlight(CreateFlight cmd)
        {
            var f = cmd.ToFlight();

            var result = AirportDataContext.Save(f);

            if (result is not null)            
                OnFlightCreated?.Invoke(this, new(f));
        }

        void AddTicketForFlight(string flightId, Ticket ticket)
        {
            var flight = AirportDataContext.Flights.FirstOrDefault(a => a.Id.Equals(flightId));

            if (flight is not null)
            {
                if(flight.AddAvailableTicket(ticket))
                    OnFlightUpdated?.Invoke(this, new(flight));
            }
        }

        void RemoveFlight(DeleteFlight cmd)
        {
            var flight = AirportDataContext.Flights.FirstOrDefault(a => a.Id.Equals(cmd.FlightId));

            var result = AirportDataContext.Delete(flight);

            if (result)
                OnFlightUpdated?.Invoke(this, new(flight));
        }

        void UpdateFlightStatus(UpdateFlightStatus cmd)
        {
            var flight = AirportDataContext.Flights.FirstOrDefault(a => a.Id.Equals(cmd.FlightId));

            if (flight is not null)
            {
                flight.UpdateStatus(cmd.Status);
                OnFlightUpdated?.Invoke(this, new(flight));
            }
        }      

        void DelayFlight(DelayFlight cmd)
        {
            var flight = AirportDataContext.Flights.FirstOrDefault(a => a.Id.Equals(cmd.FlightId));

            if (flight is not null)
            {
                if (cmd.Delay.HasValue)
                {
                    flight.DelayFlight(TimeSpan.FromMinutes(cmd.Delay.Value));

                    OnFlightUpdated?.Invoke(this, new(flight));
                }
            }
        }        

        void GenerateFlightTickets(object o, FlightCreatedEventArgs args)
        {
            var flight = args.Flight;

            foreach(var row in Standard747Template.SeatingChart.FirstClassRows)
                foreach(var seat in row.Seats)
                {
                    var ticket = new Ticket
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
                    var ticket = new Ticket
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
                    var ticket = new Ticket
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