using System;

namespace MORM.Apresentacao.Commands
{
    public class AbstractListaCommand : AbstractFormCommand, IAbstractListaCommand
    {
        public AbstractListaCommand(
            IAbstractFecharCommand fechar,
            IAbstractLimparCommand limpar,
            IAbstractListarCommand listar)
        {
            Fechar = fechar ?? throw new ArgumentNullException(nameof(fechar));
            Limpar = limpar ?? throw new ArgumentNullException(nameof(limpar));
            Listar = listar ?? throw new ArgumentNullException(nameof(listar));
        }

        public IAbstractFecharCommand Fechar { get; }
        public IAbstractLimparCommand Limpar { get; }
        public IAbstractListarCommand Listar { get; }
    }
}