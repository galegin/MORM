using MORM.Repositorio.Context;
using MORM.Repositorio.Uow;
using MORM.Repositorio.Repositories;
using MORM.Utilidade.Interfaces;
using System;

namespace MORM.Repositorio.Services
{
    //-- galeg - 01/05/2018 11:14:23
    public class AbstractService : IAbstractService
    {
        public AbstractService(IAbstractUnityOfWork abstractUnityOfWork) : this(abstractUnityOfWork.Ambiente)
        {
            AbstractUnityOfWork = abstractUnityOfWork ?? throw new ArgumentNullException(nameof(abstractUnityOfWork));
        }

        public IAbstractUnityOfWork AbstractUnityOfWork { get; }

        public AbstractService(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }

        public IAmbiente Ambiente { get; }
    }

    public class AbstractService<TObject> : AbstractService, IAbstractService<TObject> where TObject : class
    {
        public AbstractService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
            AbstractRepository = new AbstractRepository<TObject>(abstractUnityOfWork.DataContext);
        }

        public AbstractService(IAmbiente ambiente) : base(ambiente)
        {
            AbstractRepository = new AbstractRepository<TObject>(new AbstractDataContext(ambiente));
        }

        public IAbstractRepository<TObject> AbstractRepository { get; }
    }
}