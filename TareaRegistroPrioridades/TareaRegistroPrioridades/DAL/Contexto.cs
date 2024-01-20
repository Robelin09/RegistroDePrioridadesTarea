using Microsoft.EntityFrameworkCore;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Prioridades> Prioridades { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
    }
}
