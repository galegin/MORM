using MORM.Repositorio.Context;
using MORM.Repositorio.Uow;
using MORM.Repositorio.Repositories;
using MORM.Utilidade.Dtos;
using MORM.Utilidade.Interfaces;
using System;

namespace MORM.Repositorio.Services
{
    //-- galeg - 01/05/2018 11:14:23
    public class AbstractApiService : IAbstractApiService
    {
        public AbstractApiService(IAbstractUnityOfWork abstractUnityOfWork) : this(abstractUnityOfWork.Ambiente)
        {
            AbstractUnityOfWork = abstractUnityOfWork ?? throw new ArgumentNullException(nameof(abstractUnityOfWork));
        }

        public IAbstractUnityOfWork AbstractUnityOfWork { get; }
        public void SetAmbiente(IAmbiente ambiente) => AbstractUnityOfWork.SetAmbiente(ambiente);

        public AbstractApiService(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }

        public IAmbiente Ambiente { get; }
    }

    public class AbstractApiService<TObject> : AbstractApiService, IAbstractApiService<TObject> 
        where TObject : class
    {
        public AbstractApiService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
            AbstractRepository = new AbstractRepository<TObject>(abstractUnityOfWork.DataContext);
        }

        public IAbstractRepository<TObject> AbstractRepository { get; }

        public AbstractApiService(IAmbiente ambiente) : base(ambiente)
        {
            AbstractRepository = new AbstractRepository<TObject>(new AbstractDataContext(ambiente));
        }

        //-- listar

        public DtoAbstractApi<TObject>.ListarRet Listar(DtoAbstractApi<TObject>.Listar dto)
        {
            return new DtoAbstractApi<TObject>.ListarRet(AbstractRepository.ListarO(dto.Filtro, 
                qtde: dto.QtdeRegistro, pagina: dto.NumeroPagina));
        }

        //-- consultar

        public DtoAbstractApi<TObject>.ConsultarRet Consultar(DtoAbstractApi<TObject>.Consultar dto)
        {
            return new DtoAbstractApi<TObject>.ConsultarRet(AbstractRepository.ConsultarO(dto.Filtro));
        }

        //-- incluir

        public void Incluir(DtoAbstractApi<TObject>.Incluir dto)
        {
            AbstractRepository.Incluir(dto.Objeto);
        }

        public void IncluirLista(DtoAbstractApi<TObject>.IncluirLista dto)
        {
            AbstractRepository.Incluir(dto.Lista);
        }

        //-- alterar

        public void Alterar(DtoAbstractApi<TObject>.Alterar dto)
        {
            AbstractRepository.Alterar(dto.Objeto);
        }

        public void AlterarLista(DtoAbstractApi<TObject>.AlterarLista dto)
        {
            AbstractRepository.Alterar(dto.Lista);
        }

        //-- salvar

        public void Salvar(DtoAbstractApi<TObject>.Salvar dto)
        {
            AbstractRepository.Salvar(dto.Objeto);
        }

        public void SalvarLista(DtoAbstractApi<TObject>.SalvarLista dto)
        {
            AbstractRepository.Salvar(dto.Lista);
        }

        //-- excluir

        public void Excluir(DtoAbstractApi<TObject>.Excluir dto)
        {
            AbstractRepository.Excluir(dto.Objeto ?? throw new ArgumentNullException(nameof(dto.Objeto)));
        }

        public void ExcluirLista(DtoAbstractApi<TObject>.ExcluirLista dto)
        {
            AbstractRepository.Excluir(dto.Lista);
        }

        //-- sequencia

        public int SequenciaGen(DtoAbstractApi<TObject>.SequenciaGen dto)
        {
            return AbstractRepository.SequenciaGen();
        }

        //-- select max

        public int SequenciaMax(DtoAbstractApi<TObject>.SequenciaMax dto)
        {
            return AbstractRepository.SequenciaMaxO(dto.Filtro);
        }
    }
}