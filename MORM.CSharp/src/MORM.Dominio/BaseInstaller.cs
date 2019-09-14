using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.CrossCutting;

namespace MORM.Dominio
{
    public static class BaseInstaller
    {
        public static void AddDominio(this IAbstractContainer container)
        {
            container.Register<IAmbiente, Ambiente>();
            container.Register<IEmpresa, Empresa>();
            container.Register<IGrupoEmpresa, GrupoEmpresa>();
            container.Register<ITerminal, Terminal>();
            container.Register<IUsuario, Usuario>();
        }
    }
}