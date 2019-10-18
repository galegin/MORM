using MORM.CrossCutting;
using System.Linq;

namespace MORM.Repositorio
{
    public class Repository<TObject> : IRepository<TObject>, IRepositoryDataContext 
        where TObject : class
    {
        #region variaveis
        protected readonly IAbstractDataContext _dataContext;
        protected readonly IDbSet<TObject> _dbSet;
        #endregion

        #region propriedades
        public IAbstractDataContext DataContext => _dataContext;
        #endregion

        #region construtores
        public Repository(IAbstractDataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = dataContext.Set<TObject>();
        }
        #endregion

        #region metodos
        public IQueryable<TObject> GetAll() => _dbSet.GetAll();
        public TObject GetById(TObject objeto) => _dbSet.GetById(objeto);
        public void Add(TObject objeto) => _dbSet.Add(objeto);
        public void AddOrUpdate(TObject objeto) => _dbSet.AddOrUpdate(objeto);
        public void Update(TObject objeto) => _dbSet.Update(objeto);
        public void Delete(TObject objeto) => _dbSet.Delete(objeto);
        public long Sequence(object objeto) => _dbSet.Sequence(objeto);
        #endregion
    }
}