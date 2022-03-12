using JaarConsultTeste.Model;
using Microsoft.EntityFrameworkCore;

namespace JaarConsultTeste.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
