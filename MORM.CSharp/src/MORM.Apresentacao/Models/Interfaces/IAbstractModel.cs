using System;

namespace MORM.Apresentacao.Models
{
    public interface IAbstractModel
    {
        void ClearFiltroAll();
        void AddFiltroAll(Func<IAbstractModel, string> filtro);
        string GetFiltroAll();
        string GetFiltroKey();
    }
}