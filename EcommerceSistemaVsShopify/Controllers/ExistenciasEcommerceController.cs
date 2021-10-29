using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using EcommerceSistemaVsShopify.Models;
using System.Data;
using EcommerceSistemaVsShopify.Repository;
using X.PagedList;

namespace EcommerceSistemaVsShopify.Controllers
{

    public class ExistenciasEcommerceController:Controller
    {
        private readonly IConfiguration configuracion;
        IExistenciasEcommerce _IExistenciasEcommerce;
        public ExistenciasEcommerceController(IConfiguration config, IExistenciasEcommerce iexistenciasEcommerce)
        {
            configuracion = config;
            _IExistenciasEcommerce = iexistenciasEcommerce;
        }

        [HttpGet]
        public IActionResult EcommerceExistencia(int? pagina=1)
        {
            ExistenciasEcommerceInfoPaginacion informacionpaginacion= new ExistenciasEcommerceInfoPaginacion();
            if(pagina<0)
            {
                pagina = 1;

            }
            var indicepagina=(pagina??1)-1;

            int tamaño_pagina=50;
            int totalcantidadexistencias=_IExistenciasEcommerce.GetCantidadExistencias();

            var ExistenciasEcommerce=_IExistenciasEcommerce.ExistenciasEcommercePaginacion(pagina,tamaño_pagina).ToList();

            var existenciasEcommerceListaPaginada= new StaticPagedList<Models.ExistenciasEcommerceModelo>(ExistenciasEcommerce,indicepagina+1,tamaño_pagina,totalcantidadexistencias);

            informacionpaginacion.Existencias = existenciasEcommerceListaPaginada;

            informacionpaginacion.TamanioPagina = pagina;

            return View("ExistenciasBC",informacionpaginacion);

        }
        public IActionResult Index(DataSourceLoadOptions loadOptions)
        {
            List<Models.ExistenciasEcommerceModelo> ExistenciasEcommerce= new List<Models.ExistenciasEcommerceModelo>();
            try
            {
                SqlConnection Conexion= new SqlConnection(configuracion.GetConnectionString("BaseDatosVICOSA"));
                Conexion.Open();
                string consulta= "SELECT ee.PLM,ee.CodigoProducto,ee.NombreProducto,ee.Existencia,ee.Coleccion,ee.Temporada,        ee.UnidadNegocio,ee.Precio_Neto FROM dbo.ExistenciasEcommerce AS ee";
                SqlCommand comando= new SqlCommand(consulta,Conexion);
                SqlDataReader dataReader= comando.ExecuteReader();

                while(dataReader.Read())
                {
                    Models.ExistenciasEcommerceModelo E= new Models.ExistenciasEcommerceModelo();
                    E.PLM = dataReader.GetValue(0).ToString();
                    E.NombreProducto = dataReader.GetValue(1).ToString();
                    E.CodigoProducto = dataReader.GetValue(2).ToString();
                    E.Existencia = Convert.ToDouble(dataReader.GetValue(3));
                    E.Coleccion = dataReader.GetValue(4).ToString();
                    E.Temporada = Convert.ToDouble(dataReader.GetValue(5));
                    E.UnidadNegocio = dataReader.GetValue(6).ToString();
                    E.Precio_Neto = Convert.ToDecimal(dataReader.GetValue(7));
                    ExistenciasEcommerce.Add(E);

                }

            }
            catch(Exception)
            {

                throw;
            }
            return View("ExistenciasEcommerce",ExistenciasEcommerce);
        }

    }
}
