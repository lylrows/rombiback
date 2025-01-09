﻿using RombiBack.Entities.ROM.ENTEL_RETAIL.Models;
using RombiBack.Entities.ROM.ENTEL_RETAIL.Models.Allocation;
using RombiBack.Entities.ROM.ENTEL_RETAIL.Models.PlanificacionHorarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RombiBack.Services.ROM.ENTEL_RETAIL.MGM_Allocation
{
    public interface IAllocationServices
    {
        List<Roles> GetAllRolPromotor(string usuario, int idemppaisnegcue, string tipoperiodo);
        List<Roles> GetRolUsuarioPDV(string usuario, int idemppaisnegcue, string tipoperiodo);
        List<Respuesta> ValidarBotonRegistroVentas(string ususario , int idemppaisnegcue);

        List<Roles> GetRolTipoFuncionalidad(int idemppaisnegcue);
        List<Roles> GetRolTipoEstado(int idemppaisnegcue);
        List<Roles> GetRolTipoTrabajo(int idemppaisnegcue);
        List<Roles> GetRolTipoLicencia(int idemppaisnegcue);
        List<Roles> GetRolPromotorDocUsuario(string usuario, int idemppaisnegcue, string tipoperiodo, string usuarioperfil);
        List<Roles> GetRolPdv(int idemppaisnegcue);

        List<Respuesta> PostRoles(List<Roles> roles);
        List<Respuesta> PutRoles(List<Roles> roles);

    }
}
