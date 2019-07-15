using MORM.Dominio.Interfaces;
using MORM.Servico.Models;

namespace MORM.Servico.Interfaces
{
    public interface IAbstractAppService
    {
        IAbstractUnityOfWork AbstractUnityOfWork { get; }
        void SetAmbiente(IAmbiente ambiente);
    }

    public interface IAbstractAmbAppService
    {
        IAmbiente Ambiente { get; }
    }

    public interface IAbstractAppService<TObject> : IAbstractAppService
    {
        IAbstractService<TObject> AbstractService { get; }
        object Listar(AbstractListarDto.Envio<TObject> dto);
        object Consultar(AbstractConsultarDto.Envio<TObject> dto);
        object Incluir(AbstractIncluirDto.Envio<TObject> dto);
        object Alterar(AbstractAlterarDto.Envio<TObject> dto);
        object Salvar(AbstractSalvarDto.Envio<TObject> dto);
        object Excluir(AbstractExcluirDto.Envio<TObject> dto);
        object Sequencia(AbstractSequenciaDto.Envio<TObject> dto);
    }
}