using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInventario.Models
{
    public class Datos
    {
        public static List<Inventario> possibleDestinations =
          new List<Inventario>{
                new Inventario {
                    IdInventario = 1,
                    NombreProducto = "LatasCarne",
                    CodigoProducto = "LT0258",
                    DescripcionProducto = "Latas de Carne marca Dia",
                    TipoProducto = "Latas",
                    Cantidad = 10,
                    PrecioProducto = 5.10M,
                    FechaCaducidad = DateTime.ParseExact("25/10/2020", "dd/MM/yyyy", null)
                },
                new Inventario
                {
                    IdInventario = 2,
                    NombreProducto = "LitronaMahou",
                    CodigoProducto = "BC002554",
                    DescripcionProducto = "Botellas Cerveza Mahou",
                    TipoProducto = "Botellas",
                    Cantidad = 20,
                    PrecioProducto = 1.10M,
                    FechaCaducidad = DateTime.ParseExact("21/05/2030", "dd/MM/yyyy", null)
                },
                new Inventario
                {
                    IdInventario = 3,
                    NombreProducto = "LatasCarne",
                    CodigoProducto = "LT0258",
                    DescripcionProducto = "Latas de Carne marca Dia",
                    TipoProducto = "Latas",
                    Cantidad = 10,
                    PrecioProducto = 5.10M,
                    FechaCaducidad = DateTime.ParseExact("25/10/2020", "dd/MM/yyyy", null)
                },
                new Inventario
                {
                    IdInventario = 4,
                    NombreProducto = "LitronaMahou",
                    CodigoProducto = "BC002554",
                    DescripcionProducto = "Botellas Cerveza Mahou",
                    TipoProducto = "Botellas",
                    Cantidad = 20,
                    PrecioProducto = 1.10M,
                    FechaCaducidad = DateTime.ParseExact("21/05/2030", "dd/MM/yyyy", null)
                },
                new Inventario
                {
                    IdInventario = 5,
                    NombreProducto = "FlanCafeCaramelo",
                    CodigoProducto = "FCC589741",
                    DescripcionProducto = "Flan de Cafe con Caramelo marca DIA",
                    TipoProducto = "Postre",
                    Cantidad = 30,
                    PrecioProducto = 1.30M,
                    FechaCaducidad = DateTime.ParseExact("20/09/2020", "dd/MM/yyyy", null)
                },
                new Inventario
                {
                    IdInventario = 6,
                    NombreProducto = "RefrescoMaracuyaDonSimon",
                    CodigoProducto = "RMDM0012",
                    DescripcionProducto = "Botella de Refresco de Maracuya marca Don Simon",
                    TipoProducto = "Botella de Refresco",
                    Cantidad = 50,
                    PrecioProducto = 1.50M,
                    FechaCaducidad = DateTime.ParseExact("10/05/2021", "dd/MM/yyyy", null)
                }
          };


        

        
        
    }
}