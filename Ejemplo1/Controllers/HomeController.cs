using Ejemplo1.Models;
using Ejemplo1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Controllers
{
    public class HomeController:Controller
    {


        //public string Index()
        //{
        //    return amigoAlmacen.dameDatosAmigo(1).email;
        //}

        private IAmigoAlmacen amigoAlmacen;
        public HomeController(IAmigoAlmacen AmigoAlmacen)
        {
            amigoAlmacen = AmigoAlmacen;
        }



        //public JsonResult Details()
        //{
        //    Amigo modelo = amigoAlmacen.dameDatosAmigo(1);
        //    return Json(modelo);
        //}

        ////Mostrar un dato en especifico
        //public ViewResult Index()
        //{
        //    Amigo modelo = amigoAlmacen.dameDatosAmigo(2);
        //    return View(modelo);
        //}



        //public ViewResult Details()
        //{
        //    // 1. Uso del view Data 
        //    Amigo amigo = amigoAlmacen.dameDatosAmigo(2);
        //    ViewData["Cabecera"] = "Lista Amigos";
        //    ViewData["Amigo"] = amigo;

        //    //2. Uso del view bag
        //    ViewBag.titulo = "Lista de amigos VB";
        //    ViewBag.Amigo = amigo;

        //    return View(amigo);
        //}

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index(int id)
        {
            var modelo = amigoAlmacen.DameTodosLosAmigos();
            return View(modelo);
        }

        [Route("Home/Details/{id}")]

        //Objetos personalizados 
        public ViewResult Details(int? id)
        {
            
            DetallesView detalles = new DetallesView();
            detalles.amigo = amigoAlmacen.dameDatosAmigo(id?? 3);
            detalles.Titulo = "Lista de amigos";
            detalles.SubTitulo = "Compañeros";


            return View(detalles);
        }


        [Route("Home/Create")]
        [HttpGet]
        public ViewResult Create()
        {
            
            return View();
        }

        [Route("Home/Create")]
        [HttpPost]
        public IActionResult Create(Amigo a)
        {
            if(ModelState.IsValid)
            { 

            Amigo amigo = amigoAlmacen.nuevo(a);

            return RedirectToAction("details", new { id = amigo.Id });

            }

            return View();
        }
    }
}
