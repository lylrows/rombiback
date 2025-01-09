﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RombiBack.Entities.TAWA.SEGURIDAD.Models.Permisos
{
    public class PermisosModulosRequestTawa
    {
        public int? idcodmod { get; set; }
        public int? idcodmodsubmod { get; set; }
        public int? idcodmodsubmoditemmod { get; set; }
        public int? idperfiles { get; set; }
        public string? usuario { get; set; }
        public int? idempresa { get; set; }
        public int? idpais { get; set; }
        public int? idnegocio { get; set; }
        public int? idcuenta { get; set; }
        public int? estado { get; set; }
        public int? checks { get; set; }
        public string? usuario_creacion { get; set; }
    }
}
