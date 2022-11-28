using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Models
{
    public class BancoContext: DbContext
    {
        public readonly IConfiguration Configuration;

        public BancoContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<ContatoMoldel> Contatos { get; set; }
    }
}
