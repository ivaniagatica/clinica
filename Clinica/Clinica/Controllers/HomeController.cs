using Clinica.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Clinica.Datos;



namespace Clinica.Controllers
{
    public class HomeController : Controller

    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult encuesta()
        {
            return View();
        }
        public IActionResult inventario()
        {
            return View();
        }


        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult agregarcita()
        {
            var olista = _ContactoDatos.listar();
            return View(olista);
        }

        public IActionResult Guardar() {
            //metodo devuelve a la vista
            
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(AsignarCitas ocitas)
        {
            //metodo recibe el objeto en la BD
            
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.guardar(ocitas);

            if (respuesta)
                return RedirectToAction("agregarcita");
            else 
            return View();
        }
        public IActionResult Editar(int Idcitas)
        {
            //metodo devuelve a la vista
            var ocitas = _ContactoDatos.Obtener(Idcitas);
            return View(ocitas);
        }

        [HttpPost]
        public IActionResult Editar(AsignarCitas ocitas)
        {
            //metodo recibe el objeto en la BD

            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.editar(ocitas);

            if (respuesta)
                return RedirectToAction("agregarcita");
            else
                return View();
        }


        public IActionResult Eliminar(int Idcitas)
        {
            //metodo devuelve a la vista
            var ocitas = _ContactoDatos.Obtener(Idcitas);
            return View(ocitas);
        }

        [HttpPost]
        public IActionResult Eliminar(AsignarCitas ocitas)
        {
            //metodo recibe el objeto en la BD

           

            var respuesta = _ContactoDatos.eliminar(ocitas.Idcitas);

            if (respuesta)
                return RedirectToAction("agregarcita");
            else
                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}