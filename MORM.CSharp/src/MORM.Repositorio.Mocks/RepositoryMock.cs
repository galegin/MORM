using MORM.CrossCutting;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Mocks
{
    public class RepositoryMock<TObject> : IRepository<TObject>
        where TObject : class
    {
        #region variaveis
        protected int _sequencia = 0;
        protected List<TObject> DbSet = new List<TObject>();
        #endregion

        #region metodos
        public IQueryable<TObject> GetAll() => DbSet.AsQueryable();

        public TObject GetById(TObject objeto) => DbSet.FirstOrDefault(x => x.Equals(objeto));

        public void Add(TObject objeto) => DbSet.Add(objeto);

        public void AddOrUpdate(TObject objeto)
        {
            Delete(objeto);
            Add(objeto);
        }

        public void Update(TObject objeto) => AddOrUpdate(objeto);

        public void Delete(TObject objeto)
        {
            var objetoExiste = GetById(objeto);
            if (objetoExiste != null)
                DbSet.Remove(objetoExiste);
        }

        public long Sequence(object filtro) => ++_sequencia;
        #endregion
    }
}