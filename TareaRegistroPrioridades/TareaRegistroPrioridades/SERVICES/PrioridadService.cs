using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.Service
{
    public class PrioridadService
    {
        private readonly Contexto _contexto;
        public PrioridadService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int RegistroPrioridadId)
        {
            return await _contexto.Prioridades.AnyAsync(p => p.PrioridadId == RegistroPrioridadId);
        }
        public async Task<bool> Insertar(Prioridades Prioridades)
        {
            _contexto.Prioridades.Add(Prioridades);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;

        }
        public async Task<bool> Modificar(Prioridades Prioridades)
        {
            var p =await _contexto.Prioridades.FindAsync(Prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Prioridades).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Prioridades Prioridades)
        {
            if (!await Existe(Prioridades.PrioridadId))
                return await Insertar(Prioridades);
            else
                return await Modificar(Prioridades);
        }
        public async Task<bool> Eliminar(Prioridades Prioridades)
        {
            var p =await _contexto.Prioridades.FindAsync(Prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Prioridades).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Prioridades?> Buscar(int PrioridadId)
        {
            return await _contexto.Prioridades
                .Where(t => t.PrioridadId == PrioridadId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> Criterio)
        {
            return await _contexto.Prioridades
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}