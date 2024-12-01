using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMSAPI.Models;
using WMSAPI.Services.Interfaces;

namespace WMSAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WmsController : ControllerBase
    {
        private readonly IWms _wms;
        public WmsController(IWms wms)
        {
            _wms = wms;
        }
        [HttpGet("{warehouse}/{orderkey}")]
        public ResponseAPI GetLotNameByOrderkey(string warehouse, string orderkey)
        {
            ResponseAPI responseAPI = new ResponseAPI()
            {
                Result = "FAIL",
                Info = "Fail to load data"
            };

            var result = _wms.GetLotNameByOrderkey(warehouse, orderkey);

            if (result.Count > 0)
            {
                responseAPI.Result = "SUCCESS";
                responseAPI.Info = "Successfully Load Data";
                responseAPI.RECCOUNT = result.Count.ToString();
                responseAPI.ResponseJson = result;
            }
            else
            {
                responseAPI.Result = "SUCCESS";
                responseAPI.Info = "No Data";
                responseAPI.RECCOUNT = "0";
                responseAPI.ResponseJson = string.Empty;
            }

            return responseAPI;
        }
        [HttpGet("{warehouse}/{pl}")]
        public ResponseAPI GetLotNameByPL(string warehouse, string pl)
        {
            ResponseAPI responseAPI = new ResponseAPI()
            {
                Result = "FAIL",
                Info = "Fail to load data"
            };

            var result = _wms.GetLotNameByPL(warehouse, pl);

            if (result.Count > 0)
            {
                responseAPI.Result = "SUCCESS";
                responseAPI.Info = "Successfully Load Data";
                responseAPI.RECCOUNT = result.Count.ToString();
                responseAPI.ResponseJson = result;
            }
            else
            {
                responseAPI.Result = "SUCCESS";
                responseAPI.Info = "No Data";
                responseAPI.RECCOUNT = "0";
                responseAPI.ResponseJson = string.Empty;
            }

            return responseAPI;
        }
        [HttpGet("{warehouse}/{pl}")]
        public ResponseAPI GetCurrentStatus(string warehouse, string pl)
        {
            ResponseAPI responseAPI = new ResponseAPI()
            {
                Result = "FAIL",
                Info = "Fail to load data"
            };

            WMSStatus result = _wms.GetCurrentStatus(warehouse, pl);

            if (result is not null)
            {
                responseAPI.Result = "SUCCESS";
                responseAPI.Info = "Successfully Load Data";
                responseAPI.RECCOUNT = "1";
                responseAPI.ResponseJson = result;
            }

            return responseAPI;
        }
        [HttpGet("{date}/{month}/{year}")]
        public Task<ResponseAPI> GetReportShipmentFromDate(string date, string month, string year)
        {
            ResponseAPI responseAPI = new ResponseAPI()
            {
                Result = "FAIL",
                Info = "Fail to load data"
            };

            try
            {
                var result = _wms.ReportShipmentFromDate(date, month, year);

                if (result.Count > 0)
                {
                    responseAPI.Result = "SUCCESS";
                    responseAPI.Info = "Successfully Load Data";
                    responseAPI.RECCOUNT = result.Count.ToString();
                    responseAPI.ResponseJson = result;
                }
            }
            catch (Exception ex)
            {
                responseAPI.Info = "Input Date Error !!!";
            }

            return Task.FromResult(responseAPI);
        }
        [HttpGet("{DateIn}")]
        public Task<ResponseAPI> GetShipmentStatus(string DateIn)
        {
            ResponseAPI responseAPI = new ResponseAPI()
            {
                Result = "FAIL",
                Info = "Fail to load data"
            };

            try
            {
                var result = _wms.GetShipmentStatus(DateIn);

                if (result.Count > 0)
                {
                    responseAPI.Result = "SUCCESS";
                    responseAPI.Info = "Successfully Load Data";
                    responseAPI.RECCOUNT = result.Count.ToString();
                    responseAPI.ResponseJson = result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(responseAPI);
        }
    }
}
