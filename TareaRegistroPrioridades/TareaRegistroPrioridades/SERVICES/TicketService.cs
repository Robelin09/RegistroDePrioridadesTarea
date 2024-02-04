using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.Service
{
    public class TicketService
    {
        private readonly Contexto _contexto;
        public TicketService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int TicketId)
        {
            return await _contexto.Tickets.AnyAsync(p => p.TicketId == TicketId);
        }
        public async Task<bool> Insertar(Tickets Tickets)
        {
            _contexto.Tickets.Add(Tickets);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Tickets Tickets)
        {
            var p = await _contexto.Tickets.FindAsync(Tickets.TicketId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Tickets).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Tickets Tickets)
        {
            if (!await Existe(Tickets.TicketId))
                return await Insertar(Tickets);
            else
                return await Modificar(Tickets);
        }
        public async Task<bool> Eliminar(Tickets Tickets)
        {
            var p = await _contexto.Tickets.FindAsync(Tickets.TicketId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Tickets).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Tickets?> Buscar(int TicketId)
        {
            return await _contexto.Tickets
                .Where(t => t.TicketId == TicketId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> Criterio)
        {
            return await _contexto.Tickets
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
