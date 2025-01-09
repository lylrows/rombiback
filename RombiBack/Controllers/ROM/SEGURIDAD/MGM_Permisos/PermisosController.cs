using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RombiBack.Entities.ROM.ENTEL_RETAIL.Models.PlanificacionHorarios;
using RombiBack.Entities.ROM.SEGURIDAD.Models.Permisos;
using RombiBack.Security.Model.UserAuth;
using RombiBack.Services.ROM.SEGURIDAD.MGM_Permisos;

namespace RombiBack.Controllers.ROM.SEGURIDAD.MGM_Permisos
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly IPermisosServices _permisosServices;

        public PermisosController(IPermisosServices permisosServices)
        {
            _permisosServices = permisosServices;
        }
        [HttpPost("GetCodigos")]
        public async Task<IActionResult> GetCodigos([FromBody] CodigosRequest request)
        {
            var codigos = await _permisosServices.GetCodigos(request);
            return Ok(codigos);
        }
        [HttpPost("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromBody]AllUsersRequest request)
        {
            var allusers = await _permisosServices.GetAllUsers(request);
            return Ok(allusers);
        }

        [HttpPost("GetModulosPermisos")]
        public async Task<IActionResult> GetModulosPermisos([FromBody] UserDTORequest request)
        {
            var allusers = await _permisosServices.GetModulosPermisos(request);
            return Ok(allusers);
        }

        [HttpGet("GetPerfiles")]
        public async Task<IActionResult> GetPerfiles()
        {

            var rpt = await _permisosServices.GetPerfiles();
            return Ok(rpt);
        }

        [HttpPost("ValidarEstructuraModulos")]
        public async Task<IActionResult> ValidarEstructuraModulos([FromBody] List<PermisosModulosRequest> turnospdv)
        {
            var turnospdvres = await _permisosServices.ValidarEstructuraModulos(turnospdv);
            return Ok(turnospdvres);
        }

    }
}
