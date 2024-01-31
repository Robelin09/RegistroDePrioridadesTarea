using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.SERVICES
{
    public class TicketsSERVICES
    {
        private readonly Contexto _contexto;
        public TicketsSERVICES(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int TicketId)
        {
            return _contexto.Tickets.Any(p => p.TicketId == TicketId);
        }
        public bool Insertar(Tickets Tickets)
        {
            _contexto.Tickets.Add(Tickets);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Tickets Tickets)
        {
            var p = _contexto.Tickets.Find(Tickets.TicketId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Tickets).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Guardar(Tickets Tickets)
        {
            if (!Existe(Tickets.TicketId))
                return this.Insertar(Tickets);
            else
                return this.Modificar(Tickets);
        }
        public bool Eliminar(Tickets Tickets)
        {
            var p = _contexto.Tickets.Find(Tickets.TicketId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Tickets).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        public Tickets? Buscar(int TicketId)
        {
            return _contexto.Tickets
                .Where(t => t.TicketId == TicketId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public List<Tickets> Listar(Expression<Func<Tickets, bool>> Criterio)
        {
            return _contexto.Tickets
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }
    }
}
