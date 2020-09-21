using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInventario.Models
{
    public class Inventario
    {
        public int IdInventario { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string TipoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioProducto { get; set; }
        public DateTime FechaCaducidad { get; set; }
        
    }
}