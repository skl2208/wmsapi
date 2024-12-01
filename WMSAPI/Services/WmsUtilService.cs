using System;
using WMSAPI.Context;
using WMSAPI.Models;
using WMSAPI.Services.Interfaces;

namespace WMSAPI.Services
{
    public class WmsUtilService : IWms
    {
        private readonly DBWMSConnect _dbConnect;

        public WmsUtilService(DBWMSConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public List<Lot> GetLotNameByOrderkey(string WAREHOUSE,string ORDERKEY)
        {
            try
            {
                _dbConnect.SetCommandStoredProcedure("dbo.GetLotName");
                _dbConnect.AddInputParameter("pOrderKey", System.Data.SqlDbType.NVarChar, ORDERKEY);
                _dbConnect.AddInputParameter("whName", System.Data.SqlDbType.NVarChar, WAREHOUSE);

                var result = _dbConnect.ExecuteToList<Lot>();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Lot> GetLotNameByPL(string WAREHOUSE, string PL)
        {
            try
            {
                _dbConnect.SetCommandStoredProcedure("dbo.GetLotName");
                _dbConnect.AddInputParameter("PLDoc", System.Data.SqlDbType.NVarChar, PL);
                _dbConnect.AddInputParameter("whName", System.Data.SqlDbType.NVarChar, WAREHOUSE);

                var result = _dbConnect.ExecuteToList<Lot>();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public WMSStatus GetCurrentStatus(string WAREHOUSE, string PL)
        {
            try
            {
                _dbConnect.SetCommandStoredProcedure("dbo.GetCurrentStatus");
                _dbConnect.AddInputParameter("PLDoc", System.Data.SqlDbType.NVarChar, PL);
                _dbConnect.AddInputParameter("whName", System.Data.SqlDbType.NVarChar, WAREHOUSE);

                var result = _dbConnect.ExecuteToList<WMSStatus>().FirstOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ReportShipmentFromDate> ReportShipmentFromDate(string day,string month,string year)
        {
            try 
            {
                _dbConnect.SetCommandStoredProcedure("ReportShipmentFromDate");
                _dbConnect.AddInputParameter("Day",System.Data.SqlDbType.NVarChar,day);
                _dbConnect.AddInputParameter("Month", System.Data.SqlDbType.NVarChar,month);
                _dbConnect.AddInputParameter("Year", System.Data.SqlDbType.NVarChar,year);

                var result = _dbConnect.ExecuteToList<ReportShipmentFromDate>();

                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public List<ShipmentStatus> GetShipmentStatus(string DateIn)
        {
            try
            {
                _dbConnect.SetCommandStoredProcedure("ReportShipmentStatus");
                _dbConnect.AddInputParameter("DateIn", System.Data.SqlDbType.NVarChar, DateIn);

                var result = _dbConnect.ExecuteToList<ShipmentStatus>();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
