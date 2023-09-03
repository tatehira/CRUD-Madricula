using Microsoft.EntityFrameworkCore;
using Matricula.Dados;

namespace Matricula.Database
{
    public class MatriculaContext : DbContext
    {
        public MatriculaContext(DbContextOptions<MatriculaContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        // Lista do objeto que irá pro banco de dados
        public DbSet<Cadastro> cadastro { get; set; }
        public DbSet<TimeFutebol> timeFutebols { get; set; }
    }
}
