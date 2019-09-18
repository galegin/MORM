using System.Linq;

namespace MORM.Dominio.Interfaces
{
    public interface IRepository<TInstance> where TInstance : class
    {
        IQueryable<TInstance> GetAll();
        TInstance GetById(TInstance instance);
        void Add(TInstance instance);
        void AddOrUpdate(TInstance instance);
        void Update(TInstance instance);
        void Delete(TInstance instance);
        long Sequencia(TInstance instance);
    }
}