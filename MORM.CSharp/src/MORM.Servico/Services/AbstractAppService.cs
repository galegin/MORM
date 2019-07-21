using MORM.Dominio.Interfaces;
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

        public object Listar(TObject filtro)
        {
            return AbstractService.Listar(filtro);
        }

        //-- consultar

        public object Consultar(TObject filtro)
        {
            return AbstractService.Consultar(filtro);
        }

        //-- incluir

        public object Incluir(TObject objeto)
        {
            AbstractService.Incluir(objeto); return null;
        }

        //-- alterar

        public object Alterar(TObject objeto)
        {
            AbstractService.Alterar(objeto); return null;
        }

        //-- salvar

        public object Salvar(TObject objeto)
        {
            AbstractService.Salvar(objeto); return null;
        }

        //-- excluir

        public object Excluir(TObject objeto)
        {
            AbstractService.Excluir(objeto); return null;
        }

        //-- sequencia

        public object Sequencia(TObject filtro)
        {
            return AbstractService.Sequencia(filtro);
        }
    }
}