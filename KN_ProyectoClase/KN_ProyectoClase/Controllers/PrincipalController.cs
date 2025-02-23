using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//La vista llama al controlador y lo que le envia o lo que recibe es un modelo
namespace KN_ProyectoClase.Controllers
{
    public class PrincipalController : Controller
    {
        [HttpGet]   //Abrir y mostrar la vista. Siempre lo llama un hipervinculo
        public ActionResult Inicio()
        {  
            return View();
        }

        [HttpGet]

        public ActionResult IniciarSesion()
        {
            return View();
        }

    }
}