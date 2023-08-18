using AirportManagement.Shared;
using System.Text.Json.Serialization;

namespace AirportManagement.Domain
{
    public class Bag : AirportBaseModel
    {
        BagStatus _status;

        public Bag() { }

        public Bag(string flightId, string passengerId) : base()
        {
            FlightId = flightId;
            PassengerId = passengerId;
            _status = BagStatus.NotChecked;
        }

        [JsonPropertyName("flightId")]
        public string? FlightId { get; set; }

        [JsonPropertyName("passengerId")]
        public string? PassengerId { get; set; }

        [JsonPropertyName("weight")]
        public double? Weight { get; set; }

        [JsonPropertyName("bagStatus")]
        public BagStatus BagStatus { get => _status; }

        public void WeightBag(double value)
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            Weight = value;
        }

        public void UpdateStatus(BagStatus status) => _status = status;
    }
}
