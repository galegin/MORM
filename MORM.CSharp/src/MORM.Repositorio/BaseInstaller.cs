using MORM.CrossCutting;

namespace MORM.Repositorio
{
    public static class BaseInstaller
    {
        public static void AddRepositorio(this IAbstractContainer container)
        {
            container.Register<IEmpresaRepository, EmpresaRepository>();
            container.Register<IGrupoEmpresaRepository, GrupoEmpresaRepository>();
            container.Register<ITerminalRepository, TerminalRepository>();
            container.Register<IUsuarioRepository, UsuarioRepository>();

            container.Register<IAmbienteRepository, AmbienteRepository>();
            container.Register<ILogAcessoRepository, LogAcessoRepository>();
            container.Register<IMigracaoEntRepository, MigracaoEntRepository>();
            container.Register<IPermissaoRepository, PermissaoRepository>();

            container.Register<IAbstractDataContext, AbstractDataContext>();
        }
    }
}