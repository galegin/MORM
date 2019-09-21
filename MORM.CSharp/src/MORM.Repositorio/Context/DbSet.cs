using System.Linq;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Queries;

namespace MORM.Repositorio.Context
{
    public class DbSet<TInstance> : IDbSet<TInstance>
    {
        #region variaveis
        private readonly IAbstractDataContext _dataContext;
        #endregion

        #region construtores
        public DbSet(IAbstractDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        #endregion

        #region metodos
        public TInstance GetById(TInstance instance) =>
            (TInstance)_dataContext.GetObjeto(typeof(TInstance), instance);

        public IQueryable<TInstance> GetAll()
        {
            var provider = new QueryableProvider<TInstance>(_dataContext);
            return new Queryable<TInstance>(provider, null);
        }

        public void Add(object instance) => _dataContext.InsObjeto(instance);
        public void AddOrUpdate(object instance) => _dataContext.SetObjeto(instance);
        public void Update(object instance) => _dataContext.UpdObjeto(instance);
        public void Delete(object instance) => _dataContext.RemObjeto(instance);
        public long Sequencia(object instance) => _dataContext.IncObjeto<TInstance>(instance);
        #endregion
    }
}