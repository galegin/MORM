using System;

namespace MORM.Apresentacao.Menus
{
    public interface IMenuResolver
    {
    }

    public interface IMenuResolverClasse : IMenuResolver
    {
        void Executar(Type classe);
    }

    public interface IMenuResolverObjeto : IMenuResolver
    {
        void Executar(object objeto);
    }

    public interface IMenuResolverTipo : IMenuResolver
    {
        void Executar<TObject>() where TObject : class;
    }
}