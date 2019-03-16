using System;
using System.Windows.Controls;

namespace MORM.Apresentacao.Menus
{
    public class MenuResolver : IMenuResolver
    {
        protected readonly IMainWindowExec _mainWindowExec;

        public MenuResolver(IMainWindowExec mainWindowExec)
        {
            _mainWindowExec = mainWindowExec ?? throw new ArgumentNullException(nameof(mainWindowExec));
        }
    }

    public class MenuResolverObjeto : MenuResolver, IMenuResolverObjeto
    {
        public MenuResolverObjeto(IMainWindowExec mainWindowExec) : base(mainWindowExec) { }

        public void Executar(object objeto)
        {
            _mainWindowExec.Navegar(objeto as UserControl);
        }
    }

    public class MenuResolverClasse : MenuResolver, IMenuResolverClasse
    {
        public MenuResolverClasse(IMainWindowExec mainWindowExec) : base(mainWindowExec) { }

        public void Executar(Type classe) 
        {
            _mainWindowExec.Navegar(_mainWindowExec.Container.Resolve(classe) as UserControl);
        }
    }

    public class MenuResolverTipo : MenuResolver, IMenuResolverTipo
    {
        public MenuResolverTipo(IMainWindowExec mainWindowExec) : base(mainWindowExec) { }

        public void Executar<TObject>() where TObject : class
        {
            _mainWindowExec.Navegar(_mainWindowExec.Container.Resolve<TObject>() as UserControl);
        }
    }
}