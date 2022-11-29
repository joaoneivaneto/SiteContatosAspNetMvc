using ControleDeContatos.Interface;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public List<ContatoMoldel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoMoldel Adicionar(ContatoMoldel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

       
    }
}
