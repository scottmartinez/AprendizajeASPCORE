using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace EcommerceSistemaVsShopify.Models
{
    public class ExistenciasEcommerceInfoPaginacion
    {
        public int? TamanioPagina;
        //public string OrdenarPor {get; set;}
        //public string Buscar { get; set; }
        public StaticPagedList<ExistenciasEcommerceModelo> Existencias { get; set; }

    }
}
