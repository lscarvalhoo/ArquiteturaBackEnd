using configuracaoArquiteturaBackEnd.api.Business.Entities;
using configuracaoArquiteturaBackEnd.api.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace configuracaoArquiteturaBackEnd.api.Infra.Data
{
    public class CursoDbContext : DbContext
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
