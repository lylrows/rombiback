﻿using RombiBack.Entities.ROM.ENTEL_RETAIL.Models.Allocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RombiBack.Entities.ROM.ENTEL_RETAIL.Models.PlanificacionHorarios
{
    public class Respuesta
    {
        public string? Mensaje { get; set; }
        public string? CodigoBundle { get; set; }
        public string? Nombrepdffirma { get; set; }
        public string? NombreModulos { get; set; }
        public string? NombrePerfil { get; set; }

        public bool? Success { get; set; } // Indicates if the operation was successful
        public string? Message { get; set; } // Contains any message (like error or success)
        public List<string>? Errors { get; set; } // List of error messages if any
        public int? InsertedRecordsCount { get; set; } //
        public Roles Data { get; set; } // Datos relacionados con la asignación

    }
}
