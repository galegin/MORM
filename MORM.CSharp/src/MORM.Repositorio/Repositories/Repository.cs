﻿using MORM.CrossCutting;
using System.Linq;

namespace MORM.Repositorio
{
    public class Repository<TInstance> : IRepository<TInstance>, IRepositoryDataContext where TInstance : class
    {
        #region variaveis
        protected readonly IAbstractDataContext _dataContext;
        protected readonly IDbSet<TInstance> _dbSet;
        #endregion

        #region propriedades
        public IAbstractDataContext DataContext => _dataContext;
        #endregion

        #region construtores
        public Repository(IAbstractDataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = dataContext.Set<TInstance>();
        }
        #endregion

        #region metodos
        public IQueryable<TInstance> GetAll() => _dbSet.GetAll();
        public TInstance GetById(TInstance instance) => _dbSet.GetById(instance);
        public void Add(TInstance instance) => _dbSet.Add(instance);
        public void AddOrUpdate(TInstance instance) => _dbSet.AddOrUpdate(instance);
        public void Update(TInstance instance) => _dbSet.Update(instance);
        public void Delete(TInstance instance) => _dbSet.Delete(instance);
        public long Sequencia(TInstance instance) => _dbSet.Sequencia(instance);
        #endregion
    }
}