using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RombiBack.Services.ROM.ENTEL_RETAIL.MGM_Mantenimiento.MGM_Bundle;

namespace RombiBack.Controllers.ROM.ENTEL_RETAIL.MGM_Mantenimiento.MGM_Bundle
{
    [Route("api/[controller]")]
    [ApiController]
    public class BundleController : ControllerBase
    {
        private readonly IBundleServices _bundleServices;

        public BundleController(IBundleServices bundleServices)
        {
            _bundleServices = bundleServices;
        }


        [HttpGet("GetBundles")]
        public async Task<IActionResult> GetBundles(int idcodigo)
        {

            var accrespuesta = await _bundleServices.GetBundles(idcodigo);
            return Ok(accrespuesta);
        }

        [HttpPost("PutBundle")]
        public  Task PutBundle(int idcodigo, string estado)
        {

            var accrespuesta =  _bundleServices.UpdateBundle(idcodigo, estado);
            return accrespuesta;
        }
    }
}
