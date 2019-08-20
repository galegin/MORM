using MORM.Dominio.Interfaces;

namespace MORM.Dominio.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddOrUpdate<TInstance>(this IRepository repository,
            IAbstractEntidadeId entidade) 
        {
            if (entidade.IsAddEntidade())
                repository.Add(entidade);
            else
                repository.Update(entidade);
        }
    }
}