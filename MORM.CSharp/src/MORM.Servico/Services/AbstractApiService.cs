using MORM.Dominio.Interfaces;
using MORM.Dtos;
using MORM.Repositorio.Uow;
using MORM.Servico.Interfaces;
using System;

namespace MORM.Servico.Services
{
    public class AbstractApiService : IAbstractApiService
    {
        public IAbstractUnityOfWork AbstractUnityOfWork { get; }

        public AbstractApiService(IAbstractUnityOfWork abstractUnityOfWork)
        {
            AbstractUnityOfWork = abstractUnityOfWork ?? throw new ArgumentNullException(nameof(abstractUnityOfWork));
        }

        public void SetAmbiente(IAmbiente ambiente) => AbstractUnityOfWork.SetAmbiente(ambiente);
    }

    public class AbstractAmbApiService : IAbstractAmbApiService
    {
        public IAmbiente Ambiente { get; }

        public AbstractAmbApiService(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }
    }

    public class AbstractApiService<TObject> : AbstractApiService, IAbstractApiService<TObject> 
        where TObject : class
    {
        public IAbstractService<TObject> AbstractService { get; }

        public AbstractApiService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
            AbstractService = new AbstractService<TObject>(abstractUnityOfWork);
        }

        //-- listar

        public AbstractListarDto.Retorno<TObject> Listar(AbstractListarDto.Envio<TObject> dto)
        {
            return new AbstractListarDto.Retorno<TObject>(AbstractService.Listar(dto.Filtro));
        }

        //-- consultar

        public AbstractConsultarDto.Retorno<TObject> Consultar(AbstractConsultarDto.Envio<TObject> dto)
        {
            return new AbstractConsultarDto.Retorno<TObject>(AbstractService.Consultar(dto.Filtro));
        }

        //-- incluir

        public void Incluir(AbstractIncluirDto.Envio<TObject> dto) => AbstractService.Incluir(dto.Objeto);

        //-- alterar

        public void Alterar(AbstractAlterarDto.Envio<TObject> dto) => AbstractService.Alterar(dto.Objeto);

        //-- salvar

        public void Salvar(AbstractSalvarDto.Envio<TObject> dto) => AbstractService.Salvar(dto.Objeto);

        //-- excluir

        public void Excluir(AbstractExcluirDto.Envio<TObject> dto) => AbstractService.Excluir(dto.Objeto);

        //-- sequencia

        public int Sequencia(AbstractSequenciaDto.Envio<TObject> dto) => AbstractService.Sequencia(dto.Filtro);
    }
}