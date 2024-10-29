using Microsoft.EntityFrameworkCore;
using FestivosApi.Models;
using FestivosAPI.Models;

namespace FestivosAPI.Data
{
    public class FestivosContext : DbContext
    {
        public FestivosContext(DbContextOptions<FestivosContext> options) : base(options) { }

        public DbSet<Festivo> Festivos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
    }
}
