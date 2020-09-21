using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInventario.Models
{
    public class InventarioDTO
    {
        public int IdInventario { get; set; }
        public string NombreProducto { get; set; }
        public string CodProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string TypeProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioProducto { get; set; }
        public string FechaCaducidad { get; set; }
    }
}