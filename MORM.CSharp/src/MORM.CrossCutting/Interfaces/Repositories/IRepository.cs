using System.Linq;

namespace MORM.CrossCutting
{
    public interface IRepository
    {
    }

    public interface IRepositoryDataContext
    {
        IAbstractDataContext DataContext { get; }
    }

    public interface IRepository<TInstance> : IRepository where TInstance : class
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