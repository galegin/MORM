using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Queries;

namespace MORM.Repositorio.Repositories
{
    public class Repository
    {
        #region variaveis
        protected readonly IAbstractDataContext _context;
        #endregion

        #region construtores
        public Repository(IAbstractDataContext context)
        {
            _context = context;
        }
        #endregion

        #region metodos
        public void Add(object instance)
        {
            if (instance is IAbstractEntidadeId)
                (instance as IAbstractEntidadeId).SetAddEntidade();
            _context.InsObjeto(instance);
        }
        public void Update(object instance)
        {
            _context.UpdObjeto(instance);
        }
        public void Remove(object instance)
        {
            _context.RemObjeto(instance);
        }
        #endregion
    }

    public class Repository<TInstance> : Repository, IRepository<TInstance>
        where TInstance : class, IAbstractEntidadeId
    {
        #region construtores
        public Repository(IAbstractDataContext context) : base(context)
        {
        }
        #endregion

        #region metodos
        public IQueryableObject<TInstance> GetAll()
        {
            return new QueryableObject<TInstance>(_context);
        }
        public TInstance FindId(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
        #endregion
    }
}