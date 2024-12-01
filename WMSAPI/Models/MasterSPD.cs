using System.Text.Json.Serialization;

namespace WMSAPI.Models
{
    public class MasterSPD
    {
        [JsonPropertyName("genericId")]

        public string GP { get; set; }
        [JsonPropertyName("genericName")]
        public string DESCRIPTION { get; set; }
        [JsonPropertyName("uom")]
        public string UOM { get; set; }
        public string owner { get; set; }
        public string inuse { get; set; }
        public string packdescription { get; set; }
        public string group_name { get; set; }
        public string category_name { get; set; }
        [JsonPropertyName("strength")]
        public string STRENGTH { get; set; }
        [JsonPropertyName("extend_group")]
        public string ext_group { get; set; }
    }
}
