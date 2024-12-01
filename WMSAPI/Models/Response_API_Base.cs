using System.Text.Json.Serialization;

namespace WMSAPI.Models
{
    public class Response_API_Base
    {
        [JsonPropertyName("RESULT")]
        [JsonPropertyOrder(1)]
        public string? Result { get; set; }

        [JsonPropertyName("MESSAGE")]
        [JsonPropertyOrder(2)]
        public string? Info { get; set; }

        [JsonPropertyName("RECCOUNT")]
        [JsonPropertyOrder(3)]
        public string RECCOUNT { get; set; } = "0";

        [JsonPropertyName("RESPONSEDATE")]
        [JsonPropertyOrder(4)]
        public string ResponseDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    }
}
