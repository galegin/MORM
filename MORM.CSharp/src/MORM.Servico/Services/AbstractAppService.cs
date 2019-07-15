using MORM.Dominio.Interfaces;
using MORM.Servico.Models;
using MORM.Servico.Interfaces;
using System;

namespace MORM.Servico.Services
{
    public class AbstractAppService : IAbstractAppService
    {
        public IAbstractUnityOfWork AbstractUnityOfWork { get; }

        public AbstractAppService(IAbstractUnityOfWork abstractUnityOfWork)
        {
            AbstractUnityOfWork = abstractUnityOfWork ?? throw new ArgumentNullException(nameof(abstractUnityOfWork));
        }

        public void SetAmbiente(IAmbiente ambiente) => AbstractUnityOfWork.SetAmbiente(ambiente);
    }

    public class AbstractAmbAppService : IAbstractAmbAppService
    {
        public IAmbiente Ambiente { get; }

        public AbstractAmbAppService(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }
    }

    public class AbstractAppService<TObject> : AbstractAppService, IAbstractAppService<TObject> 
        where TObject : class
    {
        public IAbstractService<TObject> AbstractService { get; }

        public AbstractAppService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
            AbstractService = new AbstractService<TObject>(abstractUnityOfWork);
        }

        //-- listar

        public object Listar(AbstractListarDto.Envio<TObject> dto)
        {
            return new AbstractListarDto.Retorno<TObject>(AbstractService.Listar(dto.Filtro));
        }

        //-- consultar

        public object Consultar(AbstractConsultarDto.Envio<TObject> dto)
        {
            return new AbstractConsultarDto.Retorno<TObject>(AbstractService.Consultar(dto.Filtro));
        }

        //-- incluir

        public object Incluir(AbstractIncluirDto.Envio<TObject> dto)
        {
            AbstractService.Incluir(dto.Objeto); return null;
        }

        //-- alterar

        public object Alterar(AbstractAlterarDto.Envio<TObject> dto)
        {
            AbstractService.Alterar(dto.Objeto); return null;
        }

        //-- salvar

        public object Salvar(AbstractSalvarDto.Envio<TObject> dto)
        {
            AbstractService.Salvar(dto.Objeto); return null;
        }

        //-- excluir

        public object Excluir(AbstractExcluirDto.Envio<TObject> dto)
        {
            AbstractService.Excluir(dto.Objeto); return null;
        }

        //-- sequencia

        public object Sequencia(AbstractSequenciaDto.Envio<TObject> dto)
        {
            return AbstractService.Sequencia(dto.Filtro);
        }
    }
}