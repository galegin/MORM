using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.Dominio
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<IAmbiente, Ambiente>();
            container.Register<IEmpresa, Empresa>();
            container.Register<ITerminal, Terminal>();
            container.Register<IUsuario, Usuario>();
        }
    }
}