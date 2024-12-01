using System.Data.Common;
using WMSAPI.Models;

namespace WMSAPI.Constant
{
    public static class MyUtilClass
    {
        public static string GETDCNAME(string dc_code)
        {
            List<WarehouseName> warehouseNames = new List<WarehouseName>()
            {
                new WarehouseName(){code="DC01",name="wmwhse1"},
                new WarehouseName(){code="DC02",name="wmwhse2"},
                new WarehouseName(){code="DC03",name="wmwhse3"},
                new WarehouseName(){code="DC04",name="wmwhse4"},
                new WarehouseName(){code="DC05",name="wmwhse5"},
                new WarehouseName(){code="DC06",name="wmwhse6"},
                new WarehouseName(){code="DC07",name="wmwhse7"},
                new WarehouseName(){code="DC08",name="wmwhse8"},
                new WarehouseName(){code="DC09",name="wmwhse9"},
                new WarehouseName(){code="DC010",name="wmwhse10"},
            };

            var result = warehouseNames.Where(o => o.code == dc_code).FirstOrDefault().name;

            return (result);
        }
    }
}
