using MORM.Repositorio.Uow;
using MORM.Repositorio.Repositories;
using MORM.Utilidade.Dtos;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Services
{
    //-- galeg - 01/05/2018 11:38:32
    public interface IAbstractApiService
    {
        IAbstractUnityOfWork AbstractUnityOfWork { get; }
        void SetAmbiente(IAmbiente ambiente);
        IAmbiente Ambiente { get; }
    }

    public interface IAbstractApiService<TObject> : IAbstractApiService where TObject : class
    {
        IAbstractRepository<TObject> AbstractRepository { get; }
        DtoAbstractApi<TObject>.ListarRet Listar(DtoAbstractApi<TObject>.Listar dto);
        DtoAbstractApi<TObject>.ConsultarRet Consultar(DtoAbstractApi<TObject>.Consultar dto);
        void Incluir(DtoAbstractApi<TObject>.Incluir dto);
        void IncluirLista(DtoAbstractApi<TObject>.IncluirLista dto);
        void Alterar(DtoAbstractApi<TObject>.Alterar dto);
        void AlterarLista(DtoAbstractApi<TObject>.AlterarLista dto);
        void Salvar(DtoAbstractApi<TObject>.Salvar dto);
        void SalvarLista(DtoAbstractApi<TObject>.SalvarLista dto);
        void Excluir(DtoAbstractApi<TObject>.Excluir dto);
        void ExcluirLista(DtoAbstractApi<TObject>.ExcluirLista dto);
        int SequenciaGen(DtoAbstractApi<TObject>.SequenciaGen dto);
        int SequenciaMax(DtoAbstractApi<TObject>.SequenciaMax dto);
    }
}