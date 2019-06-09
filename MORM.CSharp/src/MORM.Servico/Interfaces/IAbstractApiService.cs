using MORM.Dominio.Interfaces;
using MORM.Dtos;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Interfaces
{
    public interface IAbstractApiService
    {
        IAbstractUnityOfWork AbstractUnityOfWork { get; }
        void SetAmbiente(IAmbiente ambiente);
    }

    public interface IAbstractAmbApiService
    {
        IAmbiente Ambiente { get; }
    }

    public interface IAbstractApiService<TObject> : IAbstractApiService
    {
        IAbstractService<TObject> AbstractService { get; }
        AbstractListarDto.Retorno<TObject> Listar(AbstractListarDto.Envio<TObject> dto);
        AbstractConsultarDto.Retorno<TObject> Consultar(AbstractConsultarDto.Envio<TObject> dto);
        void Incluir(AbstractIncluirDto.Envio<TObject> dto);
        void Alterar(AbstractAlterarDto.Envio<TObject> dto);
        void Salvar(AbstractSalvarDto.Envio<TObject> dto);
        void Excluir(AbstractExcluirDto.Envio<TObject> dto);
        int Sequencia(AbstractSequenciaDto.Envio<TObject> dto);
    }
}