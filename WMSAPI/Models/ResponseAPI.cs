using System.Text.Json.Serialization;

namespace WMSAPI.Models
{
    public class ResponseAPI : Response_API_Base
    {
        [JsonPropertyName("DATA")]
        [JsonPropertyOrder(5)]
        public dynamic? ResponseJson { get; set; }
    }
}
