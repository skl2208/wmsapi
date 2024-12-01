using System.Text.Json.Serialization;

namespace WMSAPI.Models
{
    public class Lot
    {
        [JsonPropertyName("WAVE")]
        public string WAVEKEY { get; set; } = string.Empty;

        [JsonPropertyName("ORDERKEY")]
        public string ORDERKEY { get; set; } = string.Empty;

        [JsonPropertyName("LINE")]
        public string ORDERLINENUMBER { get; set; }

        [JsonPropertyName("PL")]
        public string EXTERNORDERKEY { get; set; }

        [JsonPropertyName("PICKSTATUS")]
        public string PICKSTATUS { get; set; }

        [JsonPropertyName("SKU")]
        public string SKU { get; set; }

        [JsonPropertyName("DESCRIPTION")]
        public string DESCRIPTION { get; set; }

        [JsonPropertyName("ALLOCATED_DATE")]
        public string ALLOCATED_DATE { get; set; }

        [JsonPropertyName("OWNER")]
        public string OWNER { get; set; } = string.Empty; 

        [JsonPropertyName("TOTALQTY")]
        public double TOTALQTY { get; set; }

        [JsonPropertyName("LOT_NAME")]
        public string LOTNAME { get; set; } = string.Empty;

        [JsonPropertyName("MFG_DATE")]
        public DateTime MFG_DATE { get; set; }

        [JsonPropertyName("EXP_DATE")]
        public DateTime EXP_DATE { get; set; }

        [JsonPropertyName("COST")]
        public string COST { get; set; } = "0.0";

        [JsonPropertyName("PRICE")] 
        public string PRICE { get; set; } = "0.0";
        [JsonPropertyName("ORDERTYPE")]
        public string TYPE { get; set; }
    }
}
