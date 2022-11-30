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

        public ContatoMoldel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
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

        public ContatoMoldel Atulizar(ContatoMoldel contato )
        {
            ContatoMoldel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("houve um erro na atualização do conta");
            
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Update(contatoDB);

            _bancoContext.SaveChanges();

            return contatoDB;

            
        }

        public bool Apagar(int id)
        {
            ContatoMoldel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("houve um erro na deleção do conta");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
