using WMSAPI.Context;
using WMSAPI.Models;
using WMSAPI.Services.Interfaces;

namespace WMSAPI.Services
{
    public class OmsUtilService : IOMS
    {
        private readonly DBOMSConnect _dbOMS;

        public OmsUtilService(DBOMSConnect dbConnect)
        {
            _dbOMS = dbConnect;
        }

        public List<GetWarehouse> GetWarehouse(string purchase_no)
        {
            try
            {
                _dbOMS.SetCommandStoredProcedure("z_GetWarehouse");
                _dbOMS.AddInputParameter("PL", System.Data.SqlDbType.NVarChar, purchase_no);

                var result = _dbOMS.ExecuteToList<GetWarehouse>();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
