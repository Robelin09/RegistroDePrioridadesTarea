using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.BLL
{
    public class ClientesSERVICES
    {
        private readonly Contexto _contexto;

        public ClientesSERVICES(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int ClienteId)
        {
            return _contexto.Clientes.Any(p => p.ClienteId == ClienteId);
        }
        public bool Insertar(Clientes Clientes)
        {
            _contexto.Clientes.Add(Clientes);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Clientes Clientes)
        {
            var p = _contexto.Clientes.Find(Clientes.ClienteId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Clientes).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Guardar(Clientes Clientes)
        {
            if (!Existe(Clientes.ClienteId))
                return this.Insertar(Clientes);
            else
                return this.Modificar(Clientes);
        }
        public bool Eliminar(Clientes Clientes)
        {
            var p = _contexto.Clientes.Find(Clientes.ClienteId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Clientes).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        public Clientes? Buscar(int ClienteId)
        {
            return _contexto.Clientes
                .Where(t => t.ClienteId == ClienteId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public List<Clientes> Listar(Expression<Func<Clientes, bool>> Criterio)
        {
            return _contexto.Clientes
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }
    }
}
