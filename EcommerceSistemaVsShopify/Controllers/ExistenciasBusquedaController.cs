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
        public IActionResult Grilla(string buscar,int ordenarpor,bool isAscendente = true,int? page=1)
        {
            //int? page=1;
            string valorbusqueda= string.Empty;
            if(!string.IsNullOrEmpty(buscar))
            {
                valorbusqueda = Regex.Replace(buscar,@"[^a-zA-Z0-9\s]",String.Empty);
            }
            if(page<0)
            {
                page = 1;
            }
            ExistenciasEcommerceInfoPaginacion infoPaginacion= new ExistenciasEcommerceInfoPaginacion();
            var indicepagina=(page??1)-1;
            var  tamaniopagina=50;
            string columnaorden;
            #region Ordenandocolumna
            switch(ordenarpor)
            {
                case 0:
                    if(isAscendente)
                    {
                        columnaorden = "PLM";
                    }
                    else
                    {
                        columnaorden = "PLM Desc";
                    }
                    break;
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
                        columnaorden = "NombreProducto";
                    }
                    else
                    {
                        columnaorden = "NombreProducto Desc";
                    }
                    break;
                case 3:
                    if(isAscendente)
                    {
                        columnaorden = "Existencia";
                    }
                    else
                    {
                        columnaorden = "Existencia Desc";
                    }
                    break;
                case 4:
                    if(isAscendente)
                    {
                        columnaorden = "COLECCION";
                    }
                    else
                    {
                        columnaorden = "COLECCION Desc";
                    }
                    break;
                case 5:
                    if(isAscendente)
                    {
                        columnaorden = "Temporada";
                    }
                    else
                    {
                        columnaorden = "Temporada Desc";
                    }
                    break;
                case 6:
                    if(isAscendente)
                    {
                        columnaorden = "UnidadNegocio";
                    }
                    else
                    {
                        columnaorden = "UnidadNegocio Desc";
                    }
                    break;
                case 7:
                    if(isAscendente)
                    {
                        columnaorden = "Precio_Neto";
                    }
                    else
                    {
                        columnaorden = "Precio_Neto Desc";
                    }
                    break;
                default:
                    columnaorden = "NombrePorducto";
                    break;
            }
            #endregion
            int totalLineas= _IExistenciasBusqueda.GetCantidadExistencias(valorbusqueda);
            var Existencias=_IExistenciasBusqueda.ExistenciasEcommercePaginacion(valorbusqueda,columnaorden,page,tamaniopagina).ToList();
            var ExistenciasPaginadas= new StaticPagedList<ExistenciasEcommerceModelo>(Existencias,indicepagina+1,tamaniopagina,totalLineas);

            infoPaginacion.Existencias = ExistenciasPaginadas;
            infoPaginacion.TamanioPagina = tamaniopagina;
            infoPaginacion.Buscar = valorbusqueda;
            infoPaginacion.OrdenarPor = ordenarpor;
            infoPaginacion.isAscendente = isAscendente;
            return View(infoPaginacion);

        }
        public IActionResult Index( )
        {
            return View();
        }
    }
}
