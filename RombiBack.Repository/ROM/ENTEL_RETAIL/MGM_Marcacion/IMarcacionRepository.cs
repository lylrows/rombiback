﻿using RombiBack.Entities.ROM.ENTEL_RETAIL.Models.PlanificacionHorarios;
using RombiBack.Security.Model.UserAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RombiBack.Repository.ROM.ENTEL_RETAIL.MGM_Marcacion
{
    public interface IMarcacionRepository
    {
         Respuesta PostEmpleadoAsistenciaMarcacion(string docusuario, DateTime fechamarcacion);
         UserDataDTOResponse GetUsuarioMarcacion(string docusuario);

    }
}