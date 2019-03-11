using System;

namespace MORM.Apresentacao.Commands
{
    public class AbstractManutCommand : AbstractFormCommand, IAbstractManutCommand
    {
        public AbstractManutCommand(
            IAbstractFecharCommand fechar,
            IAbstractLimparCommand limpar,
            IAbstractConsultarCommand consultar,
            IAbstractSalvarCommand salvar,
            IAbstractExcluirCommand excluir)
        {
            Fechar = fechar ?? throw new ArgumentNullException(nameof(fechar));
            Limpar = limpar ?? throw new ArgumentNullException(nameof(limpar));
            Consultar = consultar ?? throw new ArgumentNullException(nameof(consultar));
            Salvar = salvar ?? throw new ArgumentNullException(nameof(salvar));
            Excluir = excluir ?? throw new ArgumentNullException(nameof(excluir));
        }

        public IAbstractFecharCommand Fechar { get; }
        public IAbstractLimparCommand Limpar { get; }
        public IAbstractConsultarCommand Consultar { get; }
        public IAbstractSalvarCommand Salvar { get; }
        public IAbstractExcluirCommand Excluir { get; }
    }
}