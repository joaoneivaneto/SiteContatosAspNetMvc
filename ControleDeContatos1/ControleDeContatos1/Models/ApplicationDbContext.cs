
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos1.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
       public DbSet<Contato> contatos { get; set; }
    }
}
