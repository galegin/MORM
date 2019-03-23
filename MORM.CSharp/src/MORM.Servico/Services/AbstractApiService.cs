using MORM.Dominio.Interfaces;
using MORM.Dtos;
using MORM.Repositorio.Context;
using MORM.Repositorio.Repositories;
using MORM.Repositorio.Uow;
using MORM.Servico.Interfaces;
using System;

namespace MORM.Repositorio.Services
{
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

        public AbstractApiDto<TObject>.ListarRet Listar(AbstractApiDto<TObject>.Listar dto)
        {
            return new AbstractApiDto<TObject>.ListarRet(AbstractRepository.ListarO(dto.Filtro, 
                qtde: dto.QtdeRegistro, pagina: dto.NumeroPagina));
        }

        //-- consultar

        public AbstractApiDto<TObject>.ConsultarRet Consultar(AbstractApiDto<TObject>.Consultar dto)
        {
            return new AbstractApiDto<TObject>.ConsultarRet(AbstractRepository.ConsultarO(dto.Filtro));
        }

        //-- incluir

        public void Incluir(AbstractApiDto<TObject>.Incluir dto)
        {
            AbstractRepository.Incluir(dto.Objeto);
        }

        public void IncluirLista(AbstractApiDto<TObject>.IncluirLista dto)
        {
            AbstractRepository.Incluir(dto.Lista);
        }

        //-- alterar

        public void Alterar(AbstractApiDto<TObject>.Alterar dto)
        {
            AbstractRepository.Alterar(dto.Objeto);
        }

        public void AlterarLista(AbstractApiDto<TObject>.AlterarLista dto)
        {
            AbstractRepository.Alterar(dto.Lista);
        }

        //-- salvar

        public void Salvar(AbstractApiDto<TObject>.Salvar dto)
        {
            AbstractRepository.Salvar(dto.Objeto);
        }

        public void SalvarLista(AbstractApiDto<TObject>.SalvarLista dto)
        {
            AbstractRepository.Salvar(dto.Lista);
        }

        //-- excluir

        public void Excluir(AbstractApiDto<TObject>.Excluir dto)
        {
            AbstractRepository.Excluir(dto.Objeto ?? throw new ArgumentNullException(nameof(dto.Objeto)));
        }

        public void ExcluirLista(AbstractApiDto<TObject>.ExcluirLista dto)
        {
            AbstractRepository.Excluir(dto.Lista);
        }

        //-- sequencia

        public int SequenciaGen(AbstractApiDto<TObject>.SequenciaGen dto)
        {
            return AbstractRepository.SequenciaGen();
        }

        //-- select max

        public int SequenciaMax(AbstractApiDto<TObject>.SequenciaMax dto)
        {
            return AbstractRepository.SequenciaMaxO(dto.Filtro);
        }
    }
}