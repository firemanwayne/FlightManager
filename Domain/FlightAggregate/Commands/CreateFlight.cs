using AirportManagement.Shared;
using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Domain;

public class CreateFlight : ICommand
{
    public CreateFlight() { }

    public CreateFlight(int availableFirstClass, int availableCoachPlus, int availableCoach, string destination, string departure, TimeSpan duration, DateTime departureDate)
    {
        AvailableFirstClassSeats = availableFirstClass;
        AvailableCoachPlusSeats = availableCoachPlus;
        AvailableCoachSeats = availableCoach;
        Destination = destination;
        FlightDuration = duration;
        DepartureDate = departureDate;
        Departure = departure;
    }

    [Required]
    public int AvailableFirstClassSeats { get; set; }

    [Required]
    public int AvailableCoachPlusSeats { get; set; }

    [Required]
    public int AvailableCoachSeats { get; set; }

    [Required]
    public string Departure { get; set; } = string.Empty;

    [Required]
    public string Destination { get; set; } = string.Empty;

    [Required]
    public TimeSpan FlightDuration { get; set; }

    [Required]
    public DateTime DepartureDate { get; set; }
}
