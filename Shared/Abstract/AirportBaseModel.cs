using System.Text.Json.Serialization;

namespace AirportManagement.Shared
{
    public abstract class AirportBaseModel
    {
        public AirportBaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public AirportBaseModel(string id)
        {
            Id = id;
        }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
