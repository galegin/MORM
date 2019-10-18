using System.Linq;
using MORM.CrossCutting;

namespace MORM.Repositorio
{
    public class DbSet<TObject> : IDbSet<TObject>
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
        public TObject GetById(TObject objeto) =>
            (TObject)_dataContext.GetObjeto(typeof(TObject), objeto);

        public IQueryable<TObject> GetAll()
        {
            var provider = new QueryableProvider<TObject>(_dataContext);
            return new Queryable<TObject>(provider, null);
        }

        public void Add(object objeto) => _dataContext.InsObjeto(objeto);
        public void AddOrUpdate(object objeto) => _dataContext.SetObjeto(objeto);
        public void Update(object objeto) => _dataContext.UpdObjeto(objeto);
        public void Delete(object objeto) => _dataContext.RemObjeto(objeto);
        public long Sequence(object objeto) => _dataContext.IncObjeto<TObject>(objeto);
        #endregion
    }
}