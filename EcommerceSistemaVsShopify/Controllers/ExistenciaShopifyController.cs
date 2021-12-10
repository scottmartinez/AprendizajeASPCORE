using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceSistemaVsShopify.Models;
using Microsoft.AspNetCore.Mvc;
using ShopifySharp;
using ShopifySharp.Filters;

namespace EcommerceSistemaVsShopify.Controllers
{
    public class ExistenciaShopifyController:Controller
    {


        public async Task<IActionResult> GetList([FromQuery]string page_info,int cantidad_items=50)
        {


            int LimiteporPagina= cantidad_items;
            ListFilter<Product> filtropagina;
            if(!string.IsNullOrEmpty(page_info))
            {
                filtropagina = new ListFilter<Product>(page_info,LimiteporPagina);
            }
            else
            {
                filtropagina = new ProductListFilter
                {
                    Limit = LimiteporPagina
                };
            }
            var servicioProducto= new ProductService(CadenaDeConexionManager.UrlTienda,CadenaDeConexionManager.Contrasenia);
            var productos=await servicioProducto.ListAsync(filtropagina);


            return View(productos);
        }

        public IActionResult Index( )
        {
            ViewBag.Msg = "Mensaje Index "+this.GetType().ToString();
            return View();
        }

    }
}
