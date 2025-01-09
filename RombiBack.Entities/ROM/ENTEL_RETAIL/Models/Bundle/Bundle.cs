using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RombiBack.Entities.ROM.ENTEL_RETAIL.Models.Bundles
{
    public class Bundle
    {
        public int? idbundle { get; set; }
        public string? codigobundle { get; set; }
        public string? nombrebundle { get; set; }
        public int? flagauthmessage { get; set; }
        public int? idcodigo { get; set; }
        public int? estado { get; set; }
        public int? usuariocreacion { get; set; }
        public DateTime? fechacreacion { get; set; }
        public int? usuariomodificacion { get; set; }
        public DateTime? fechamodificacion { get; set; }

        //PARA ENTEL RETAIL ANTES DE MIGRAR
        public int? Id { get; set; }
        public string? Descripcion { get; set; }
        //public int? Authmessage { get; set; }
        public string? Status { get; set; }





    }
}
