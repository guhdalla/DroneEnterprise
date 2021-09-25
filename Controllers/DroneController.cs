using Fiap.Aula02.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Controllers
{
    public class DroneController : Controller
    {

        private static List<Drone> _banco = new List<Drone>();

        private static int index;

        public IActionResult Index()
        {
            return View(_banco);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Drone drone)
        {
            drone.Id = ++index; 
            _banco.Add(drone);
            TempData["msg"] = "Drone registrado!";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var veiculo = _banco.Find( churros => churros.Id == id);
            return View(veiculo);
        }

        [HttpPost]
        public IActionResult Editar(Drone drone)
        {
            _banco[ _banco.FindIndex(churros => churros.Id == drone.Id) ] = drone;
            TempData["msg"] = "Drone atualizado!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _banco.RemoveAt( _banco.FindIndex(churros => churros.Id == id) );
            TempData["msg"] = "Drone removido!";
            return RedirectToAction("Index");
        }

    }
}
