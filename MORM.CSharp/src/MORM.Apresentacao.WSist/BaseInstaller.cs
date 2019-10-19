using MORM.CrossCutting;

namespace MORM.Apresentacao.WSist
{
    public static class BaseInstaller
    {
        public static void AddApresentacaoSist(this IAbstractContainer container)
        {
            container.Register<IMenuSistema, MenuSistema>();
            
            container.Register<IAmbienteView, AmbienteView>();
            container.Register<ILogAcessoView, LogAcessoView>();
            container.Register<IMigracaoEntView, MigracaoEntView>();
            container.Register<IPermissaoView, PermissaoView>();
            container.Register<IEmpresaView, EmpresaView>();
            container.Register<IGrupoEmpresaView, GrupoEmpresaView>();
            container.Register<ITerminalView, TerminalView>();
            container.Register<IUsuarioView, UsuarioView>();
        }
    }
}