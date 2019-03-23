using MORM.Dominio.Interfaces;
using MORM.Dtos;
using MORM.Repositorio.Repositories;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Interfaces
{
    public interface IAbstractApiService
    {
        IAbstractUnityOfWork AbstractUnityOfWork { get; }
        void SetAmbiente(IAmbiente ambiente);
        IAmbiente Ambiente { get; }
    }

    public interface IAbstractApiService<TObject> : IAbstractApiService where TObject : class
    {
        IAbstractRepository<TObject> AbstractRepository { get; }
        AbstractApiDto<TObject>.ListarRet Listar(AbstractApiDto<TObject>.Listar dto);
        AbstractApiDto<TObject>.ConsultarRet Consultar(AbstractApiDto<TObject>.Consultar dto);
        void Incluir(AbstractApiDto<TObject>.Incluir dto);
        void IncluirLista(AbstractApiDto<TObject>.IncluirLista dto);
        void Alterar(AbstractApiDto<TObject>.Alterar dto);
        void AlterarLista(AbstractApiDto<TObject>.AlterarLista dto);
        void Salvar(AbstractApiDto<TObject>.Salvar dto);
        void SalvarLista(AbstractApiDto<TObject>.SalvarLista dto);
        void Excluir(AbstractApiDto<TObject>.Excluir dto);
        void ExcluirLista(AbstractApiDto<TObject>.ExcluirLista dto);
        int SequenciaGen(AbstractApiDto<TObject>.SequenciaGen dto);
        int SequenciaMax(AbstractApiDto<TObject>.SequenciaMax dto);
    }
}