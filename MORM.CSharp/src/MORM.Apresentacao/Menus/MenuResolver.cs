using System;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public class MenuResolver : IMenuResolver
    {
        public void Executar(object objeto)
        {
            TelaUtils.Instance.NavegarPara(objeto as UserControl);
        }

        public void Executar(Type classe) 
        {
            var userControl = TelaUtils.Instance.Container.Resolve(classe) as UserControl;
            TelaUtils.Instance.NavegarPara(userControl);
        }

        public void Executar<TObject>() where TObject : class
        {
            var userControl = TelaUtils.Instance.Container.Resolve<TObject>() as UserControl;
            TelaUtils.Instance.NavegarPara(userControl);
        }
    }
}