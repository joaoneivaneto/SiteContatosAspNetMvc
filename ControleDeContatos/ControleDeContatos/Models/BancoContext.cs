using ControleDeContatos.Interface;
using ControleDeContatos.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Models
{
    public class BancoContext: DbContext
    {
        
        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options)
        {
           
        }
        
        

        public DbSet<ContatoMoldel> Contatos { get; set; }
    }
}
