using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMSAPI.Models;
using WMSAPI.Services.Interfaces;

namespace WMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class spdmasterController : ControllerBase
    {
        private readonly ISpd _spd;

        public spdmasterController(ISpd spd)
        {
            _spd = spd;
        }
        [HttpGet]
        public ResponseAPI Get()
        {
            var response = _spd.GetMaster("*");

            return response;
        }
        [HttpGet("{searchGP}")]
        public ResponseAPI Get(string searchGP)
        {
            var response = _spd.GetMaster(searchGP);

            return response;
        }
    }
}
