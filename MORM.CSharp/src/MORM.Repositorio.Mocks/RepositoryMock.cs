using MORM.CrossCutting;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Mocks
{
    public class RepositoryMock<TInstance> : IRepository<TInstance>
        where TInstance : class
    {
        #region variaveis
        protected int _sequencia = 0;
        protected List<TInstance> DbSet = new List<TInstance>();
        #endregion

        #region metodos
        public IQueryable<TInstance> GetAll() => DbSet.AsQueryable();

        public TInstance GetById(TInstance instance) => DbSet.FirstOrDefault(x => x.Equals(instance));

        public void Add(TInstance instance) => DbSet.Add(instance);

        public void AddOrUpdate(TInstance instance)
        {
            Delete(instance);
            Add(instance);
        }

        public void Update(TInstance instance) => AddOrUpdate(instance);

        public void Delete(TInstance instance)
        {
            var instanceExiste = GetById(instance);
            if (instanceExiste != null)
                DbSet.Remove(instanceExiste);
        }

        public long Sequence(TInstance instance) => ++_sequencia;
        #endregion
    }
}