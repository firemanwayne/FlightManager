namespace AirportManager.Shared
{
    public class Bag : AirportBaseModel
    {
        public Bag() : base()
        { }

        public Bag(string flight, string passenger) : base()
        {
            FlightId = flight;
            PassengerId = passenger;
        }

        public string? FlightId { get; set; }

        public string? PassengerId { get; set; }

        public double? Weight { get; set; }

        public void WeightBag(double value)
        {
            Weight = value;
        }
    }
}
