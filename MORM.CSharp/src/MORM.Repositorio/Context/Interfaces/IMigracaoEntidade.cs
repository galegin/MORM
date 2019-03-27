using System;

namespace MORM.Repositorio.Interfaces
{
    public interface IMigracaoEntidade
    {
        void Clear();
        void CreateOrAlter(Type type);
        void CreateOrAlter<TObject>();
        void DropForeigns();
        void CreateForeigns();
    }
}