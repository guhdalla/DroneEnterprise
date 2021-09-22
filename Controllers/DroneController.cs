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
        //Armazenar os veículos na memória (simular o DB)
        private static List<Drone> _banco = new List<Drone>();
        //Atributo para armzenar o index dos veículos
        private static int index;

        //URLs: veiculo/index ou /veiculo
        public IActionResult Index()
        {
            //Enviar a lista de veículos para a view
            return View(_banco);
        }

        [HttpGet] //Abrir a página de cadastro, URL: /veiculo/cadastrar
        public IActionResult Cadastrar()
        {
//CarregarMarcas();
            return View();
        }

        //Carrega o select das marcas dos veículos
//private void CarregarMarcas()
//{
//var lista = new List<string>(new String[] { "Ford", "Fiat", "Pegeout", "Hyundai", "Toyota" });
////Enviar a lista de marcas para carregar o Select
//ViewBag.marcas = new SelectList(lista);
// }

        [HttpPost] //Recupera os dados do formulário e "cadastra" no banco
        public IActionResult Cadastrar(Drone drone)
        {
            drone.Id = ++index; 
            //Adicionar o veículo na lista
            _banco.Add(drone);
            //Mensagem de sucesso
            TempData["msg"] = "Drone registrado!";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet] //Abre a página com o formulário HTML preenchido com os dados do veículo
        public IActionResult Editar(int id)
        {
//CarregarMarcas();
            //Pesquisar o veículo pelo Id
            var veiculo = _banco.Find( churros => churros.Id == id);
            //Enviar o veículo para a view
            return View(veiculo);
        }

        [HttpPost] //Atualiza o veículo 
        public IActionResult Editar(Drone drone)
        {
            //Atualiza o veiculo na lista (pesquisa pela posição do veículo e substitui o veiculo)
            _banco[ _banco.FindIndex(churros => churros.Id == drone.Id) ] = drone;
            //Mensagem de sucesso
            TempData["msg"] = "Drone atualizado!";
            //Redirect para a listagem
            return RedirectToAction("Index");
        }

        [HttpPost] //Receber o Id do veículo para remover
        public IActionResult Remover(int id)
        {
            //Remove o veiculo da lista pelo index
            _banco.RemoveAt( _banco.FindIndex(churros => churros.Id == id) );
            //Mensagem de sucesso
            TempData["msg"] = "Drone removido!";
            //Redirecionar para a listagem
            return RedirectToAction("Index");
        }

    }
}
