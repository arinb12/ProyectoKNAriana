using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KN_ProyectoClase.BaseDatos;
using KN_ProyectoClase.Models;
//La vista llama al controlador y lo que le envia o lo que recibe es un modelo
namespace KN_ProyectoClase.Controllers
{
    public class PrincipalController : Controller
    {

        #region RegistrarCuenta

        [HttpGet]//Abrir y mostrar la vista. Siempre lo llama un hipervinculo

        public ActionResult RegistrarCuenta()
        {
            return View();
        }

        [HttpPost]//Despues de un submit button

        public ActionResult RegistrarCuenta(UsuarioModel model)
        {
            //BD
            //EF usando LinQ
            using (var context = new KN_DBEntities())
            {
                //Usuario tabla = new Usuario();
                //tabla.Identificacion = model.Identificacion;
                //tabla.Contrasenna = model.Contrasenna;
                //tabla.Nombre = model.Nombre;
                //tabla.Correo = model.Correo;
                //.Estado = true;
                //tabla.IdPerfil = 2;

                //context.Usuario.Add(tabla);
                //var result = context.SaveChanges();

                //EF usando Procedimientos Almacenados
                var result = context.RegistrarCuenta(model.Identificacion, model.Contrasenna, model.Nombre, model.Correo);

                if(result > 0)
                    return RedirectToAction("IniciarSesion", "Principal");
                else
                {
                    ViewBag.Mensaje = "Su información no se ha podido registrar correctamente";
                    return View();
                }

            }

        }
        #endregion

        #region IniciarSesion

        [HttpGet]

        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(UsuarioModel model)
        {
            //EF usando LinQ
            using (var context = new KN_DBEntities())
            {

                //EF usando LinQ
                //var info = context.Usuario.
                //Where(x => x.Identificacion == model.Identificacion
                //&& x.Contrasenna == model.Contrasenna
                //&& x.Estado == true).FirstOrDefault();

                //EF usando Procedimientos Almacenados
                  var info = context.IniciarSesion(model.Identificacion, model.Contrasenna).FirstOrDefault();

                if (info != null)
                {
                    Session["NombreUsuario"] = info.NombreUsuario;
                    Session["NombrePerfilUsuario"] = info.NombrePerfil;
                    Session["IdPerfilUsuario"] = info.IdPerfil;
                    return RedirectToAction("Inicio","Principal");
                }
                else
                {
                    ViewBag.Mensaje = "Su información no se ha podido validar correctamente";
                    return View();
                }
            }

        }

        #endregion


        [HttpGet]   //Abrir y mostrar la vista. Siempre lo llama un hipervinculo
        public ActionResult Inicio()
        {  
            return View();
        }


        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Inicio","Principal");
        }


        [HttpGet]

        public ActionResult RecuperarContrasenna()
        {
            return View();
        }

        //PENDIENTE POST RECUPERAR CONTRASENA

    }
}