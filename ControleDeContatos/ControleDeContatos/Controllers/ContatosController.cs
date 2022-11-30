using ControleDeContatos.Interface;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
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
            try
            {
                if (ModelState.IsValid)
                {

                    _contatoRepositorio.Adicionar(contato);
                    TempData["messagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["messagemErro"] = $"Ops, não foi possival realizar cadastro do contato, tente novamente, detalhe do erro{erro.Message}";
                return RedirectToAction("Index");
            }
           
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["messagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["messagemErro"] = $"Ops, não foi possival apagar o contato";
                }
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                TempData["messagemErro"] = $"Ops, não foi possival apagar o contato, tente novamente, detalhe do erro{erro.Message}";
                throw;
            }
            
        }

        [HttpPost]
        public IActionResult Alterar(ContatoMoldel contato)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atulizar(contato);
                    TempData["messagemSucesso"] = "Contato alterado com sucesso com sucesso";
                    return RedirectToAction("index");
                }
                return View("Editar", contato);
            }
            catch (Exception erro)
            {

                TempData["messagemErro"] = $"Ops, não foi possival alterar cadastro, tente novamente, detalhe do erro{erro.Message}";
                return RedirectToAction("Index");
            }
        }


    }
}
