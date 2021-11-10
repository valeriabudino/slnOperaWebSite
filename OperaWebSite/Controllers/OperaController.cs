﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperaWebSite.Data;
using OperaWebSite.Models;
using System.Data.Entity;
using System.Diagnostics;
using OperaWebSite.Filters;

namespace OperaWebSite.Controllers
{
    [MyFilterAction]
    public class OperaController : Controller
    {
        //Crear instancia del dbcontext

        private OperaDbContext context = new OperaDbContext();

        // GET: Opera o /Opera/Index
        public ActionResult Index()
        {
            //Traer todas Operas usando EF
            var operas = context.Operas.ToList();

            //el controller retorna una vista "Index" con la lista de operas
            return View("Index", operas);
        }


        //Creamos dos métodos para la inserción de la opera en la DB

        //primer create por GET para retornar la vista de registro
        [HttpGet]//El Get es implicito asi y todo lo podemos indicar
        public ActionResult Create()
        {
            //creamos la instancia con valores en las propiedades
            Opera opera = new Opera();

            //retornamos la vista "Create" que tiene el objeto opera
            return View("Create", opera);
        }

        //Segundo Create es por Post para insertar la nueva opera en la base
        //cuando el usuario en la vista Create hace click en enviar
        //Opera/Create -->POST
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", opera);
        }

        //GET
        // Opera/Detail/id
        // Opera/Detail/2
        [HttpGet]//opcional porque el default es GET
        public ActionResult Detail(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Detail", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //GET /Opera/Delete/Id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Delete", opera);
            }
            else
            {
                return HttpNotFound();
            }

        }



        // /Opera/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);

            context.Operas.Remove(opera);
            context.SaveChanges();

            return RedirectToAction("Index");

        }


        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var controller = filterContext.RouteData.Values["controller"];
        //    var action = filterContext.RouteData.Values["action"];
        //    Debug.WriteLine("Controller: " + controller + " Action: " + action + " Paso por OneActionExecuting");
        //}

        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    var controller = filterContext.RouteData.Values["controller"];
        //    var action = filterContext.RouteData.Values["action"];
        //    Debug.WriteLine("Controller: " + controller + " Action: " + action + " Paso por OneActionExecuting");
        //}

    }


}