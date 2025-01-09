using RombiBack.Entities.ROM.ENTEL_RETAIL.Models.Bundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RombiBack.Services.ROM.ENTEL_RETAIL.MGM_Mantenimiento.MGM_Bundle
{
    public interface IBundleServices
    {
        Task<List<Bundle>> GetBundles(int idcodigo);
         Task UpdateBundle(int idcodigo, string estado);

    }
}
