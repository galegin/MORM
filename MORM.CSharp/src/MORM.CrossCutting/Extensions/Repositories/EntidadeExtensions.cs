using System;

namespace MORM.CrossCutting
{
    public static class EntidadeExtensions
    {
        public static bool IsAddEntidade(this IAbstractEntidadeId entidade)
        {
            return string.IsNullOrWhiteSpace(entidade.Id);
        }

        public static void SetAddEntidade(this IAbstractEntidadeId entidade)
        {
            if (entidade.IsAddEntidade())
                entidade.Id = Guid.NewGuid().ToString();
        }
    }
}