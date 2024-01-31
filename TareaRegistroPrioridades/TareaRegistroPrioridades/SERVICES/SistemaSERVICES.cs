using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.Modelo;

namespace TareaRegistroPrioridades.SERVICES
{
    public class SistemaSERVICES
    {
        private readonly Contexto _contexto;
        public SistemaSERVICES(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int SistemaId)
        {
            return _contexto.Sistema.Any(p => p.SistemaId == SistemaId);
        }
        public bool Insertar(Sistema Sistema)
        {
            _contexto.Sistema.Add(Sistema);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Sistema Sistema)
        {
            var p = _contexto.Sistema.Find(Sistema.SistemaId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Sistema).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Guardar(Sistema Sistema)
        {
            if (!Existe(Sistema.SistemaId))
                return this.Insertar(Sistema);
            else
                return this.Modificar(Sistema);
        }
        public bool Eliminar(Sistema Sistema)
        {
            var p = _contexto.Sistema.Find(Sistema.SistemaId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Sistema).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        public Sistema? Buscar(int SistemaId)
        {
            return _contexto.Sistema
                .Where(t => t.SistemaId == SistemaId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public List<Sistema> Listar(Expression<Func<Sistema, bool>> Criterio)
        {
            return _contexto.Sistema
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }   
    }
}
