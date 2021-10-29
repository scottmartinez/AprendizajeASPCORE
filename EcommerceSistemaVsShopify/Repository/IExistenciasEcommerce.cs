using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSistemaVsShopify.Repository
{
    public interface IExistenciasEcommerce
    {
        int GetCantidadExistencias( );
        int GetCantidadExistencias(string buscar);
        List<Models.ExistenciasEcommerceModelo> ExistenciasEcommercePaginacion(int? pagina,int tamaño_pagina);
        List<Models.ExistenciasEcommerceModelo> ExistenciasEcommercePaginacion(string buscar,string ordenarpor,int? pagina,int tamanio_pagina);

    }
}
