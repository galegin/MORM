using System;
using System.Collections.Generic;

namespace MORM.Apresentacao
{
    public abstract class AbstractMenuSistema : IMenuSistema
    {
        protected readonly IMenuResolver _resolver;

        public AbstractMenuSistema(IMenuResolver resolver)
        {
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public abstract IList<IMenuOpcao> GetListaDeMenuOpcao();
    }
}