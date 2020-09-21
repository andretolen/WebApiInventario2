using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiInventario.Controllers;
using WebApiInventario.Models;
using System.Web.Http;
using System.Net;
using System.Web.Http.Results;
using System.Linq;

namespace WebApiInventario.Test
{
    /// <summary>
    /// Descripción resumida de TestInventarioController
    /// </summary>
    [TestClass]
    public class TestInventarioController
    {
        public TestInventarioController()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion       


        [TestMethod]
        public void GetItems_ShouldReturnAllInventarios()
        {
            var inventarioController = new InventarioController();            

            var actionResult = inventarioController.GetItems();

            var response = actionResult as IOrderedEnumerable<Inventario>;            

            Assert.AreEqual(response.ToList().Count, 6);
            Assert.IsTrue(true);
            Assert.IsNotNull(response);                               

        }

        [TestMethod]
        public void DeleteReturnsOk()
        {
            // Arrange
            var inventarioController = new InventarioController();

            // Act
            IHttpActionResult actionResult = inventarioController.Delete(1);
            var deletedResult = ((OkNegotiatedContentResult<HttpStatusCode>)actionResult).Content;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, deletedResult);
        }

        [TestMethod]
        public void PostMethodSetsLocationHeader()
        {
            // Arrange
            var inventarioController = new InventarioController();

            // Act
            IHttpActionResult actionResult = inventarioController.Post(new InventarioDTO { NombreProducto = "Product1", CodProducto = "CodProducto1", Cantidad = 10, DescripcionProducto = "DescripcionProducto1", FechaCaducidad = "22/10/2020", PrecioProducto = 12.14M, TypeProducto = "TipoProducto" }); ;           

            var createdResult = ((OkNegotiatedContentResult<HttpStatusCode>)actionResult).Content;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.Created, createdResult);
            
        }

    }
}
