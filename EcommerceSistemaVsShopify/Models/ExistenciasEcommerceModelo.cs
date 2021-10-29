using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSistemaVsShopify.Models
{
    public class ExistenciasEcommerceModelo
    {
        [DisplayName("PLM PRODUCTO")]
        public string PLM { get; set; }
        [DisplayName("CODIGO PRODUCTO")]
        public string CodigoProducto { get; set; }
        [DisplayName("NOMBRE PRODUCTO")]
        public string NombreProducto { get; set; }
        [DisplayName("EXISTENCIA")]
        public double Existencia { get; set; }
        [DisplayName("COLECCIÓN")]
        public string Coleccion { get; set; }
        [DisplayName("TEMPORADA")]
        public double Temporada { get; set; }
        [DisplayName("UNIDAD NEGOCIO")]
        public string UnidadNegocio { get; set; }
        [DisplayName("PRECIO NETO")]
        public decimal Precio_Neto { get; set; }

    }
}
