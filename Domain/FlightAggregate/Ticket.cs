using AirportManagement.Shared;
using System.Text.Json.Serialization;

namespace AirportManagement.Domain;

public class Ticket : AirportBaseModel
{
    public Ticket() : base()
    { }

    public Ticket(string flightId, int rowNumber, FlightSeatType seatType, FlightSeatNumber seatNumber, double price, string passengerId = "") : base()
    {
        FlightId = flightId;
        SeatType = seatType;
        SeatNumber = seatNumber;
        PassengerId = passengerId;
        Price = price;
        RowNumber = rowNumber;
    }

    [JsonPropertyName("flightId")]
    public string FlightId { get; set; } = string.Empty;

    [JsonPropertyName("seatType")]
    public FlightSeatType SeatType { get; set; }

    [JsonPropertyName("passengerId")]
    public string PassengerId { get; set; } = string.Empty;

    [JsonPropertyName("seatNumber")]
    public FlightSeatNumber SeatNumber { get; set; }

    [JsonPropertyName("rowNumber")]
    public int RowNumber { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; } = default;
}
