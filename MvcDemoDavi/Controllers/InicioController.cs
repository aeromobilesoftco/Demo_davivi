using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemoDavi.Svr_datamdavi;
using MvcDemoDavi.Models;

namespace MvcDemoDavi.Controllers
{
    public class InicioController : Controller
    {

        ClsDataBas cldatam = new ClsDataBas();

        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listarusu()
        {
            return View(cldatam.verusu());
        }

        // GET: Inicio/Create
        public ActionResult Guardar()
        {
            return View();
        }

        // POST: Inicio/Create
        [HttpPost]
        public ActionResult Guardar(FormCollection collection)
        {
            usuario userguarda = new usuario
            {
                idusuario = 0,
                nombres = collection["nombres"],
                fecnac = collection["fecnac"],
                sexo = collection["sexo"]
            };

            cldatam.ejecutaproc(userguarda, 2);
            return RedirectToAction("Index");
        }

        // GET: Inicio/Edit/5
        public ActionResult Editar(int id)
        {
            usuario useparam= cldatam.verusuparami(id);
            return View(useparam);
        }

        // POST: Inicio/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
        {

            usuario userguarda = new usuario
            {
                idusuario = int.Parse(collection["idusuario"]),
                nombres = collection["nombres"],
                fecnac = collection["fecnac"],
                sexo = collection["sexo"]
            };

            cldatam.ejecutaproc(userguarda, 3);

            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id, FormCollection collection)
        {
            usuario userguarda = new usuario
            {
                idusuario = id,
                nombres = collection["nombres"],
                fecnac = collection["fecnac"],
                sexo = collection["sexo"]
            };

            cldatam.ejecutaproc(userguarda, 4);
            return RedirectToAction("Index");
        }
    }
}
