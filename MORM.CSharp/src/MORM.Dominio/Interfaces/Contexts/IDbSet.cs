using System.Linq;

namespace MORM.Dominio.Interfaces
{
    public interface IDbSet<TInstance>
    {
        TInstance GetById(TInstance instance);
        IQueryable<TInstance> GetAll();
        void Add(object instance);
        void AddOrUpdate(object instance);
        void Update(object instance);
        void Delete(object instance);
    }
}