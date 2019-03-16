using MORM.Utilidade.Entidades;
using MORM.Utilidade.Interfaces;

namespace MORM.Ioc.Installer
{
    public class AbstractAmbienteInstaller : AbstractInstaller
    {
        protected override void Setup()
        {
            Register<IAmbiente, Ambiente>();
            Register<IUsuario, Usuario>();
            Register<IEmpresa, Empresa>();
            Register<ITerminal, Terminal>();
        }
    }
}