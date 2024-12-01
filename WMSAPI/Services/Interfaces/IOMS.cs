using WMSAPI.Models;

namespace WMSAPI.Services.Interfaces
{
    public interface IOMS
    {
        public List<GetWarehouse> GetWarehouse(string purchase_no);
    }
}