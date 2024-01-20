using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.BLL
{
    public class ClientesBLL
    {
        private readonly Contexto contexto;

        public ClientesBLL(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public bool Existe(int ClienteId)
        {
            return contexto.Clientes.Any(p => p.ClienteId == ClienteId);
        }
        public bool Insertar(Clientes Clientes)
        {
            contexto.Clientes.Add(Clientes);
            return contexto.SaveChanges() > 0;
        }
        public bool Modificar(Clientes Clientes)
        {
            var p = contexto.Clientes.Find(Clientes.ClienteId);
            contexto.Entry(p!).State = EntityState.Detached;
            contexto.Entry(Clientes).State = EntityState.Modified;
            return contexto.SaveChanges() > 0;
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
            var p = contexto.Clientes.Find(Clientes.ClienteId);
            contexto.Entry(p!).State = EntityState.Detached;
            contexto.Entry(Clientes).State = EntityState.Deleted;
            return contexto.SaveChanges() > 0;
        }
        public Clientes? Buscar(int ClienteId)
        {
            return contexto.Clientes
                    .AsNoTracking()
                    .SingleOrDefault(a => a.ClienteId == ClienteId);
        }
        public List<Clientes> Listar(Expression<Func<Clientes, bool>> Criterio)
        {
            return contexto.Clientes
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }       

    }
}
