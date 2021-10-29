using Dapper;
using EcommerceSistemaVsShopify.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSistemaVsShopify.Repository
{
    public class ExistenciaEcommerceService:IExistenciasEcommerce
    {
        public List<ExistenciasEcommerceModelo> ExistenciasEcommercePaginacion(int? pagina,int tamaño_pagina)
        {
            using(SqlConnection Con = new SqlConnection(CadenaDeConexionManager.Valor))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@NumeroPagina",pagina);
                parametro.Add("@TamañoPagina",tamaño_pagina);
                var datos= Con.Query<ExistenciasEcommerceModelo>("ExistenciasEcommercePaginado",parametro,commandType:System.Data.CommandType.StoredProcedure).ToList();
                return datos;
            }
        }

        public int GetCantidadExistencias( )
        {
            using(SqlConnection Con = new SqlConnection(CadenaDeConexionManager.Valor))
            {
                var parametro = new DynamicParameters();
                var datos=Con.Query<int>("ObtenerExistenciasConteo",parametro,commandType:System.Data.CommandType.StoredProcedure).FirstOrDefault();
                return datos;
            }
        }
    }
}
