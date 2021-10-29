using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceSistemaVsShopify.Repository;
using System.Text.RegularExpressions;
using EcommerceSistemaVsShopify.Models;
using X.PagedList;

namespace EcommerceSistemaVsShopify.Controllers
{

    public class ExistenciasBusquedaController:Controller
    {
        IExistenciasEcommerce _IExistenciasBusqueda;
        public ExistenciasBusquedaController(IExistenciasEcommerce IExistenciasBusqueda)
        {
            _IExistenciasBusqueda = IExistenciasBusqueda;
        }
        public IActionResult Grilla(string buscar,int ordenar_por,bool isAscendente = true, int? pagina=1)
        {
            string valorbusqueda= string.Empty;
            if(!string.IsNullOrEmpty(buscar))
            {
                valorbusqueda = Regex.Replace(buscar,@"[^a-zA-Z0-9\s]",String.Empty);
            }
            if(pagina<0)
            {
                pagina = 1;
            }
            ExistenciasEcommerceInfoPaginacion infoPaginacion= new ExistenciasEcommerceInfoPaginacion();
            var indicepagina=(pagina??1)-1;
            var  tamaniopagina=50;
            string columnaorden;
            #region Ordenandocolumna
            switch(ordenar_por)
            {
                case 1:
                    if(isAscendente)
                    {
                        columnaorden = "CodigoProducto";
                    }
                    else
                    {
                        columnaorden = "CodigoProducto Desc";
                    }
                    break;
                case 2:
                    if(isAscendente)
                    {
                        columnaorden = "PLM";
                    }
                    else
                    {
                        columnaorden = "PLM Desc";
                    }
                    break;
                case 3:
                    if(isAscendente)
                    {
                        columnaorden = "COLECCION";
                    }
                    else
                    {
                        columnaorden = "COLECCION Desc";
                    }
                    break;
                default:
                    columnaorden = "CodigoProducto";
                    break;
            }
            #endregion
            int totalLineas= _IExistenciasBusqueda.GetCantidadExistencias(valorbusqueda);
            var Existencias=_IExistenciasBusqueda.ExistenciasEcommercePaginacion(valorbusqueda,columnaorden,pagina,tamaniopagina).ToList();
            var ExistenciasPaginadas= new StaticPagedList<ExistenciasEcommerceModelo>(Existencias,indicepagina+1,tamaniopagina,totalLineas);

            infoPaginacion.Existencias = ExistenciasPaginadas;
            infoPaginacion.TamanioPagina = tamaniopagina;
            infoPaginacion.Buscar = valorbusqueda;
            infoPaginacion.OrdenarPor = ordenar_por;
            infoPaginacion.isAscendente = isAscendente;
            return View(infoPaginacion);

        }
        public IActionResult Index( )
        {
            return View();
        }
    }
}
