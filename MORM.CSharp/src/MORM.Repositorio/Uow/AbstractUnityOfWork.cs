using MORM.Repositorio.Interfaces;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Repositorio.Uow
{
    public class AbstractUnityOfWork : IAbstractUnityOfWork
    {
        public AbstractUnityOfWork(IAbstractDataContext dataContext)
        {
            DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public IAbstractDataContext DataContext { get; }
        public void SetAmbiente(IAmbiente ambiente) => DataContext.SetAmbiente(ambiente);
    }

    public class AbstractAmbUnityOfWork : IAbstracAmbtUnityOfWork
    {
        public AbstractAmbUnityOfWork(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }

        public IAmbiente Ambiente { get; }
    }
}