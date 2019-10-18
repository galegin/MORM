using System.Linq;

namespace MORM.CrossCutting
{
    public interface IDbSet<TObject>
    {
        TObject GetById(TObject objeto);
        IQueryable<TObject> GetAll();
        void Add(object objeto);
        void AddOrUpdate(object objeto);
        void Update(object objeto);
        void Delete(object objeto);
        long Sequence(object objeto);
    }
}