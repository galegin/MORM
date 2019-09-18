using MORM.Dominio.Interfaces;
using MORM.Repositorio.Repositories;
using System;
using System.Linq;

namespace MORM.Servico.Services
{
    public class AbstractAppService : IAbstractAppService
    {
        //public IAbstractUnityOfWork AbstractUnityOfWork { get; }
        private IAbstractDataContext _dataContext;

        //public AbstractAppService(IAbstractUnityOfWork abstractUnityOfWork)
        public AbstractAppService(IAbstractDataContext dataContext)
        {
            //AbstractUnityOfWork = abstractUnityOfWork ?? throw new ArgumentNullException(nameof(abstractUnityOfWork));
            _dataContext = dataContext;
        }

        //public void SetAmbiente(IAmbiente ambiente) => AbstractUnityOfWork.SetAmbiente(ambiente);
        public void SetAmbiente(IAmbiente ambiente) => _dataContext.SetAmbiente(ambiente);
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
        //public IAbstractService<TObject> AbstractService { get; }
        public IRepository<TObject> Repository { get; }

        //public AbstractAppService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        public AbstractAppService(IAbstractDataContext dataContext) : base(dataContext)
        {
            //AbstractService = new AbstractService<TObject>(abstractUnityOfWork);
            Repository = RepositoryExtensions.GetRepository<TObject>(dataContext);
        }

        //-- listar

        public object Listar(TObject filtro)
        {
            return Repository.GetAll().Where(filtro).ToList();
        }

        //-- consultar

        public object Consultar(TObject filtro)
        {
            return Repository.GetAll().FirstOrDefault(filtro);
        }

        //-- incluir

        public object Incluir(TObject objeto)
        {
            Repository.Add(objeto); return null;
        }

        //-- alterar

        public object Alterar(TObject objeto)
        {
            Repository.Update(objeto); return null;
        }

        //-- salvar

        public object Salvar(TObject objeto)
        {
            Repository.AddOrUpdate(objeto); return null;
        }

        //-- excluir

        public object Excluir(TObject objeto)
        {
            Repository.Delete(objeto); return null;
        }

        //-- sequencia

        public object Sequencia(TObject filtro)
        {
            return Repository.Sequencia(filtro);
        }
    }
}