using MORM.Apresentacao.Comps;
using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.Models
{
    public abstract class AbstractModel : AbstractNotifyPropertyChanged, IAbstractModel
    {
        private List<string> _filtros = new List<string>();
        public void ClearFiltroAll() => _filtros.Clear();
        public void AddFiltroAll(Func<IAbstractModel, string> filtro)
        {
            _filtros.Add(filtro?.Invoke(this) ?? null);
        }
        public string GetFiltroAll() => string.Join(" and ", _filtros);

        public abstract string GetFiltroKey();
    }
}