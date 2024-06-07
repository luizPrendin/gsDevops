using GS.Models;
using GS.Persistencia.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio<Usuario> _repositorioUsuarios;


        public HomeController(IRepositorio<Usuario> repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;

        }
        public IActionResult Index()
        {
            ViewBag.NomeSolucao = "EcoBlue Solution";
            ViewBag.ListaUsuarios = _repositorioUsuarios.GetAll();
            return View();
        }
    }
}
