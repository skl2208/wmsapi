using System.Text.Json.Serialization;

namespace WMSAPI.Models
{
    public class GetWarehouse
    {
        [JsonPropertyName("WAREHOUSECODE")]
        public string warehousecode { get; set; }
        [JsonPropertyName("PURCHASE_NO")]
        public string purchase_no { get; set; }
        [JsonPropertyName("DCCODE")]
        public string dc_id { get; set; }
        [JsonPropertyName("ORDERTYPE")]
        public string order_type { get; set; }
        [JsonPropertyName("DESCRIPTION")]
        public string dc_detail { get; set; }
        [JsonIgnore]
        public string d_bypass_type { get; set; }
        [JsonIgnore]
        public string u_dc_id_stock_book { get; set; }
    }
}
