using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.Service
{
    public class SistemaService
    {
        private readonly Contexto _contexto;
        public SistemaService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int SistemaId)
        {
            return await _contexto.Sistema.AnyAsync(p => p.SistemaId == SistemaId);
        }
        public async Task<bool> Insertar(Sistemas Sistema)
        {
            _contexto.Sistema.Add(Sistema);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Sistemas Sistema)
        {
            var p = await _contexto.Sistema.FindAsync(Sistema.SistemaId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Sistema).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Sistemas Sistema)
        {
            if (!await Existe(Sistema.SistemaId))
                return await Insertar(Sistema);
            else
                return await Modificar(Sistema);
        }
        public async Task<bool> Eliminar(Sistemas Sistema)
        {
            var p = await _contexto.Sistema.FindAsync(Sistema.SistemaId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Sistema).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Sistemas?> Buscar(int SistemaId)
        {
            return await _contexto.Sistema
                .Where(t => t.SistemaId == SistemaId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> Criterio)
        {
            return await _contexto.Sistema
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }   
    }
}
