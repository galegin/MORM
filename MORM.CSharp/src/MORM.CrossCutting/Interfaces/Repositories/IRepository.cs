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

    public interface IRepository<TObject> : IRepository where TObject : class
    {
        IQueryable<TObject> GetAll();
        TObject GetById(TObject objeto);
        void Add(TObject objeto);
        void AddOrUpdate(TObject objeto);
        void Update(TObject objeto);
        void Delete(TObject objeto);
        long Sequence(object filtro);
    }
}