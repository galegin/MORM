using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Menus;
using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Mensagens;
using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public static class BaseInstaller
    {
        public static void AddApresentacao(this IAbstractContainer container)
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