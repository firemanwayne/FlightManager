using AirportManagement.Shared;
using System.Text.Json.Serialization;

namespace AirportManagement.Domain;

public class Flight : AirportBaseModel
{
    public Flight() : base()
    {
        FlightStatus = FlightStatus.InQueue;
    }
    public Flight(int availableFirstClassSeats, int availableCoachPlusSeats, int availableCoachSeats, Airport? departure, Airport? destination, DateTime departureDate, TimeSpan flightDuration)
    {
        AvailableFirstClassSeats = availableFirstClassSeats;
        AvailableCoachPlusSeats = availableCoachPlusSeats;
        AvailableCoachSeats = availableCoachSeats;
        Departure = departure;
        Destination = destination;
        DepartureDate = departureDate;
        FlightDuration = flightDuration;

        FlightStatus = FlightStatus.InQueue;
    }

    [JsonPropertyName("availableFirstClassSeats")]
    public int AvailableFirstClassSeats { get; set; }

    [JsonPropertyName("availableCoachPlusSeats")]
    public int AvailableCoachPlusSeats { get; set; }

    [JsonPropertyName("availableCoachSeats")]
    public int AvailableCoachSeats { get; set; }

    [JsonPropertyName("departure")]
    public Airport? Departure { get; set; }

    [JsonPropertyName("destination")]
    public Airport? Destination { get; set; }

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
    public IList<Ticket> AvailableTickets { get; set; } = new List<Ticket>();

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
        else
        {
            throw new ArgumentOutOfRangeException(nameof(delay));
        }
    }
    public bool AddAvailableTicket(Ticket ticket)
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