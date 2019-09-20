using MORM.Dominio.Interfaces;
using System;

namespace MORM.Repositorio.UnityOfWork
{
    public class AbstractUnityOfWork : IAbstractUnityOfWork
    {
        private readonly IAbstractDataContext _dataContext;

        public AbstractUnityOfWork(IAbstractDataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public void SetAmbiente(IAmbiente ambiente) => 
            _dataContext.SetAmbiente(ambiente);
    }

    public class AbstractAmbUnityOfWork : IAbstracAmbtUnityOfWork
    {
        private readonly IAmbiente _ambiente;

        public AbstractAmbUnityOfWork(IAmbiente ambiente)
        {
            _ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }
    }
}