using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Menus;

namespace MORM.Apresentacao
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<IAmbiente, Ambiente>();
            container.Register<IUsuario, Usuario>();
            container.Register<IEmpresa, Empresa>();
            container.Register<ITerminal, Terminal>();
            container.Register<IInformacaoSistema, InformacaoSistema>();

            container.RegisterSingleton<IMainWindow, MainWindow>();

            container.Register<IMenuLateral, ucMenuLateral>();
            container.Register<ITituloSistema, ucTituloSistema>();

            container.Register<IMenuResolver, MenuResolver>();
        }
    }
}