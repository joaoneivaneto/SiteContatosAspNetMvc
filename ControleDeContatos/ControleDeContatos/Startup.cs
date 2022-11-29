using ControleDeContatos.Interface;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Builder;

namespace ControleDeContatos
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IContatoRepositorio, ContatoRepositorio>();
        }
    }
}
