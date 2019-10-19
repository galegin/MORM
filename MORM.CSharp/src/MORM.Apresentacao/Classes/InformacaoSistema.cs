using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public class InformacaoSistema : IInformacaoSistema
    {
        public InformacaoSistema(IAmbiente ambiente, 
            IEmpresa empresa,
            IUsuario usuario,
            ITerminal terminal)
        {
            Ambiente = Check.NotNull(ambiente, nameof(ambiente));
            Ambiente.SetAmbiente();

            Empresa = Check.NotNull(empresa, nameof(empresa));
            Empresa.SetEmpresa();

            Usuario = Check.NotNull(usuario, nameof(usuario));
            Usuario.SetUsuario();

            Terminal = Check.NotNull(terminal, nameof(terminal));
            Terminal.SetTerminal();
        }

        public IAmbiente Ambiente { get; }
        public IEmpresa Empresa { get; }
        public IUsuario Usuario { get; }
        public ITerminal Terminal { get; }
    }
}