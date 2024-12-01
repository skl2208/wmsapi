using WMSAPI.Context;
using WMSAPI.Models;
using WMSAPI.Services.Interfaces;

namespace WMSAPI.Services
{
    public class SpdUtilService : ISpd
    {
        private readonly DBSPDConnect _spd;
        public SpdUtilService(DBSPDConnect spd)
        {
            _spd = spd;
        }
        public ResponseAPI GetMaster(string searchGP="*")
        {
            ResponseAPI response = new ResponseAPI()
            {
                Result = "FAIL",
            };

            try
            {
                searchGP = (searchGP.Trim() == "" ? "*" : searchGP.Trim());

                _spd.SetCommandStoredProcedure("GetAllMaster");
                _spd.AddInputParameter("searchGP", System.Data.SqlDbType.NVarChar, searchGP);

                var result = _spd.ExecuteToList<MasterSPD>();

                response.Result = "SUCCESS";
                response.ResponseJson = result;
                response.RECCOUNT = result.Count.ToString();

            } catch(Exception ex)
            {
/*                response.Result = "FAIL";
                response.Info = "Error while loading information !";*/
                throw;
            }

            return response;
        }
    }
}
