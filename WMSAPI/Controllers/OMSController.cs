using Microsoft.AspNetCore.Mvc;
using WMSAPI.Constant;
using WMSAPI.Context;
using WMSAPI.Models;

namespace WMSAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OMSController : ControllerBase
    {
        private readonly DBOMSConnect _dbOMS;

        public OMSController(DBOMSConnect dbOMS)
        {
            _dbOMS = dbOMS;
        }
        [HttpGet("{purchase_no}")]
        public IActionResult GetWareHouse(string purchase_no)
        {
            ResponseAPI responseAPI = new ResponseAPI()
            {
                Result = "FAIL",
                RECCOUNT = "0",
            };

            _dbOMS.SetCommandStoredProcedure("z_GetWarehouse");
            _dbOMS.AddInputParameter("PL", System.Data.SqlDbType.NVarChar, purchase_no);

            var result = _dbOMS.ExecuteToList<GetWarehouse>().FirstOrDefault();

            if (result is not null)
            {

                var a_name = MyUtilClass.GETDCNAME(result.dc_id);

                if(a_name is null)
                {
                    result.warehousecode = "";
                } else
                {
                    result.warehousecode = a_name;
                }
                
                if(result.d_bypass_type=="CLEARANCE")
                {
                    result.order_type = "เบิกจาก Sale Return";
                } else
                {
                    result.order_type = "เบิกปกติ";
                }

                responseAPI.Result = "SUCCESS";
                responseAPI.RECCOUNT = "1";
                responseAPI.Info = "Successfully Loaded Data";
                responseAPI.ResponseJson = result;
            }

            return Ok(responseAPI);
        }
    }
}
