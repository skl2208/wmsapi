using WMSAPI.Models;

namespace WMSAPI.Services.Interfaces
{
    public interface IWms
    {
        public List<Lot> GetLotNameByOrderkey(string WAREHOUSE, string ORDERKEY);
        public List<Lot> GetLotNameByPL(string WAREHOUSE, string PL);
        public WMSStatus GetCurrentStatus(string WAREHOUSE, string PL);
        public List<ReportShipmentFromDate> ReportShipmentFromDate(string day, string month, string year);
        public List<ShipmentStatus> GetShipmentStatus(string DateIn);
    }
}
