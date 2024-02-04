using Microsoft.EntityFrameworkCore;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prioridades> Prioridades { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Sistemas> Sistema { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options)  {  }
    }
}
