namespace AirportManager.Shared
{
    public class FlightTicket : AirportBaseModel
    {
        public FlightTicket() : base()
        { }

        public FlightTicket(string flightId, int rowNumber, FlightSeatType seatType, FlightSeatNumber seatNumber, double price, string passengerId = "") : base()
        {
            FlightId = flightId;
            SeatType = seatType;
            SeatNumber = seatNumber;
            PassengerId = passengerId;
            Price = price;
            RowNumber = rowNumber;
        }

        public string FlightId { get; set; } = string.Empty;
        public FlightSeatType SeatType { get; set; }
        public string PassengerId { get; set; } = string.Empty;
        public FlightSeatNumber SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public double Price { get; set; } = default;
    }
}
