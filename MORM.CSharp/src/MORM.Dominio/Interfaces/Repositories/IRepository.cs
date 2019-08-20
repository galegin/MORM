namespace MORM.Dominio.Interfaces
{
    public interface IRepository
    {
        void Add(object instance);
        void Update(object instance);
        void Remove(object instance);
    }

    public interface IRepository<TInstance> 
        where TInstance : class
    {
        IQueryableObject<TInstance> GetAll();
        TInstance FindId(string id);
    }
}