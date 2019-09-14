namespace MORM.Dominio.Interfaces
{
    public interface IDbSet<TInstance>
    {
        TInstance GetById(TInstance instance);
        IQueryableObject<TInstance> GetListAll();
        void Add(object instance);
        void AddOrUpdate(object instance);
        void Update(object instance);
        void Delete(object instance);
    }
}