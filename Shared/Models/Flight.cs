using System.Text.Json.Serialization;

namespace Events.Shared
{   
    public class Flight : AirportBaseModel
    {
        public Flight() : base()
        {
            FlightStatus = FlightStatus.InQueue;
        }        

        [JsonPropertyName("availableFirstClassSeats")]
        public int AvailableFirstClassSeats { get; set; }

        [JsonPropertyName("availableCoachPlusSeats")]
        public int AvailableCoachPlusSeats { get; set; }

        [JsonPropertyName("availableCoachSeats")]
        public int AvailableCoachSeats { get; set; }

        [JsonPropertyName("departure")]
        public Airport Departure { get; set; } = new();

        [JsonPropertyName("destination")]
        public Airport Destination { get; set; } = new();

        [JsonPropertyName("departureDate")]        
        public DateTime DepartureDate { get; set; }

        [JsonPropertyName("arrivalDate")]
        public DateTime ArrivalDate
        {
            get
            {
                if (FlightDelay > TimeSpan.Zero)
                    return DepartureDate.Add(FlightDuration + FlightDelay);
                else
                    return DepartureDate.Add(FlightDuration);
            }
        }

        [JsonPropertyName("flightDuration")]
        public TimeSpan FlightDuration { get; set; } = TimeSpan.Zero;

        [JsonPropertyName("flightDelay")]
        public TimeSpan FlightDelay { get; set; } = TimeSpan.Zero;

        [JsonPropertyName("flightStatus")]
        public FlightStatus FlightStatus { get; set; }

        [JsonPropertyName("passengers")]
        public IList<Passenger> Passengers { get; set; } = new List<Passenger>();

        [JsonPropertyName("availableTickets")]
        public IList<FlightTicket> AvailableTickets { get; set; } = new List<FlightTicket>();

        public void DelayFlight(TimeSpan delay)
        {
            if (delay > TimeSpan.Zero)
            {
                FlightDelay = delay;
                UpdateStatus(FlightStatus.Delayed);
            }
        }
        public void DelayFlight(double delay)
        {
            if (delay > 0)
            {
                FlightDelay = TimeSpan.FromMinutes(delay);
                UpdateStatus(FlightStatus.Delayed);
            }
        }

        public bool AddAvailableTicket(FlightTicket ticket)
        {
            var result = false;

            if (ticket.SeatType == FlightSeatType.FirstClass && AvailableFirstClassSeats > 0)
            {
                AvailableTickets.Add(ticket);
                result = true;
            }
            else if (ticket.SeatType == FlightSeatType.CoachPlus && AvailableCoachPlusSeats > 0)
            {
                AvailableTickets.Add(ticket);
                result = true;
            }
            else if (ticket.SeatType == FlightSeatType.Coach && AvailableCoachSeats > 0)
            {
                AvailableTickets.Add(ticket);
                result = true;
            }
            return result;
        }

        public bool AddPassenger(Passenger p)
        {
            var result = true;

            if (AvailableFirstClassSeats > 0)
            {
                if (Passengers.Contains(p))
                    result = false;
                else
                    Passengers.Add(p);
            }
            else
                result = false;

            return result;
        }
        public bool RemovePassenger(Passenger p)
        {
            var result = true;

            if (AvailableFirstClassSeats == 0)
                result = false;
            else
            {
                if (Passengers.Contains(p))
                    Passengers.Remove(p);

                else
                    result = false;

                if (result)
                    AvailableFirstClassSeats++;
            }

            return result;
        }
        public void UpdateStatus(FlightStatus s) => FlightStatus = s;

        public int TotalSeats => AvailableFirstClassSeats + AvailableCoachPlusSeats + AvailableCoachSeats;
    }
}