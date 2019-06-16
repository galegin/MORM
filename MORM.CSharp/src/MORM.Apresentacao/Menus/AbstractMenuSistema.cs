using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.Menus
{
    public abstract class AbstractMenuSistema : IMenuSistema
    {
        protected readonly IMenuResolverClasse _resolverClasse;
        protected readonly IMenuResolverObjeto _resolverObjeto;
        protected readonly IMenuResolverTipo _resolverTipo;

        public AbstractMenuSistema(
            IMenuResolverClasse resolverClasse,
            IMenuResolverObjeto resolverObjeto,
            IMenuResolverTipo resolverTipo)
        {
            _resolverClasse = resolverClasse ?? throw new ArgumentNullException(nameof(resolverClasse));
            _resolverObjeto = resolverObjeto ?? throw new ArgumentNullException(nameof(resolverObjeto));
            _resolverTipo = resolverTipo ?? throw new ArgumentNullException(nameof(resolverTipo));
        }

        public abstract IList<IMenuOpcao> GetListaDeMenuOpcao();
    }
}