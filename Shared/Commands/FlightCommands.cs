using System.ComponentModel.DataAnnotations;

namespace Events.Shared
{
    public interface ICommand
    {        
    }

    public class CreateFlightCommand : ICommand
    {
        public CreateFlightCommand()
        { }
        public CreateFlightCommand(int availableFirstClass, int availableCoachPlus, int availableCoach, string destination, string departure, TimeSpan duration, DateTime departureDate)
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

    public class UpdateFlightStatusCommand : ICommand
    {
        public UpdateFlightStatusCommand()
        { }

        public UpdateFlightStatusCommand(string flightId, FlightStatus status)
        {
            FlightId = flightId;
            Status = status;
        }

        public string? FlightId { get; set; }
        public FlightStatus Status { get; set; }
    }

    public class DeleteFlightCommand : ICommand
    {
        public DeleteFlightCommand()
        { }

        public DeleteFlightCommand(string flightId)
        {
            FlightId = flightId;
        }

        public string? FlightId { get; set; }
    }

    public class DelayFlightCommand : ICommand
    {
        public DelayFlightCommand()
        { }

        public DelayFlightCommand(string flightId, double delay)
        {
            FlightId = flightId;
            Delay = delay;
        }

        public string? FlightId { get; set; }
        public double? Delay { get; set; }

    }
}
