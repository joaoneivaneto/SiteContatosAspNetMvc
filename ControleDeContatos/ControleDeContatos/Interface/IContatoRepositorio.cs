using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControleDeContatos.Interface
{
    public interface IContatoRepositorio 
    {
        ContatoMoldel ListarPorId(int id);
        List<ContatoMoldel> BuscarTodos();
        ContatoMoldel Adicionar(ContatoMoldel contato);

        ContatoMoldel Atulizar(ContatoMoldel contato);

        bool Apagar(int id);
  


        

    }
}
