using MORM.Utilidade.Entidades;
using MORM.Utilidade.Interfaces;
using MORM.IoC.Installer;
using MORM.Apresentacao.Classes;

namespace MORM.Apresentacao.IoC.Installer
{
    public class AbstractAppAmbienteInstaller : AbstractAmbienteInstaller
    {
        protected override void Setup()
        {
            Register<IAmbiente, Ambiente>();
            Register<IUsuario, Usuario>();
            Register<IEmpresa, Empresa>();
            Register<ITerminal, Terminal>();
            Register<IInformacaoSistema, InformacaoSistema>();
        }
    }
}