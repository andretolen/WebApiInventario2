using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiInventario.Helper;
using WebApiInventario.Models;

namespace WebApiInventario.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class InventarioController : ApiController
    {
        public Dictionary<int, Inventario> res;      

        public MessengerService messengerService = null;


        public InventarioController()
        {
            messengerService = new MessengerService();
        }
       

        [HttpGet]
        [Route("api/inventario/AllInventarios")]
        public IEnumerable<Inventario> GetItems()
        {            
            messengerService.ExpireElement(Datos.possibleDestinations);            

            return Datos.possibleDestinations.OrderBy(x => x.IdInventario);
        }

        [HttpGet]
        [Route("api/inventario/GetItemsExpired")]
        public IList<MSMQMessage> GetItemsExpired()
        {
            return messengerService.ItemsExpired();            
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Inventario inventario = Datos.possibleDestinations.Where(x => x.IdInventario == id).FirstOrDefault();

            if (inventario != null)
            {
                return NotFound();
            }

            return Ok(inventario);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/inventario")]
        public IHttpActionResult Post([FromBody] InventarioDTO inventario)
        {
            if (inventario != null)
            {
                var Idultimo = Datos.possibleDestinations.OrderByDescending(x => x.IdInventario).Select(x => x.IdInventario).FirstOrDefault();

                Inventario newInventario = new Inventario()
                {
                    IdInventario = Idultimo + 1,
                    NombreProducto = inventario.NombreProducto,
                    CodigoProducto = inventario.CodProducto,
                    DescripcionProducto = inventario.DescripcionProducto,
                    TipoProducto = inventario.TypeProducto,
                    Cantidad = inventario.Cantidad,
                    PrecioProducto = inventario.PrecioProducto,
                    FechaCaducidad = DateTime.ParseExact(inventario.FechaCaducidad, "dd/MM/yyyy", null)
                };

                Datos.possibleDestinations.Add(newInventario);             

                return Ok(HttpStatusCode.Created);
            }

            return BadRequest();
        }
       
        [HttpPut]
        [Route("api/inventario")]
        public IHttpActionResult Put(InventarioDTO inventario)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var existingStudent = Datos.possibleDestinations.Where(s => s.IdInventario == inventario.IdInventario).FirstOrDefault();

            if (existingStudent != null)
            {
                existingStudent.IdInventario = inventario.IdInventario;
                existingStudent.NombreProducto = inventario.NombreProducto;                
                existingStudent.DescripcionProducto = inventario.DescripcionProducto;
                existingStudent.TipoProducto = inventario.TypeProducto;
                existingStudent.Cantidad = inventario.Cantidad;
                existingStudent.PrecioProducto = inventario.PrecioProducto;
                existingStudent.FechaCaducidad = DateTime.ParseExact(inventario.FechaCaducidad, "dd/MM/yyyy", null);
            }
            else
            {
                return NotFound();
            }

            return Ok();

        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = Datos.possibleDestinations.Where(s => s.IdInventario == id).FirstOrDefault();

            if (existingStudent != null)
            {
                Datos.possibleDestinations.Remove(existingStudent);

                messengerService.SendMessage(id);
                
            }
            else
            {
                return NotFound();
            }

            return Ok(HttpStatusCode.OK);

        }        

    }
}