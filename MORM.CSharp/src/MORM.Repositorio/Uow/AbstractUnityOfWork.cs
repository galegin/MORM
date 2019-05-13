using MORM.Repositorio.Interfaces;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Repositorio.Uow
{
    public class AbstractUnityOfWork : IAbstractUnityOfWork
    {
        public IAbstractDataContext DataContext { get; }

        public AbstractUnityOfWork(IAbstractDataContext dataContext)
        {
            DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public void SetAmbiente(IAmbiente ambiente) => DataContext.SetAmbiente(ambiente);
    }

    public class AbstractAmbUnityOfWork : IAbstracAmbtUnityOfWork
    {
        public IAmbiente Ambiente { get; }

        public AbstractAmbUnityOfWork(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }
    }
}