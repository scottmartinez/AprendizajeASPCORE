using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSistemaVsShopify.Repository
{
    public interface IExistenciasEcommerce
    {
        int GetCantidadExistencias( );
        List<Models.ExistenciasEcommerceModelo> ExistenciasEcommercePaginacion(int? pagina,int tamaño_pagina);
    }
}
