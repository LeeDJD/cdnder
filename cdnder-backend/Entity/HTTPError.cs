using System.Text.Json.Serialization;

namespace cdnder_backend.Entity
{
    public class HTTPError
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }

        public HTTPError(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}