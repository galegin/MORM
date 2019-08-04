using MORM.Dominio.Interfaces;
using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Menus;
using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Mensagens;

namespace MORM.Apresentacao
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<IInformacaoSistema, InformacaoSistema>();

            container.RegisterSingleton<IMainWindow, MainWindow>();
            container.RegisterSingleton<IMainLogin, MainLogin>();
            container.RegisterSingleton<IMainCommand, MainCommand>();
            container.RegisterSingleton<IMainMensagem, MainMensagem>();

            container.Register<IMenuLateral, ucMenuLateral>();
            container.Register<ITituloSistema, ucTituloSistema>();

            container.Register<IMenuResolver, MenuResolver>();
        }
    }
}