using MORM.Dominio.Interfaces;
using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Menus;
using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Mensagens;
using MORM.Infra.CrossCutting;

namespace MORM.Apresentacao
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<IInformacaoSistema, InformacaoSistema>();

            container.Register<IMainWindow, MainWindow>().PerSingleton();
            container.Register<IMainLogin, MainLogin>().PerSingleton();
            container.Register<IMainCommand, MainCommand>().PerSingleton();
            container.Register<IMainMensagem, MainMensagem>().PerSingleton();

            container.Register<IMenuLateral, ucMenuLateral>();
            container.Register<ITituloSistema, ucTituloSistema>();

            container.Register<IMenuResolver, MenuResolver>();
        }
    }
}