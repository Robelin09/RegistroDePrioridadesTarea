using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.Service
{
    public class ClienteService
    {
        private readonly Contexto _contexto;
        public ClienteService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int ClienteId)
        {
            return await _contexto.Clientes.AnyAsync(p => p.ClienteId == ClienteId);
        }
        public async Task<bool> Insertar(Clientes Clientes)
        {
            _contexto.Clientes.Add(Clientes);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Clientes Clientes)
        {
            var p = await _contexto.Clientes.FindAsync(Clientes.ClienteId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Clientes).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Clientes Clientes)
        {
            if (!await Existe(Clientes.ClienteId))
                return await Insertar(Clientes);
            else
                return await Modificar(Clientes);
        }
        public async Task<bool> Eliminar(Clientes Clientes)
        {
            var p = await _contexto.Clientes.FindAsync(Clientes.ClienteId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Clientes).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Clientes?> Buscar(int ClienteId)
        {
            return await _contexto.Clientes
                .Where(t => t.ClienteId == ClienteId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> Criterio)
        {
            return await _contexto.Clientes
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
