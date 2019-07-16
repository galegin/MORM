using System;

namespace MORM.Apresentacao.Menus
{
    public interface IMenuResolver
    {
        void Executar(Type classe);
        void Executar(object objeto);
        void Executar<TObject>() where TObject : class;
    }
}