
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGutierrezCRUDTelefono.Controllers
{
    public class TelefonoController : Controller
    {
        // GET: Telefono
        public ActionResult GetAll()
        {
            ML.Telefono telefono = new ML.Telefono();
            ML.Result result = BL.Telefono.GetAll();

            if (result.Correct)
            {
                telefono.Telefonos = result.Objects;
                return View(telefono);
            }
            else
            {
                return View(telefono);
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdTelefono)
        {
            ML.Telefono telefono = new ML.Telefono();
            ML.Result resultTelefono = BL.Telefono.GetAll();
            if (resultTelefono.Correct)
            {
                telefono.Telefonos = resultTelefono.Objects;
            }

            if (IdTelefono == null)
            {
                return View(telefono);
            }
            else
            {
                ML.Result result = BL.Telefono.GetById(IdTelefono.Value);

                if (result.Correct)
                {

                    telefono = (ML.Telefono)result.Object;
                    telefono.Telefonos = resultTelefono.Objects;
                    return View(telefono);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la información del telefono";
                    return View("Modal");
                }
            }

        }
        [HttpPost]
        public ActionResult Form(ML.Telefono telefono)
        {
            ML.Result result = new ML.Result();

            if (telefono.IdTelefono != null)
            {
                result = BL.Telefono.Update(telefono);
                ViewBag.Message = "Se ha modificado el registro";
            }
            else
            {
                result = BL.Telefono.Add(telefono);
                ViewBag.Message = "Se ha agregado el registro";
            }
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
            }
        }
        public ActionResult Delete(int IdTelefono)
        {
            ML.Result result = BL.Telefono.Delete(IdTelefono);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar el registro seleccionado" + result.ErrorMessage;
                return PartialView("Modal");
            }

        }

    }

}
