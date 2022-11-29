using ControleDeContatos.Models;

namespace ControleDeContatos.Interface
{
    public interface IContatoRepositorio 
    {
        List<ContatoMoldel> BuscarTodos();
        ContatoMoldel Adicionar(ContatoMoldel contato);
        

    }
}
