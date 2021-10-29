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
        public int OrdenarPor { get; set; }
        public string Buscar { get; set; }
        public bool isAscendente { get; set; }
        public StaticPagedList<ExistenciasEcommerceModelo> Existencias { get; set;}

    }
}
