using WMSAPI.Models;

namespace WMSAPI.Services.Interfaces
{
    public interface ISpd
    {
        public ResponseAPI GetMaster(string searchGP);
    }
}
