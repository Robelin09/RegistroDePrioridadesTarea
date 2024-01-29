using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.BLL
{
    public class PrioridadSERVICES
    {
        private readonly Contexto _contexto;

        public PrioridadSERVICES(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int RegistroPrioridadId)
        {
            return _contexto.Prioridades.Any(p => p.PrioridadId == RegistroPrioridadId);
        }
        public bool Insertar(Prioridades Prioridades)
        {
            _contexto.Prioridades.Add(Prioridades);
            return _contexto.SaveChanges() > 0;

        }
        public bool Modificar(Prioridades Prioridades)
        {
            var p = _contexto.Prioridades.Find(Prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Prioridades).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Guardar(Prioridades Prioridades)
        {
            if (!Existe(Prioridades.PrioridadId))
                return this.Insertar(Prioridades);
            else
                return this.Modificar(Prioridades);
        }
        public bool Eliminar(Prioridades Prioridades)
        {
            var p = _contexto.Prioridades.Find(Prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Prioridades).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        public Prioridades? Buscar(int PrioridadId)
        {
            return _contexto.Prioridades
                .Where(t => t.PrioridadId == PrioridadId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public List<Prioridades> Listar(Expression<Func<Prioridades, bool>> Criterio)
        {
            return _contexto.Prioridades
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }
    }
}