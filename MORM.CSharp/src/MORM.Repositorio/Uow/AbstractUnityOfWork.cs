using MORM.Repositorio.Interfaces;
using MORM.Utilidade.Interfaces;
using System;

namespace MORM.Repositorio.Uow
{
    //-- galeg - 28/04/2018 15:18:31
    public class AbstractUnityOfWork : IAbstractUnityOfWork
    {
        public AbstractUnityOfWork(IAbstractDataContext dataContext) : this(dataContext.Ambiente)
        {
            DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public IAbstractDataContext DataContext { get; }
        public void SetAmbiente(IAmbiente ambiente) => DataContext.SetAmbiente(ambiente);

        public AbstractUnityOfWork(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }
        
        public IAmbiente Ambiente { get; }
    }
}