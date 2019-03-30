using MORM.Apresentacao.Comps;
using System;
using System.Windows.Controls;

namespace MORM.Apresentacao.Menus
{
    public class MenuResolver : IMenuResolver
    {
    }

    public class MenuResolverObjeto : MenuResolver, IMenuResolverObjeto
    {
        public void Executar(object objeto)
        {
            TelaUtils.Instance.NavegarPara(objeto as UserControl);
        }
    }

    public class MenuResolverClasse : MenuResolver, IMenuResolverClasse
    {
        public void Executar(Type classe) 
        {
            var userControl = TelaUtils.Instance.Container.Resolve(classe) as UserControl;
            TelaUtils.Instance.NavegarPara(userControl);
        }
    }

    public class MenuResolverTipo : MenuResolver, IMenuResolverTipo
    {
        public void Executar<TObject>() where TObject : class
        {
            var userControl = TelaUtils.Instance.Container.Resolve<TObject>() as UserControl;
            TelaUtils.Instance.NavegarPara(userControl);
        }
    }
}