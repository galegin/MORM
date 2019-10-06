namespace MORM.CrossCutting
{
    public static class BaseInstaller
    {
        public static void AddCrossCutting(this IAbstractContainer container)
        {
            container.Register<IAmbiente, Ambiente>();
            container.Register<IEmpresa, Empresa>();
            container.Register<IGrupoEmpresa, GrupoEmpresa>();
            container.Register<ITerminal, Terminal>();
            container.Register<IUsuario, Usuario>();
        }
    }
}