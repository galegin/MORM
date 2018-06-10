using MORM.Utilidade.Interfaces;
using System;

namespace MORM.Repositorio.IoC
{
    //-- galeg - 28/04/2018 15:18:31
    public class UnityOfWork : IUnityOfWork
    {
        public UnityOfWork()
        {
        }

        public UnityOfWork(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }

        public IAmbiente Ambiente { get; }
    }
}