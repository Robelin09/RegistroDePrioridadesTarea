using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.BLL
{
    public class Prioridadbll
    {
        private readonly Contexto contexto;

        public Prioridadbll(Contexto scontexto)
        {
            scontexto = scontexto;
        }
        public bool Existe(int RegistroPrioridadId)
        {
            return contexto.Prioridades.Any(p => p.PrioridadId == RegistroPrioridadId);
        }
        public bool Insertar(Prioridades Prioridades)
        {
            contexto.Prioridades.Add(Prioridades);
            return contexto.SaveChanges() > 0;
        }
        public bool Modificar(Prioridades Prioridades)
        {
            var p = contexto.Prioridades.Find(Prioridades.PrioridadId);
            contexto.Entry(p!).State = EntityState.Detached;
            contexto.Entry(Prioridades).State = EntityState.Modified;
            return contexto.SaveChanges() > 0;
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
            var p = contexto.Prioridades.Find(Prioridades.PrioridadId);
            contexto.Entry(p!).State = EntityState.Detached;
            contexto.Entry(Prioridades).State = EntityState.Deleted;
            return contexto.SaveChanges() > 0;
        }
        public Prioridades? Buscar(int PrioridadId)
        {
            return contexto.Prioridades
                    .AsNoTracking()
                    .SingleOrDefault(a => a.PrioridadId == PrioridadId);
        }
        public List<Prioridades> Listar(Expression<Func<Prioridades, bool>> Criterio)
        {
            return contexto.Prioridades
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }
    }
}
