using System;

namespace MORM.Dominio.Interfaces
{
    public interface IMigracao
    {
        void Clear();
        void CreateOrAlter(Type type);
        void CreateOrAlter<TObject>();
        void DropForeigns();
        void CreateForeigns();
    }
}