using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperaWebSite.Models;
using OperaWebSite.Data;

namespace OperaWebSite.Controllers
{
    public class EmpleadoController : Controller
    {
        OperaDbContext context = new OperaDbContext();
        // GET: Empleado
        public ActionResult Index()
        {
            var empleado = context.Empleados.ToList();
            return View("Index", empleado);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Empleado empleado = new Empleado();
            return View("Create", empleado);
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", empleado);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Empleado empleado= context.Empleados.Find(id);

            if (empleado != null)
            {
                return View("Delete", empleado);
            }
            else
            {
                return HttpNotFound();
            }

        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = context.Empleados.Find(id);

            context.Empleados.Remove(empleado);
            context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}