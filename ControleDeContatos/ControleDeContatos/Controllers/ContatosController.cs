using ControleDeContatos.Interface;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatosController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatosController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoMoldel> contatos =  _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoMoldel contato = _contatoRepositorio.ListarPorId(id);
            return View( contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoMoldel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Criar(ContatoMoldel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            _contatoRepositorio.Apagar(id);

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Alterar(ContatoMoldel contato)
        {
            _contatoRepositorio.Atulizar(contato);
            return RedirectToAction("index");
        }

    }
}
