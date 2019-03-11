using System;

namespace MORM.Repositorio.Interfaces
{
    //-- galeg - 28/04/2018 20:24:50
    public interface IMigracao
    {
        void Clear();
        void CreateOrAlter(Type type);
        void CreateOrAlter<TObject>();
        void DropForeigns();
        void CreateForeigns();
    }
}