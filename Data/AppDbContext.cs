using Microsoft.EntityFrameworkCore;
using PesquisaSatisfacaoApi.Models;

namespace PesquisaSatisfacaoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<PesquisaResposta> Respostas => Set<PesquisaResposta>();
    }
}
