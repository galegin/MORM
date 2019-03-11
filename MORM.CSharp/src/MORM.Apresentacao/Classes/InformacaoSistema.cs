using MORM.Utilidade.Extensions;
using MORM.Utilidade.Interfaces;
using System;

namespace MORM.Apresentacao.Classes
{
    public class InformacaoSistema : IInformacaoSistema
    {
        public InformacaoSistema(IAmbiente ambiente, 
            IEmpresa empresa,
            IUsuario usuario,
            ITerminal terminal)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
            Ambiente.SetAmbiente();

            Empresa = empresa ?? throw new ArgumentNullException(nameof(empresa));
            Empresa.SetEmpresa();

            Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            Usuario.SetUsuario();

            Terminal = terminal ?? throw new ArgumentNullException(nameof(terminal));
            Terminal.SetTerminal();
        }

        public IAmbiente Ambiente { get; }
        public IEmpresa Empresa { get; }
        public IUsuario Usuario { get; }
        public ITerminal Terminal { get; }
    }
}