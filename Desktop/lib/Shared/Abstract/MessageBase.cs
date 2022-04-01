using System.Text.Json.Serialization;

namespace Desktop.Shared
{
    public class MessageBase
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
    }
}
