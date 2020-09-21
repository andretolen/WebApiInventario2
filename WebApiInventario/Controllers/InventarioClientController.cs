using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiInventario.Models;

namespace WebApiInventario.Controllers
{
    public class InventarioClientController : Controller
    {
        // GET: InventarioClient
        public ActionResult Index()
        {          
            return View(Datos.possibleDestinations);
        }        

        // GET: InventarioClient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventarioClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventarioClient/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InventarioClient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventarioClient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InventarioClient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventarioClient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
