using MORM.Dominio.Interfaces;
using MORM.Repositorio.Repositories;
using MORM.Repositorio.Uow;
using MORM.Servico.Interfaces;
using System;

namespace MORM.Servico.Services
{
    public class AbstractService : IAbstractService
    {
        public AbstractService(IAbstractUnityOfWork abstractUnityOfWork)
        {
            AbstractUnityOfWork = abstractUnityOfWork ?? throw new ArgumentNullException(nameof(abstractUnityOfWork));
        }

        public IAbstractUnityOfWork AbstractUnityOfWork { get; }
    }

    public class AbstractService<TObject> : AbstractService, IAbstractService<TObject> where TObject : class
    {
        public AbstractService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
            AbstractRepository = new AbstractRepository<TObject>(abstractUnityOfWork.DataContext);
        }

        public IAbstractRepository<TObject> AbstractRepository { get; }
    }

    public class AbstractAmbService : IAbstractAmbService
    {
        public AbstractAmbService(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }

        public IAmbiente Ambiente { get; }
    }
}